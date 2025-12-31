using AITest.OpenAI;
using AITest.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AITest.OpenAI
{
    public class OpenAIClient : IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly OpenAIConfig _config;
        private readonly JsonSerializerOptions _jsonOptions;
        private bool _disposed = false;

        /// <summary>
        /// 初始化OpenAI客户端
        /// </summary>
        /// <param name="config">OpenAI配置</param>
        public OpenAIClient(OpenAIConfig config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));

            if (!_config.IsValid())
            {
                throw new ArgumentException("Invalid OpenAI configuration. Please check your API key and other settings.", nameof(config));
            }

            _httpClient = new HttpClient();
            _httpClient.Timeout = TimeSpan.FromMilliseconds(_config.TimeoutMs);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _config.ApiKey);
            _httpClient.DefaultRequestHeaders.Add("User-Agent", _config.UserAgent);

            if (!string.IsNullOrWhiteSpace(_config.OrganizationId))
            {
                _httpClient.DefaultRequestHeaders.Add("OpenAI-Organization", _config.OrganizationId);
            }
        }

        /// <summary>
        /// 发送HTTP请求并处理响应
        /// </summary>
        /// <typeparam name="TResponse">响应类型</typeparam>
        /// <param name="method">HTTP方法</param>
        /// <param name="endpoint">API端点</param>
        /// <param name="request">请求数据（可选）</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>API响应</returns>
        protected async Task<TResponse> SendRequestAsync<TResponse>(
            HttpMethod method,
            string endpoint,
            ChatCompletionRequest? request = null,
            CancellationToken cancellationToken = default)
        {
            var url = _config.GetEndpointUrl(endpoint);
            HttpRequestMessage httpRequest;

            if (request != null)
            {
                var json = Tools.ToJson(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                httpRequest = new HttpRequestMessage(method, url) { Content = content };
            }
            else
            {
                httpRequest = new HttpRequestMessage(method, url);
            }

            try
            {
                var response = await _httpClient.SendAsync(httpRequest, cancellationToken);

                if (!response.IsSuccessStatusCode)
                {
                    await HandleErrorAsync(response);
                }

                var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
                return JsonSerializer.Deserialize<TResponse>(responseContent, _jsonOptions)
                    ?? throw new InvalidOperationException("Failed to deserialize API response.");
            }
            finally
            {
                httpRequest.Dispose();
            }
        }

        /// <summary>
        /// 处理API错误响应
        /// </summary>
        /// <param name="response">HTTP响应</param>
        private async Task HandleErrorAsync(HttpResponseMessage response)
        {
            var errorContent = await response.Content.ReadAsStringAsync();

            OpenAIErrorResponse? errorResponse;
            try
            {
                errorResponse = JsonSerializer.Deserialize<OpenAIErrorResponse>(errorContent, _jsonOptions);
            }
            catch
            {
                // 如果无法解析错误响应，使用通用错误
                throw new OpenAIException(
                    $"API request failed with status code {response.StatusCode}. Response: {errorContent}",
                    "api_error",
                    null,
                    response.StatusCode);
            }

            if (errorResponse?.Error != null)
            {
                throw new OpenAIException(errorResponse.Error, response.StatusCode);
            }

            throw new OpenAIException(
                $"API request failed with status code {response.StatusCode}. Response: {errorContent}",
                "api_error",
                null,
                response.StatusCode);
        }

        /// <summary>
        /// 发送聊天完成请求
        /// </summary>
        /// <param name="request">聊天完成请求参数</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>聊天完成响应</returns>
        public async Task<ChatCompletionResponse> ChatCompletionsAsync(
            ChatCompletionRequest request,
            CancellationToken cancellationToken = default)
        {
            return await SendRequestAsync<ChatCompletionResponse>(
                HttpMethod.Post,
                "chat/completions",
                request,
                cancellationToken);
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 释放资源的具体实现
        /// </summary>
        /// <param name="disposing">是否正在释放托管资源</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _httpClient?.Dispose();
                _disposed = true;
            }
        }
    }
}
