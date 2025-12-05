using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using LlamaWorker;
using Newtonsoft.Json.Linq;

namespace AITest
{
    public partial class MainWindow : Form
    {
        private Dictionary<string, (string question, string answer)> questionData = null!;
        private LlamaApiClient? _apiClient;
        private System.Windows.Forms.Timer? _questionSaveTimer;
        private bool _suppressQuestionChange;
        private System.Windows.Forms.Timer? _answerSaveTimer;
        private bool _suppressAnswerChange;

        public MainWindow()
        {
            InitializeComponent();
            Load += MainWindow_Load;
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
                catch { }
            }
        }

        public class QuestionFile
        {
            public string Title { get; set; } = string.Empty;
            public string Question { get; set; } = string.Empty;
            public string Answer { get; set; } = string.Empty;
        }

        private void MainWindow_Load(object? sender, EventArgs e)
        {
            listQuestions.View = View.List;
            listQuestions.Items.Clear();
            foreach (var key in questionData.Keys)
            {
                listQuestions.Items.Add(new ListViewItem(key));
            }

            listQuestions.SelectedIndexChanged += ListView1_SelectedIndexChanged;
            btnAddQuestion.Click += BtnAddQuestion_Click;
            btnSubmitQuestion.Click += BtnSubmitQuestion_Click;
            btnShowAnswer.Click += BtnShowAnswer_Click;
            
            toolStripButton1.Click += BtnSettings_Click;
            toolStripButton2.Click += BtnScoreSettings_Click;
            btnAuto.Click += BtnAuto_Click;
            btnScore.Click += BtnScore_Click;
            btnDeleteQuestion.Click += BtnDeleteQuestion_Click;
            btnViewEvaluation.Click += BtnViewEvaluation_Click;

            InitializeApiClient();

            

            if (listQuestions.Items.Count > 0)
            {
                listQuestions.Items[0].Selected = true;
            }

            tbQuestion.AllowDrop = true;
            tbQuestion.DragEnter += OnFilesDragEnter;
            tbQuestion.DragDrop += OnFilesDragDrop;
            tbQuestion.TextChanged += TbQuestion_TextChanged;
            _questionSaveTimer = new System.Windows.Forms.Timer { Interval = 500 };
            _questionSaveTimer.Tick += QuestionSaveTimer_Tick;
            tbAnswer.TextChanged += TbAnswer_TextChanged;
            _answerSaveTimer = new System.Windows.Forms.Timer { Interval = 500 };
            _answerSaveTimer.Tick += AnswerSaveTimer_Tick;
            var listFilesCtrl = this.Controls.Find("listFiles", true).FirstOrDefault() as ListView;
            if (listFilesCtrl != null)
            {
                listFilesCtrl.AllowDrop = true;
                listFilesCtrl.DragEnter += OnFilesDragEnter;
                listFilesCtrl.DragDrop += OnFilesDragDrop;
                listFilesCtrl.View = View.List;
                listFiles.SelectedIndexChanged += ListFiles_SelectedIndexChanged;
            }
            btnDeleteFile.Enabled = false;
            btnDeleteFile.Click += BtnDeleteFile_Click;

            var listModelsCtrl = this.Controls.Find("listModels", true).FirstOrDefault() as ListView;
            if (listModelsCtrl != null)
            {
                try
                {
                    listModelsCtrl.View = View.List;
                    var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "api_settings.json");
                    if (File.Exists(path))
                    {
                        var json = File.ReadAllText(path);
                        var settings = JsonConvert.DeserializeObject<ApiSettings>(json);
                        listModelsCtrl.Items.Clear();
                        if (settings != null)
                        {
                            if (settings.Models != null && settings.Models.Count > 0)
                            {
                                foreach (var m in settings.Models)
                                {
                                    if (!string.IsNullOrWhiteSpace(m))
                                        listModelsCtrl.Items.Add(new ListViewItem(m));
                                }
                            }
                            else if (!string.IsNullOrWhiteSpace(settings.Model))
                            {
                                listModelsCtrl.Items.Add(new ListViewItem(settings.Model));
                            }
                        }
                    }
                }
                catch { }
                listModelsCtrl.SelectedIndexChanged += (s, e2) => RefreshModelAnswerForSelectedQuestion();
            }
        }

        private void BtnScore_Click(object? sender, EventArgs e)
        {
            if (listQuestions.SelectedItems.Count == 0)
            {
                MessageBox.Show("请先选择一个问题", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var title = listQuestions.SelectedItems[0].Text;
            using var dlg = new ScoreListDialog(title);
            dlg.ShowDialog(this);
        }

        private void OnFilesDragEnter(object? sender, DragEventArgs e)
        {
            if (e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void OnFilesDragDrop(object? sender, DragEventArgs e)
        {
            try
            {
                if (listQuestions.SelectedItems.Count == 0) return;
                var selected = listQuestions.SelectedItems[0].Text;
                if (!questionData.ContainsKey(selected)) return;
                if (e.Data == null) return;
                var dropped = e.Data.GetData(DataFormats.FileDrop) as string[];
                if (dropped == null || dropped.Length == 0) return;

                var dstFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "files");
                Directory.CreateDirectory(dstFolder);

                var copiedNames = new List<string>();
                foreach (var path in dropped)
                {
                    try
                    {
                        var name = Path.GetFileName(path);
                        var dst = Path.Combine(dstFolder, name);
                        int i = 1;
                        var baseName = Path.GetFileNameWithoutExtension(name);
                        var ext = Path.GetExtension(name);
                        while (File.Exists(dst))
                        {
                            dst = Path.Combine(dstFolder, $"{baseName}({i++}){ext}");
                        }
                        File.Copy(path, dst, overwrite: false);
                        copiedNames.Add(Path.GetFileName(dst));
                    }
                    catch { }
                }

                if (copiedNames.Count > 0)
                {
                    var qFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "questions");
                    var files = Directory.GetFiles(qFolder, "*.json");
                    foreach (var file in files)
                    {
                        try
                        {
                            var json = File.ReadAllText(file);
                            var obj = JObject.Parse(json);
                            var t = obj["title"]?.ToString();
                            if (string.Equals(t, selected, StringComparison.Ordinal))
                            {
                                var arr = obj["files"] as JArray ?? new JArray();
                                foreach (var n in copiedNames)
                                {
                                    bool exists = arr.Any(x => x?.ToString() == n);
                                    if (!exists) arr.Add(n);
                                }
                                obj["files"] = arr;
                                File.WriteAllText(file, obj.ToString(Newtonsoft.Json.Formatting.Indented));
                                break;
                            }
                        }
                        catch { }
                    }

                    var listFilesCtrl2 = this.Controls.Find("listFiles", true).FirstOrDefault() as ListView;
                    if (listFilesCtrl2 != null)
                    {
                        foreach (var n in copiedNames)
                        {
                            listFilesCtrl2.Items.Add(new ListViewItem(n));
                        }
                    }
                }
            }
            catch { }
        }

        private void TbQuestion_TextChanged(object? sender, EventArgs e)
        {
            if (_suppressQuestionChange) return;
            _questionSaveTimer?.Stop();
            _questionSaveTimer?.Start();
        }

        private void QuestionSaveTimer_Tick(object? sender, EventArgs e)
        {
            _questionSaveTimer?.Stop();
            try
            {
                if (listQuestions.SelectedItems.Count == 0) return;
                var selected = listQuestions.SelectedItems[0].Text;
                if (!questionData.ContainsKey(selected)) return;
                var qFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "questions");
                var files = Directory.GetFiles(qFolder, "*.json");
                foreach (var file in files)
                {
                    try
                    {
                        var json = File.ReadAllText(file);
                        var obj = JObject.Parse(json);
                        var t = obj["title"]?.ToString();
                        if (string.Equals(t, selected, StringComparison.Ordinal))
                        {
                            obj["question"] = tbQuestion.Text;
                            File.WriteAllText(file, obj.ToString(Newtonsoft.Json.Formatting.Indented));
                            var pair = questionData[selected];
                            questionData[selected] = (tbQuestion.Text, pair.answer);
                            break;
                        }
                    }
                    catch { }
                }
            }
            catch { }
        }

        private void TbAnswer_TextChanged(object? sender, EventArgs e)
        {
            if (_suppressAnswerChange) return;
            _answerSaveTimer?.Stop();
            _answerSaveTimer?.Start();
        }

        private void AnswerSaveTimer_Tick(object? sender, EventArgs e)
        {
            _answerSaveTimer?.Stop();
            try
            {
                if (listQuestions.SelectedItems.Count == 0) return;
                var selected = listQuestions.SelectedItems[0].Text;
                if (!questionData.ContainsKey(selected)) return;
                var qFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "questions");
                var files = Directory.GetFiles(qFolder, "*.json");
                foreach (var file in files)
                {
                    try
                    {
                        var json = File.ReadAllText(file);
                        var obj = JObject.Parse(json);
                        var t = obj["title"]?.ToString();
                        if (string.Equals(t, selected, StringComparison.Ordinal))
                        {
                            obj["answer"] = tbAnswer.Text;
                            File.WriteAllText(file, obj.ToString(Newtonsoft.Json.Formatting.Indented));
                            var pair = questionData[selected];
                            questionData[selected] = (pair.question, tbAnswer.Text);
                            break;
                        }
                    }
                    catch { }
                }
            }
            catch { }
        }

        private void ListView1_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (listQuestions.SelectedItems.Count > 0)
            {
                var selected = listQuestions.SelectedItems[0].Text;
                if (questionData.ContainsKey(selected))
                {
                    var data = questionData[selected];
                    _suppressQuestionChange = true;
                    tbQuestion.Text = data.question;
                    _suppressQuestionChange = false;
                    _suppressAnswerChange = true;
                    tbAnswer.Text = data.answer;
                    _suppressAnswerChange = false;
                    RefreshModelAnswerForSelectedQuestion();
                    
                    try
                    {
                        var folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "questions");
                        var files = Directory.GetFiles(folder, "*.json");
                        JArray? filesArray = null;
                        foreach (var file in files)
                        {
                            try
                            {
                                var json = File.ReadAllText(file);
                                var obj = JObject.Parse(json);
                                var t = obj["title"]?.ToString();
                                if (string.Equals(t, selected, StringComparison.Ordinal))
                                {
                                    filesArray = obj["files"] as JArray;
                                    break;
                                }
                            }
                            catch { }
                        }

                        var listFilesCtrl3 = this.Controls.Find("listFiles", true).FirstOrDefault() as ListView;
                        if (listFilesCtrl3 != null)
                        {
                            listFilesCtrl3.BeginUpdate();
                            try
                            {
                                listFilesCtrl3.View = View.List;
                                listFilesCtrl3.Items.Clear();
                                if (filesArray != null)
                                {
                                    foreach (var item in filesArray)
                                    {
                                        var name = item?.ToString() ?? string.Empty;
                                        if (!string.IsNullOrWhiteSpace(name))
                                        {
                                            listFilesCtrl3.Items.Add(new ListViewItem(name));
                                        }
                                    }
                                }
                                btnDeleteFile.Enabled = false;
                            }
                            finally
                            {
                                listFilesCtrl3.EndUpdate();
                            }
                        }
                    }
                    catch { }

                    try
                    {
                        var folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "questions");
                        var files = Directory.GetFiles(folder, "*.json");
                        JArray? scoreArray = null;
                        foreach (var file in files)
                        {
                            try
                            {
                                var json = File.ReadAllText(file);
                                var obj = JObject.Parse(json);
                                var t = obj["title"]?.ToString();
                                if (string.Equals(t, selected, StringComparison.Ordinal))
                                {
                                    scoreArray = obj["score"] as JArray;
                                    break;
                                }
                            }
                            catch { }
                        }

                        var listScore = this.Controls.Find("listSocre", true).FirstOrDefault() as ListView;
                        if (listScore != null)
                        {
                            listScore.BeginUpdate();
                            try
                            {
                                listScore.View = View.Details;
                                listScore.FullRowSelect = true;
                                if (listScore.Columns.Count < 3)
                                {
                                    listScore.Columns.Clear();
                                    listScore.Columns.Add("打分模型名称", 220);
                                    listScore.Columns.Add("作答模型名称", 220);
                                    listScore.Columns.Add("分数", 120);
                                }
                                listScore.Items.Clear();
                                if (scoreArray != null)
                                {
                                    foreach (var item in scoreArray.OfType<JObject>())
                                    {
                                        var scoreModel = item["scoreModelName"]?.ToString() ?? "";
                                        var model = item["modelName"]?.ToString() ?? (item["模型名"]?.ToString() ?? "");
                                        var score = item["socre"]?.ToString() ?? "";
                                        var lvi = new ListViewItem(scoreModel);
                                        lvi.SubItems.Add(model);
                                        lvi.SubItems.Add(score);
                                        lvi.Tag = item;
                                        listScore.Items.Add(lvi);
                                    }
                                }
                            }
                            finally
                            {
                                listScore.EndUpdate();
                            }
                        }
                    }
                    catch { }
                }
            }
        }

        private void RefreshModelAnswerForSelectedQuestion()
        {
            try
            {
                if (listQuestions.SelectedItems.Count == 0) return;
                var selectedTitle = listQuestions.SelectedItems[0].Text;
                var listModelsCtrl = this.Controls.Find("listModels", true).FirstOrDefault() as ListView;
                var outBox = this.Controls.Find("tbAiAnswerBox", true).FirstOrDefault() as TextBox;
                if (outBox == null) return;
                if (listModelsCtrl == null || listModelsCtrl.SelectedItems.Count == 0)
                {
                    outBox.Text = "请选择一个模型来查看它的回答";
                    return;
                }
                var modelName = listModelsCtrl.SelectedItems[0].Text ?? string.Empty;

                var folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "questions");
                var files = Directory.GetFiles(folder, "*.json");
                string content = string.Empty;
                foreach (var file in files)
                {
                    try
                    {
                        var json = File.ReadAllText(file);
                        var obj = JObject.Parse(json);
                        var t = obj["title"]?.ToString();
                        if (string.Equals(t, selectedTitle, StringComparison.Ordinal))
                        {
                            var answers = obj["aiAnswers"] as JObject;
                            if (answers != null && !string.IsNullOrWhiteSpace(modelName))
                            {
                                content = answers[modelName]?.ToString() ?? string.Empty;
                            }
                            break;
                        }
                    }
                    catch { }
                }
                outBox.Text = content;
            }
            catch { }
        }

        private void ListFiles_SelectedIndexChanged(object? sender, EventArgs e)
        {
            btnDeleteFile.Enabled = listFiles.SelectedItems.Count > 0;
        }

        private void BtnDeleteFile_Click(object? sender, EventArgs e)
        {
            try
            {
                if (listQuestions.SelectedItems.Count == 0) return;
                var title = listQuestions.SelectedItems[0].Text;
                if (listFiles.SelectedItems.Count == 0) return;
                var name = listFiles.SelectedItems[0].Text;
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "files", name);
                try { if (File.Exists(path)) File.Delete(path); } catch { }

                var qFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "questions");
                var files = Directory.GetFiles(qFolder, "*.json");
                foreach (var file in files)
                {
                    try
                    {
                        var json = File.ReadAllText(file);
                        var obj = JObject.Parse(json);
                        var t = obj["title"]?.ToString();
                        if (string.Equals(t, title, StringComparison.Ordinal))
                        {
                            var arr = obj["files"] as JArray ?? new JArray();
                            for (int i = arr.Count - 1; i >= 0; i--)
                            {
                                if (string.Equals(arr[i]?.ToString() ?? string.Empty, name, StringComparison.Ordinal))
                                {
                                    arr.RemoveAt(i);
                                }
                            }
                            obj["files"] = arr;
                            File.WriteAllText(file, obj.ToString(Newtonsoft.Json.Formatting.Indented));
                            break;
                        }
                    }
                    catch { }
                }

                foreach (ListViewItem it in listFiles.Items)
                {
                    if (string.Equals(it.Text, name, StringComparison.Ordinal))
                    {
                        listFiles.Items.Remove(it);
                        break;
                    }
                }
                btnDeleteFile.Enabled = false;
            }
            catch { btnDeleteFile.Enabled = false; }
        }

        private void BtnAddQuestion_Click(object? sender, EventArgs e)
        {
            using (var dialog = new AddQuestionDialog())
            {
                dialog.ShowDialog(this);
                if (dialog.DialogResult == DialogResult.OK)
                {
                    questionData[dialog.QuestionTitle] = (dialog.QuestionContent, dialog.AnswerContent);
                    listQuestions.Items.Clear();
                    foreach (var key in questionData.Keys)
                    {
                        listQuestions.Items.Add(new ListViewItem(key));
                    }
                    var found = listQuestions.Items.Cast<ListViewItem>().FirstOrDefault(i => i.Text == dialog.QuestionTitle);
                    if (found != null) found.Selected = true;
                }
            }
        }

        private void BtnSettings_Click(object? sender, EventArgs e)
        {
            using (var dialog = new ApiSettingsDialog())
            {
                dialog.ShowDialog(this);
                if (dialog.DialogResult == DialogResult.OK)
                {
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
                _apiClient = LlamaApiClient.CreateFromConfig();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"初始化API客户端失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _apiClient = new LlamaApiClient();
            }
        }

        

        private void BtnSubmitQuestion_Click(object? sender, EventArgs e)
        {
            if (listQuestions.SelectedItems.Count == 0)
            {
                MessageBox.Show("请先选择一个问题", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var selected = listQuestions.SelectedItems[0].Text;
            if (!questionData.ContainsKey(selected))
            {
                MessageBox.Show("未找到该问题内容", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var data = questionData[selected];
            using var dlg = new AnswerStreamDialog(selected, data.question);
            dlg.ShowDialog(this);
        }

        private void BtnShowAnswer_Click(object? sender, EventArgs e)
        {
            if (listQuestions.SelectedItems.Count == 0)
            {
                MessageBox.Show("请先选择一个问题", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var selected = listQuestions.SelectedItems[0].Text;
            if (!questionData.ContainsKey(selected))
            {
                MessageBox.Show("未找到该问题内容", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var data = questionData[selected];
            var listModelsCtrl = this.Controls.Find("listModels", true).FirstOrDefault() as ListView;
            if (listModelsCtrl == null || listModelsCtrl.SelectedItems.Count == 0)
            {
                MessageBox.Show("请先在模型列表中选择一个模型", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrWhiteSpace(tbAiAnswerBox.Text))
            {
                MessageBox.Show("当前没有可供打分的答案，请先生成或选择一个模型回答", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string aiAnswer = tbAiAnswerBox.Text;
            var modelName = listModelsCtrl?.SelectedItems[0]?.Text ?? string.Empty;
            var dlg = new ScoreRequestDialog(selected, data.question, data.answer, aiAnswer, modelName);
            if (!string.IsNullOrWhiteSpace(modelName)) dlg.Text = $"打分请求（模型：{modelName}）";
            dlg.Show(this);
        }

        private void BtnDeleteQuestion_Click(object? sender, EventArgs e)
        {
            try
            {
                if (listQuestions.SelectedItems.Count == 0) return;
                var title = listQuestions.SelectedItems[0].Text;

                var qFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "questions");
                var files = Directory.GetFiles(qFolder, "*.json");
                foreach (var file in files)
                {
                    try
                    {
                        var json = File.ReadAllText(file);
                        var obj = JObject.Parse(json);
                        var t = obj["title"]?.ToString();
                        if (string.Equals(t, title, StringComparison.Ordinal))
                        {
                            var arr = obj["files"] as JArray;
                            if (arr != null)
                            {
                                foreach (var item in arr)
                                {
                                    var name = item?.ToString() ?? string.Empty;
                                    if (!string.IsNullOrWhiteSpace(name))
                                    {
                                        var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "files", name);
                                        try { if (File.Exists(path)) File.Delete(path); } catch { }
                                    }
                                }
                            }
                            try { File.Delete(file); } catch { }
                            break;
                        }
                    }
                    catch { }
                }

                if (questionData.ContainsKey(title)) questionData.Remove(title);

                listQuestions.Items.Clear();
                foreach (var key in questionData.Keys)
                {
                    listQuestions.Items.Add(new ListViewItem(key));
                }

                var listFilesCtrl = this.Controls.Find("listFiles", true).FirstOrDefault() as ListView;
                if (listFilesCtrl != null)
                {
                    listFilesCtrl.Items.Clear();
                }
                var listScoreCtrl = this.Controls.Find("listSocre", true).FirstOrDefault() as ListView;
                if (listScoreCtrl != null)
                {
                    listScoreCtrl.Items.Clear();
                }
                tbQuestion.Clear();
                tbAnswer.Clear();
                tbAiAnswerBox.Clear();
                btnDeleteFile.Enabled = false;

                if (listQuestions.Items.Count > 0)
                {
                    listQuestions.Items[0].Selected = true;
                }
            }
            catch { }
        }

        private async void BtnAuto_Click(object? sender, EventArgs e)
        {
            try
            {
                var items = listQuestions.Items.Cast<ListViewItem>()
                    .Select(it => it.Text)
                    .Where(t => questionData.ContainsKey(t))
                    .Select(t => (t, questionData[t].question, questionData[t].answer))
                    .ToList();
                if (items.Count == 0)
                {
                    MessageBox.Show("没有可处理的问题", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using var dlg = new AutoAnswerDialog();
                var service = new AutoAnswerService();
                service.OnProgress += (cur, total, title) => dlg.SetStatus(cur, total, title);
                service.OnLog += (text) => dlg.AppendLog(text);
                dlg.OnCancel += () => service.Cancel();

                var task = service.RunAsync(items);
                var result = dlg.ShowDialog(this);
                await task;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"自动答题失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnViewEvaluation_Click(object? sender, EventArgs e)
        {
            try
            {
                var listScore = this.Controls.Find("listSocre", true).FirstOrDefault() as ListView;
                if (listScore == null || listScore.SelectedItems.Count == 0)
                {
                    MessageBox.Show("请先选择一个分数行", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                var obj = listScore.SelectedItems[0].Tag as JObject;
                var eval = obj?["evaluation"]?.ToString() ?? string.Empty;
                using var dlg = new EvaluationDialog(eval);
                dlg.ShowDialog(this);
            }
            catch { }
        }
        
    }
}
