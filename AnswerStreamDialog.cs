using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using LlamaWorker;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Collections.Generic;

namespace AITest
{
    public partial class AnswerStreamDialog : Form
    {
        private readonly string _title;
        private readonly string _question;
        private LlamaApiClient? _client;

        public AnswerStreamDialog(string title, string question)
        {
            InitializeComponent();
            _title = title;
            _question = question;
            BeginAnswer();
            FormClosed += AnswerStreamDialog_FormClosed;
        }

        private async void BeginAnswer()
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

            tbOut.Clear();
            btnCancel.Enabled = true;
            btnRedo.Enabled = false;
            btnSave.Enabled = false;

            try
            {
                string userPrompt = _question;
                List<LlamaApiClient.Attachment> imageAttachments = new List<LlamaApiClient.Attachment>();
                try
                {
                    var qFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "questions");
                    var files = Directory.GetFiles(qFolder, "*.json");
                    foreach (var file in files)
                    {
                        var json = File.ReadAllText(file);
                        var obj = JObject.Parse(json);
                        var t = obj["title"]?.ToString();
                        if (string.Equals(t, _title, StringComparison.Ordinal))
                        {
                            var arr = obj["files"] as JArray;
                            if (arr != null && arr.Count > 0)
                            {
                                var sb = new StringBuilder();
                                sb.AppendLine(_question);
                                foreach (var item in arr)
                                {
                                    var name = item?.ToString() ?? "";
                                    if (string.IsNullOrWhiteSpace(name)) continue;
                                    var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "files", name);
                                    if (File.Exists(path))
                                    {
                                        try
                                        {
                                            var ext = Path.GetExtension(path).ToLowerInvariant();
                                            var isText = ext == ".txt" || ext == ".md" || ext == ".csv" || ext == ".json" || ext == ".xml" || ext == ".yaml" || ext == ".yml" || ext == ".ini" || ext == ".log";
                                            var isImage = ext == ".png" || ext == ".jpg" || ext == ".jpeg" || ext == ".gif" || ext == ".bmp" || ext == ".webp";
                                            if (isText)
                                            {
                                                var content = File.ReadAllText(path);
                                                sb.AppendLine($"\n[附件 文本 {name}]\n{content}\n");
                                            }
                                            else if (isImage)
                                            {
                                                var bytes = File.ReadAllBytes(path);
                                                var b64 = Convert.ToBase64String(bytes);
                                                var mime = ext switch
                                                {
                                                    ".png" => "image/png",
                                                    ".jpg" => "image/jpeg",
                                                    ".jpeg" => "image/jpeg",
                                                    ".gif" => "image/gif",
                                                    ".bmp" => "image/bmp",
                                                    ".webp" => "image/webp",
                                                    _ => "image/*"
                                                };
                                                imageAttachments.Add(new LlamaApiClient.Attachment { Mime = mime, Base64Data = b64 });
                                            }
                                            else
                                            {
                                                // 非文本且非图片的附件，作为说明文字追加
                                                sb.AppendLine($"\n[附件 {name}] (非图片二进制，省略数据)\n");
                                            }
                                        }
                                        catch { }
                                    }
                                }
                                userPrompt = sb.ToString();
                            }
                            break;
                        }
                    }
                }
                catch { }
                await _client!.SendStreamChatRequestAsync(
                systemPrompt,
                userPrompt,
                chunk =>
                {
                    if (tbOut.InvokeRequired)
                        tbOut.Invoke(new Action(() => { tbOut.AppendText(chunk); tbOut.SelectionStart = tbOut.TextLength; tbOut.ScrollToCaret(); }));
                    else
                    {
                        tbOut.AppendText(chunk);
                        tbOut.SelectionStart = tbOut.TextLength;
                        tbOut.ScrollToCaret();
                    }
                },
                model,
                temperature,
                maxTokens,
                topP,
                imageAttachments
                );
            }
            catch
            {
                // 被取消或失败
            }
            finally
            {
                if (IsHandleCreated)
                {
                    BeginInvoke(new Action(() =>
                    {
                        btnCancel.Enabled = false;
                        btnRedo.Enabled = true;
                        btnSave.Enabled = true;
                    }));
                }
            }
        }

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            try
            {
                btnCancel.Enabled = false;
                _client?.CancelPendingRequests();
                btnRedo.Enabled = true;
                btnSave.Enabled = true;
            }
            catch { }
        }

        private void btnRedo_Click(object? sender, EventArgs e)
        {
            btnCancel.Enabled = true;
            BeginAnswer();
        }

        private void btnSave_Click(object? sender, EventArgs e)
        {
            try
            {
                var folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "questions");
                var files = Directory.GetFiles(folder, "*.json");
                bool saved = false;
                foreach (var file in files)
                {
                    try
                    {
                        var json = File.ReadAllText(file);
                        var obj = JObject.Parse(json);
                        var t = obj["title"]?.ToString();
                        if (string.Equals(t, _title, StringComparison.Ordinal))
                        {
                            obj["aiAnswer"] = tbOut.Text;
                            File.WriteAllText(file, obj.ToString(Newtonsoft.Json.Formatting.Indented));
                            saved = true;
                            break;
                        }
                    }
                    catch { }
                }
                if (saved)
                {
                    MessageBox.Show("AI答案已保存", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("未找到问题文件", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AnswerStreamDialog_FormClosed(object? sender, FormClosedEventArgs e)
        {
            try
            {
                var folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "questions");
                var files = Directory.GetFiles(folder, "*.json");
                string aiAnswer = string.Empty;
                foreach (var file in files)
                {
                    try
                    {
                        var json = File.ReadAllText(file);
                        var obj = JObject.Parse(json);
                        var t = obj["title"]?.ToString();
                        if (string.Equals(t, _title, StringComparison.Ordinal))
                        {
                            aiAnswer = obj["aiAnswer"]?.ToString() ?? string.Empty;
                            break;
                        }
                    }
                    catch { }
                }
                if (Owner != null)
                {
                    var box = Owner.Controls.Find("tbAiAnswerBox", true).FirstOrDefault() as TextBox;
                    if (box != null)
                    {
                        box.Text = aiAnswer;
                    }
                }
            }
            catch { }
        }
    }
}

