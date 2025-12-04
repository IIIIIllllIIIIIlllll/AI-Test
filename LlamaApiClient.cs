using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Net.Http.Headers;

namespace LlamaWorker
{
    public class LlamaApiClient : IDisposable
    {
        private readonly HttpClient _httpClient;
        public readonly string _baseUrl;
        private readonly string _apiKey;

        public LlamaApiClient(string baseUrl = "http://127.0.0.1:8080", string apiKey = "")
        {
            _httpClient = new HttpClient
            {
                Timeout = TimeSpan.FromMinutes(10) // 设置10分钟超时
            };
            _httpClient.DefaultRequestHeaders.Add("Connection", "keep-alive");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            
            // 如果提供了API密钥，添加到请求头
            if (!string.IsNullOrEmpty(apiKey))
            {
                _httpClient.DefaultRequestHeaders.Remove("Authorization");
                _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
                _httpClient.DefaultRequestHeaders.Remove("X-API-Key");
                _httpClient.DefaultRequestHeaders.Add("X-API-Key", apiKey);
                _httpClient.DefaultRequestHeaders.Remove("api-key");
                _httpClient.DefaultRequestHeaders.Add("api-key", apiKey);
            }
            
            _baseUrl = OptimizeUrl(baseUrl.TrimEnd('/'));
            _apiKey = apiKey;
        }

        /// <summary>
        /// 优化URL，将localhost替换为127.0.0.1以避免DNS解析延迟
        /// </summary>
        /// <param name="url">原始URL</param>
        /// <returns>优化后的URL</returns>
        private static string OptimizeUrl(string url)
        {
            if (string.IsNullOrEmpty(url))
                return url;

            // 替换localhost为127.0.0.1，不区分大小写
            return url.Replace("localhost", "127.0.0.1", StringComparison.OrdinalIgnoreCase);
        }

        private static string BuildModelsUrl(string baseUrl)
        {
            var trimmed = baseUrl.TrimEnd('/');
            var match = Regex.Match(trimmed, @"/v\d+$");
            return match.Success ? $"{trimmed}/models" : $"{trimmed}/v1/models";
        }

        private void AddAuthHeaders(HttpRequestMessage request)
        {
            if (!string.IsNullOrEmpty(_apiKey))
            {
                request.Headers.Remove("Authorization");
                request.Headers.Add("Authorization", $"Bearer {_apiKey}");
                request.Headers.Remove("X-API-Key");
                request.Headers.Add("X-API-Key", _apiKey);
                request.Headers.Remove("api-key");
                request.Headers.Add("api-key", _apiKey);
            }
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// 发送聊天请求到llama.cpp API
        /// </summary>
        /// <param name="systemPrompt">系统提示词</param>
        /// <param name="userPrompt">用户提示词</param>
        /// <param name="model">模型名称</param>
        /// <param name="temperature">温度参数 (0.0-2.0)</param>
        /// <param name="maxTokens">最大token数量</param>
        /// <param name="topP">Top-P参数 (0.0-1.0)</param>
        /// <param name="stream">是否使用流式响应</param>
        /// <returns>API响应</returns>
        public async Task<string> SendChatRequestAsync(string systemPrompt, string userPrompt, string model = "", double temperature = 0.7, int maxTokens = 4096, double topP = 0.9, bool stream = false)
        {
            var requestData = new
            {
                messages = new[]
                {
                    new { role = "system", content = systemPrompt },
                    new { role = "user", content = userPrompt }
                },
                model = !string.IsNullOrEmpty(model) ? model : null,
                temperature = temperature,
                max_tokens = maxTokens,
                top_p = topP,
                stream = stream
            };

            var json = JsonConvert.SerializeObject(requestData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, $"{_baseUrl}/v1/chat/completions")
                {
                    Content = content
                };
                AddAuthHeaders(request);

                using var response = await _httpClient.SendAsync(request, stream ? HttpCompletionOption.ResponseHeadersRead : HttpCompletionOption.ResponseContentRead);
                response.EnsureSuccessStatusCode();

                if (stream)
                {
                    // 流式响应处理将在后续实现
                    return await HandleStreamResponse(response);
                }
                else
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    return ParseNormalResponse(responseContent);
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"API请求失败: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"处理请求时发生错误: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// 发送流式聊天请求
        /// </summary>
        /// <param name="systemPrompt">系统提示词</param>
        /// <param name="userPrompt">用户提示词</param>
        /// <param name="onChunkReceived">接收到数据块时的回调</param>
        /// <param name="model">模型名称</param>
        /// <param name="temperature">温度参数 (0.0-2.0)</param>
        /// <param name="maxTokens">最大token数量</param>
        /// <param name="topP">Top-P参数 (0.0-1.0)</param>
        /// <returns></returns>
        public class Attachment
        {
            public string Mime { get; set; } = "image/png";
            public string Base64Data { get; set; } = string.Empty;
        }

        public async Task SendStreamChatRequestAsync(string systemPrompt, string userPrompt, Action<string> onChunkReceived, string model = "", double temperature = 0.7, int maxTokens = 0, double topP = 0.9, List<Attachment>? attachments = null)
        {
            var requestData = new JObject();
            var messages = new JArray();
            // system prompt as content parts
            var systemContent = new JArray
            {
                new JObject { ["type"] = "text", ["text"] = systemPrompt }
            };
            messages.Add(new JObject { ["role"] = "system", ["content"] = systemContent });

            // user content parts
            var userContent = new JArray
            {
                new JObject { ["type"] = "text", ["text"] = userPrompt }
            };
            if (attachments != null && attachments.Count > 0)
            {
                foreach (var att in attachments)
                {
                    if (string.IsNullOrWhiteSpace(att.Base64Data)) continue;
                    var url = $"data:{att.Mime};base64,{att.Base64Data}";
                    userContent.Add(new JObject
                    {
                        ["type"] = "image_url",
                        ["image_url"] = new JObject { ["url"] = url }
                    });
                }
            }
            messages.Add(new JObject { ["role"] = "user", ["content"] = userContent });
            requestData["messages"] = messages;
            if (!string.IsNullOrEmpty(model)) requestData["model"] = model;
            requestData["temperature"] = temperature;
            if (maxTokens > 0) requestData["max_tokens"] = maxTokens;
            requestData["top_p"] = topP;
            requestData["stream"] = true;

            var json = requestData.ToString(Newtonsoft.Json.Formatting.None);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, $"{_baseUrl}/v1/chat/completions")
                {
                    Content = content
                };
                AddAuthHeaders(request);

                using var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();

                using var stream = await response.Content.ReadAsStreamAsync();
                using var reader = new StreamReader(stream);

                string? line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    // 处理空行
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    if (line.StartsWith("data: "))
                    {
                        var data = line.Substring(6).Trim();
                        
                        // 检查结束标志
                        if (data == "[DONE]")
                            break;

                        // 跳过空数据
                        if (string.IsNullOrWhiteSpace(data))
                            continue;

                        try
                        {
                            var chunk = JsonConvert.DeserializeObject<dynamic>(data);
                            if (chunk?.choices != null && chunk.choices.Count > 0)
                            {
                                var content_chunk = chunk.choices[0]?.delta?.content?.ToString();
                                if (!string.IsNullOrEmpty(content_chunk))
                                {
                                    // 处理换行符，确保正确显示
                                    content_chunk = content_chunk!.Replace("\\n", Environment.NewLine)
                                                               .Replace("\\r\\n", Environment.NewLine)
                                                               .Replace("\\r", Environment.NewLine);
                                    onChunkReceived(content_chunk);
                                }
                            }
                        }
                        catch (JsonException ex)
                        {
                            // 记录JSON解析错误但继续处理
                            System.Diagnostics.Debug.WriteLine($"[StreamRequest] JSON解析错误: {ex.Message}, 数据: {data}");
                            continue;
                        }
                        catch (Exception ex)
                        {
                            // 捕获其他可能的异常
                            System.Diagnostics.Debug.WriteLine($"[StreamRequest] 处理流数据时出错: {ex.Message}, 数据: {data}");
                            continue;
                        }
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine($"[StreamRequest] HttpRequestException: {ex}");
                throw new Exception($"流式API请求失败: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex) when (ex.InnerException is TimeoutException)
            {
                Debug.WriteLine($"[StreamRequest] Timeout: {ex}");
                throw new Exception("请求超时，请检查网络连接或增加超时时间", ex);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[StreamRequest] Exception: {ex}");
                throw new Exception($"处理流式请求时发生错误: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// 处理流式响应
        /// </summary>
        private async Task<string> HandleStreamResponse(HttpResponseMessage response)
        {
            var result = new StringBuilder();
            using var stream = await response.Content.ReadAsStreamAsync();
            using var reader = new StreamReader(stream);

            string? line;
            while ((line = await reader.ReadLineAsync()) != null)
            {
                // 处理空行
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                if (line.StartsWith("data: "))
                {
                    var data = line.Substring(6).Trim();
                    
                    // 检查结束标志
                    if (data == "[DONE]")
                        break;

                    // 跳过空数据
                    if (string.IsNullOrWhiteSpace(data))
                        continue;

                    try
                    {
                        var chunk = JsonConvert.DeserializeObject<dynamic>(data);
                        if (chunk?.choices != null && chunk.choices.Count > 0)
                        {
                            var content = chunk.choices[0]?.delta?.content?.ToString();
                            if (!string.IsNullOrEmpty(content))
                            {
                                // 处理换行符，确保正确显示
                                content = content!.Replace("\\n", Environment.NewLine)
                                               .Replace("\\r\\n", Environment.NewLine)
                                               .Replace("\\r", Environment.NewLine);
                                result.Append(content);
                            }
                        }
                    }
                    catch (JsonException ex)
                    {
                        // 记录JSON解析错误但继续处理
                        System.Diagnostics.Debug.WriteLine($"JSON解析错误: {ex.Message}, 数据: {data}");
                        continue;
                    }
                    catch (Exception ex)
                    {
                        // 捕获其他可能的异常
                        System.Diagnostics.Debug.WriteLine($"处理流数据时出错: {ex.Message}, 数据: {data}");
                        continue;
                    }
                }
            }

            return result.ToString();
        }

        /// <summary>
        /// 解析普通响应
        /// </summary>
        private string ParseNormalResponse(string responseContent)
        {
            try
            {
                var response = JsonConvert.DeserializeObject<dynamic>(responseContent);
                if (response?.choices != null && response.choices.Count > 0)
                {
                    var content = response.choices[0]?.message?.content?.ToString() ?? "无响应内容";
                    
                    // 处理换行符，确保正确显示
                    var formatted = content.Replace("\\n", Environment.NewLine)
                                 .Replace("\\r\\n", Environment.NewLine)
                                 .Replace("\\r", Environment.NewLine);
                    return formatted;
                }
                else
                {
                    Debug.WriteLine("[ParseNormal] 无响应内容或choices为空");
                    return "无响应内容";
                }
            }
            catch (JsonException ex)
            {
                Debug.WriteLine($"[ParseNormal] JsonException: {ex}\nRaw: {responseContent}");
                throw new Exception($"解析响应失败: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ParseNormal] Exception: {ex}\nRaw: {responseContent}");
                throw new Exception($"处理响应时发生错误: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// 获取可用的模型列表
        /// </summary>
        /// <returns>模型列表</returns>
        public async Task<List<string>> GetModelsAsync(string url)
        {
            try
            {
                // 优化URL，将localhost替换为127.0.0.1以避免DNS解析延迟
                var optimizedUrl = OptimizeUrl(url);
                
                var request = new HttpRequestMessage(HttpMethod.Get, optimizedUrl);
                AddAuthHeaders(request);
                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                var modelsResponse = JsonConvert.DeserializeObject<dynamic>(responseContent);
                
                var models = new List<string>();
                if (modelsResponse?.data != null)
                {
                    foreach (var model in modelsResponse.data)
                    {
                        try
                        {
                            var modelId = model?.id?.ToString();
                            if (!string.IsNullOrEmpty(modelId))
                            {
                                models.Add(modelId);
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine($"解析模型ID时出错: {ex.Message}");
                            continue;
                        }
                    }
                }
                

                return models;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"获取模型列表失败: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"处理模型列表请求时发生错误: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// 测试API连接
        /// </summary>
        public async Task<bool> TestConnectionAsync()
        {
            try
            {
                var url = BuildModelsUrl(_baseUrl);
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                AddAuthHeaders(request);
                var response = await _httpClient.SendAsync(request);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
            GC.SuppressFinalize(this);
        }

        public void CancelPendingRequests()
        {
            try
            {
                _httpClient.CancelPendingRequests();
            }
            catch { }
        }

        /// <summary>
        /// 从配置文件创建API客户端实例
        /// </summary>
        /// <returns>配置好的API客户端实例</returns>
        public static LlamaApiClient CreateFromConfig()
        {
            try
            {
                string configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "api_settings.json");
                
                if (File.Exists(configFilePath))
                {
                    var json = File.ReadAllText(configFilePath);
                    var settings = JsonConvert.DeserializeObject<ApiSettings>(json);
                    
                    if (settings != null)
                    {
                        return new LlamaApiClient(settings.ApiBaseUrl, settings.ApiKey);
                    }
                }
                
                // 如果配置文件不存在或读取失败，使用默认设置
                return new LlamaApiClient();
            }
            catch
            {
                // 发生任何异常时都返回默认配置的客户端
                return new LlamaApiClient();
            }
        }
    }

    // API设置类，用于序列化配置
    public class ApiSettings
    {
        public string ApiBaseUrl { get; set; } = "http://127.0.0.1:8080";
        public string ApiKey { get; set; } = "";
        public string Model { get; set; } = "";
        public double Temperature { get; set; } = 0.7;
        public int MaxTokens { get; set; } = 4096;
        public double TopP { get; set; } = 0.9;
        public string SystemPrompt { get; set; } = "你是一个专业的AI助手，擅长回答各种学科的问题。请提供准确、详细且易于理解的答案。";
    }
}
