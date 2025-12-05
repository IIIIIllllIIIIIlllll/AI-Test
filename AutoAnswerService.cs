using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using LlamaWorker;

namespace AITest
{
    public class AutoAnswerService
    {
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();
        private LlamaApiClient? _client;

        public event Action<int, int, string>? OnProgress;
        public event Action<string>? OnLog;
        public event Action<string>? OnChunk;
        public event Action? OnStreamStart;

        public void Cancel()
        {
            try
            {
                _cts.Cancel();
                _client?.CancelPendingRequests();
            }
            catch { }
        }

        public async Task RunAsync(List<(string title, string question, string answer)> items)
        {
            try
            {
                _client = LlamaApiClient.CreateFromConfig();
            }
            catch
            {
                _client = new LlamaApiClient();
            }

            string configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "api_settings.json");
            var models = new List<string>();
            double temperature = 0.7;
            int maxTokens = 4096;
            double topP = 0.9;
            string systemPrompt = "你是一个专业的AI助手，擅长回答各种学科的问题。请提供准确、详细且易于理解的答案。";
            try
            {
                if (File.Exists(configFilePath))
                {
                    var json = File.ReadAllText(configFilePath);
                    var settings = JsonConvert.DeserializeObject<ApiSettings>(json);
                    if (settings != null)
                    {
                        if (settings.Models != null && settings.Models.Count > 0)
                        {
                            models.AddRange(settings.Models);
                        }
                        if (!string.IsNullOrWhiteSpace(settings.Model))
                        {
                            models.Add(settings.Model);
                        }
                        models = models
                            .Where(m => !string.IsNullOrWhiteSpace(m))
                            .Distinct()
                            .ToList();
                        temperature = settings.Temperature;
                        maxTokens = settings.MaxTokens;
                        topP = settings.TopP;
                        if (!string.IsNullOrWhiteSpace(settings.SystemPrompt)) systemPrompt = settings.SystemPrompt;
                    }
                }
            }
            catch { }

            var totalModels = models.Count > 0 ? models.Count : 1;
            var total = items.Count * totalModels;
            int progress = 0;
            for (int i = 0; i < items.Count; i++)
            {
                if (_cts.IsCancellationRequested) break;
                var item = items[i];
                var loopModels = models.Count > 0 ? models : new List<string> { "" };
                foreach (var model in loopModels)
                {
                    if (_cts.IsCancellationRequested) break;
                    progress++;
                    var titleWithModel = string.IsNullOrWhiteSpace(model) ? item.title : $"{item.title}（模型：{model}）";
                    OnProgress?.Invoke(progress, total, titleWithModel);
                    try
                    {
                        var buffer = new StringBuilder();
                        OnStreamStart?.Invoke();
                        await _client!.SendStreamChatRequestAsync(
                            systemPrompt,
                            item.question,
                            chunk =>
                            {
                                buffer.Append(chunk);
                                OnChunk?.Invoke(chunk);
                            },
                            model,
                            temperature,
                            maxTokens,
                            topP
                        );
                        var answer = buffer.ToString();
                        SaveAiAnswer(item.title, model, answer);
                        OnLog?.Invoke($"已完成: {titleWithModel}");
                    }
                    catch (Exception ex)
                    {
                        OnLog?.Invoke($"失败: {titleWithModel} - {ex.Message}");
                    }
                }
            }
        }

        private void SaveAiAnswer(string title, string model, string answer)
        {
            try
            {
                var folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "questions");
                var files = Directory.GetFiles(folder, "*.json");
                foreach (var file in files)
                {
                    try
                    {
                        var json = File.ReadAllText(file);
                        var obj = JObject.Parse(json);
                        var t = obj["title"]?.ToString();
                        if (string.Equals(t, title, StringComparison.Ordinal))
                        {
                            var answers = obj["aiAnswers"] as JObject ?? new JObject();
                            if (!string.IsNullOrWhiteSpace(model))
                            {
                                answers[model] = answer;
                            }
                            else
                            {
                                answers["default"] = answer;
                            }
                            obj["aiAnswers"] = answers;
                            File.WriteAllText(file, obj.ToString(Newtonsoft.Json.Formatting.Indented));
                            break;
                        }
                    }
                    catch { }
                }
            }
            catch { }
        }
    }
}
