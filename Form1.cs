using System.Data;
using System.IO;
using Newtonsoft.Json;

namespace AITest
{
    public partial class Form1 : Form
    {
        private Dictionary<string, (string question, string answer)> questionData = null!;
        private LlamaWorker.LlamaApiClient? _apiClient;

        public Form1()
        {
            InitializeComponent();
            InitializeQuestionData();
        }

        private void InitializeQuestionData()
        {
            questionData = new Dictionary<string, (string question, string answer)>();
            var folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "questions");
            if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
            var files = Directory.GetFiles(folder, "*.json");
            foreach (var file in files)
            {
                try
                {
                    var json = File.ReadAllText(file);
                    var item = JsonConvert.DeserializeObject<QuestionFile>(json);
                    if (item != null && !string.IsNullOrWhiteSpace(item.Title))
                    {
                        var q = item.Question ?? string.Empty;
                        var a = item.Answer ?? string.Empty;
                        questionData[item.Title] = (q, a);
                    }
                }
                catch
                {
                }
            }
        }

        public class QuestionFile
        {
            public string Title { get; set; } = string.Empty;
            public string Question { get; set; } = string.Empty;
            public string Answer { get; set; } = string.Empty;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBoxQuestions.Items.Clear();
            foreach (var key in questionData.Keys)
            {
                listBoxQuestions.Items.Add(key);
            }

            listBoxQuestions.SelectedIndexChanged += ListBoxQuestions_SelectedIndexChanged;
            btnAddQuestion.Click += BtnAddQuestion_Click;
            btnGetAIAnswer.Click += BtnGetAIAnswer_Click;

            // 初始化API客户端
            InitializeApiClient();

            // 默认选择第一题
            if (listBoxQuestions.Items.Count > 0)
            {
                listBoxQuestions.SelectedIndex = 0;
            }
        }

        private void ListBoxQuestions_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (listBoxQuestions.SelectedItem is string selected && questionData.ContainsKey(selected))
            {
                var data = questionData[selected];
                rtbQuestion.Text = data.question;
                rtbStandard.Text = data.answer;
                rtbAI.Clear();
            }
        }

        private void BtnAddQuestion_Click(object? sender, EventArgs e)
        {
            using (var dialog = new AddQuestionDialog())
            {
                // 设置对话框的父窗体，实现模态对话框效果
                dialog.ShowDialog(this);

                if (dialog.DialogResult == DialogResult.OK)
                {
                    // 添加新问题到数据字典
                    questionData[dialog.QuestionTitle] = (dialog.QuestionContent, dialog.AnswerContent);

                    // 刷新问题列表
                    listBoxQuestions.Items.Clear();
                    foreach (var key in questionData.Keys)
                    {
                        listBoxQuestions.Items.Add(key);
                    }

                    // 选中新添加的问题
                    listBoxQuestions.SelectedItem = dialog.QuestionTitle;
                }
            }
        }

        private void listBoxQuestions_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void BtnSettings_Click(object? sender, EventArgs e)
        {
            using (var dialog = new ApiSettingsDialog())
            {
                dialog.ShowDialog(this);

                if (dialog.DialogResult == DialogResult.OK)
                {
                    // 重新初始化API客户端
                    InitializeApiClient();
                    MessageBox.Show("API设置已保存并应用", "设置成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnScoreSettings_Click(object? sender, EventArgs e)
        {
            using (var dialog = new ScoreApiSettingsDialog())
            {
                dialog.ShowDialog(this);
                if (dialog.DialogResult == DialogResult.OK)
                {
                    MessageBox.Show("打分API设置已保存并应用", "设置成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void InitializeApiClient()
        {
            try
            {
                // 使用LlamaApiClient的静态方法从配置文件创建实例
                _apiClient = LlamaWorker.LlamaApiClient.CreateFromConfig();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"初始化API客户端失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _apiClient = new LlamaWorker.LlamaApiClient(); // 使用默认设置
            }
        }

        private async void GetAIAnswer(string question)
        {
            if (_apiClient == null)
            {
                rtbAI.Text = "API客户端未初始化，请检查设置";
                return;
            }

            try
            {
                rtbAI.Clear();
                btnGetAIAnswer.Enabled = false;
                
                // 从JSON配置文件获取参数
                string configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "api_settings.json");
                string model = "";
                double temperature = 0.7;
                int maxTokens = 4096;
                double topP = 0.9;

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
                    }
                }

                // 构建系统提示词
                string systemPrompt = "你是一个专业的AI助手，擅长回答各种学科的问题。请提供准确、详细且易于理解的答案。";
                if (File.Exists(configFilePath))
                {
                    try
                    {
                        var json2 = File.ReadAllText(configFilePath);
                        var settings2 = JsonConvert.DeserializeObject<ApiSettings>(json2);
                        if (settings2 != null && !string.IsNullOrWhiteSpace(settings2.SystemPrompt))
                        {
                            systemPrompt = settings2.SystemPrompt;
                        }
                    }
                    catch { }
                }

                await _apiClient.SendStreamChatRequestAsync(
                    systemPrompt,
                    question,
                    chunk =>
                    {
                        if (rtbAI.InvokeRequired)
                            rtbAI.Invoke(new Action(() => { rtbAI.AppendText(chunk); rtbAI.SelectionStart = rtbAI.TextLength; rtbAI.ScrollToCaret(); }));
                        else
                        {
                            rtbAI.AppendText(chunk);
                            rtbAI.SelectionStart = rtbAI.TextLength;
                            rtbAI.ScrollToCaret();
                        }
                    },
                    model,
                    temperature,
                    maxTokens,
                    topP
                );
            }
            catch (Exception ex)
            {
                rtbAI.Text = $"获取AI答案时出错: {ex.Message}";
            }
            finally
            {
                btnGetAIAnswer.Enabled = true;
            }
        }

        private void BtnGetAIAnswer_Click(object? sender, EventArgs e)
        {
            if (listBoxQuestions.SelectedItem is string selected && questionData.ContainsKey(selected))
            {
                var data = questionData[selected];
                GetAIAnswer(data.question);
            }
            else
            {
                MessageBox.Show("请先选择一个问题", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
