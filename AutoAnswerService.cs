using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            string model = "";
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
                        model = settings.Model;
                        temperature = settings.Temperature;
                        maxTokens = settings.MaxTokens;
                        topP = settings.TopP;
                        if (!string.IsNullOrWhiteSpace(settings.SystemPrompt)) systemPrompt = settings.SystemPrompt;
                    }
                }
            }
            catch { }

            var total = items.Count;
            for (int i = 0; i < total; i++)
            {
                if (_cts.IsCancellationRequested) break;
                var item = items[i];
                OnProgress?.Invoke(i + 1, total, item.title);
                try
                {
                    var answer = await _client!.SendChatRequestAsync(systemPrompt, item.question, model, temperature, maxTokens, topP, stream: false);
                    SaveAiAnswer(item.title, answer);
                    OnLog?.Invoke($"已完成: {item.title}");
                }
                catch (Exception ex)
                {
                    OnLog?.Invoke($"失败: {item.title} - {ex.Message}");
                }
            }
        }

        private void SaveAiAnswer(string title, string answer)
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
                            obj["aiAnswer"] = answer;
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

