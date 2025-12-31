using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using AITest.DataStruct;
using AITest.OpenAI;

namespace AITest
{
    public class AutoAnswerService
    {
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();

        public event Action<int, int, string>? OnProgress;
        public event Action<string>? OnLog;
        public event Action<string>? OnChunk;
        public event Action? OnStreamStart;

        public void Cancel()
        {
            try
            {
                _cts.Cancel();
            }
            catch { }
        }

        public async Task RunAsync(List<(string title, string question, string answer)> items)
        {
            // 这里读取配置文件
            string configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "api_settings.json");
            List<ApiConfig>? apiConfigs = null;
            try
            {
                if (File.Exists(configFilePath))
                {
                    var json = File.ReadAllText(configFilePath);
                    // 需要循环操作所有的模型
                    apiConfigs = JsonConvert.DeserializeObject<List<ApiConfig>>(json);
                }
                if (apiConfigs == null)
                    throw new Exception("配置文件：api_settings.json 错误，无法读取！");
            }
            catch {
                // TODO 出错了这里最好弄个提示
                return;
            }
            // 计算待测试的模型总数
            var totalModels = 0;
            // 
            foreach(ApiConfig apiConfig in apiConfigs)
                totalModels += apiConfig.Models.Count;
            // 问题数量 * 模型总数
            var total = items.Count * totalModels;
            int progress = 0;
            // 循环执行任务
            // 1.循环问题
            for (int i = 0; i < items.Count; i++)
            {
                if (_cts.IsCancellationRequested) break;
                var item = items[i];
                // 循环Config
                foreach (ApiConfig apiConfig in apiConfigs)
                {
                    // 再循环Config里的模型
                    foreach(ModelInfo model in apiConfig.Models)
                    {
                        if (_cts.IsCancellationRequested) break;
                        progress++;
                        var titleWithModel = string.IsNullOrWhiteSpace(model.Model) ? item.title : $"{item.title}（模型：{model}）";
                        // 这是干嘛的
                        OnProgress?.Invoke(progress, total, titleWithModel);
                        try
                        {
                            /*
                            var buffer = new StringBuilder();
                            OnStreamStart?.Invoke();
                            await _client!.SendStreamChatRequestAsync(
                                model.SystemPrompt,
                                item.question,
                                chunk =>
                                {
                                    buffer.Append(chunk);
                                    OnChunk?.Invoke(chunk);
                                },
                                model.Model,
                                model.Temperature,
                                model.MaxTokens,
                                model.TopP
                            );
                            var answer = buffer.ToString();
                            SaveAiAnswer(item.title, model.Model, answer);
                            */
                            OnLog?.Invoke($"已完成: {titleWithModel}");
                        }
                        catch (Exception ex)
                        {
                            OnLog?.Invoke($"失败: {titleWithModel} - {ex.Message}");
                        }
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
