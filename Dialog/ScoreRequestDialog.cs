using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using LlamaWorker;
using System.Globalization;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace AITest
{
    public partial class ScoreRequestDialog : Form
    {
        private readonly string _title;
        private readonly string _question;
        private readonly string _answer;
        private readonly string _aiAnswer;
        private readonly string _modelName = string.Empty;
        private readonly List<ScoreApiSettings> _apis = new List<ScoreApiSettings>();
        private RichTextStreamAppender? _streamAppender;

        public ScoreRequestDialog(string title, string question, string answer, string aiAnswer, string modelName = "")
        {
            InitializeComponent();
            _title = title ?? string.Empty;
            _question = question ?? string.Empty;
            _answer = answer ?? string.Empty;
            _aiAnswer = aiAnswer ?? string.Empty;
            _modelName = modelName ?? string.Empty;
            LoadApis();
            if (cmbApi.Items.Count > 0) cmbApi.SelectedIndex = 0;
            tbAiAnswer.Text = _aiAnswer;
            _streamAppender = new RichTextStreamAppender(rtbStream);
        }

        private void LoadApis()
        {
            try
            {
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "score_api_settings.json");
                if (File.Exists(path))
                {
                    var json = File.ReadAllText(path);
                    var list = JsonConvert.DeserializeObject<List<ScoreApiSettings>>(json);
                    if (list != null)
                    {
                        _apis.Clear();
                        _apis.AddRange(list);
                        cmbApi.Items.Clear();
                        foreach (var item in _apis.Select((x, i) => (x, i)))
                        {
                            cmbApi.Items.Add($"API {item.i + 1}: {item.x.ApiBaseUrl}");
                        }
                        cmbApi.Items.Insert(0, "人工评分");
                    }
                }
                else
                {
                    cmbApi.Items.Clear();
                    cmbApi.Items.Add("人工评分");
                }
            }
            catch { }
        }

        private async void btnStart_Click(object? sender, EventArgs e)
        {
            var sel = cmbApi.SelectedIndex;
            if (sel == 0)
            {
                rtbStream.Clear();
                rtbStream.Text = "人工评分模式：请在此输入评价内容，然后使用下方保存分数按钮保存。";
                return;
            }
            if (sel < 0)
            {
                MessageBox.Show("请先选择一个打分API", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var apiIndex = sel - 1;
            if (apiIndex < 0 || apiIndex >= _apis.Count)
            {
                MessageBox.Show("请先选择一个打分API", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var s = _apis[apiIndex];
            var systemPrompt = string.IsNullOrWhiteSpace(s.SystemPrompt) ? "" : s.SystemPrompt;
            var userPrompt = $"----问题：----{Environment.NewLine}{_question}{Environment.NewLine}----正确答案：----{Environment.NewLine}{_answer}{Environment.NewLine}----AI模型答案：----{_aiAnswer}";

            Debug.WriteLine(userPrompt.Length);

            rtbStream.Clear();
            btnStart.Enabled = false;

            try
            {
                using var client = new LlamaApiClient(s.ApiBaseUrl, s.ApiKey);
                await client.SendStreamChatRequestAsync(
                    systemPrompt,
                    userPrompt,
                    chunk =>
                    {
                        _streamAppender?.Append(chunk);
                    },
                    s.Model,
                    s.Temperature,
                    s.MaxTokens,
                    s.TopP
                );
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                rtbStream.Text = $"打分请求出错: {ex.Message}";
            }
            finally
            {
                btnStart.Enabled = true;
            }
        }

        private void tbSocre_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;
            var ch = e.KeyChar;
            if (char.IsDigit(ch))
            {
                var text = tbSocre.Text;
                var selStart = tbSocre.SelectionStart;
                var selLen = tbSocre.SelectionLength;
                var prospective = text.Remove(selStart, selLen).Insert(selStart, ch.ToString());
                if (double.TryParse(prospective, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out var val))
                {
                    if (val > 100) { e.Handled = true; return; }
                }
                return;
            }
            if (ch == '.')
            {
                if (tbSocre.Text.Contains('.')) { e.Handled = true; return; }
                return;
            }
            e.Handled = true;
        }

        private void btnSaveSocre_Click(object? sender, EventArgs e)
        {
            try
            {
                double? scoreFound = null;
                var raw = tbSocre.Text?.Trim() ?? string.Empty;
                if (double.TryParse(raw, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out var direct))
                {
                    if (direct < 0) direct = 0;
                    if (direct > 100) direct = 100;
                    scoreFound = direct;
                }
                else
                {
                    var lines = rtbStream.Text.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
                    var regex = new Regex("^\\s*\\d+(\\.\\d+)?\\s*$");
                    foreach (var line in lines)
                    {
                        if (regex.IsMatch(line))
                        {
                            if (double.TryParse(line.Trim(), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out var v))
                            {
                                if (v < 0) v = 0;
                                if (v > 100) v = 100;
                                scoreFound = v;
                                break;
                            }
                        }
                    }
                }
                if (!scoreFound.HasValue)
                {
                    MessageBox.Show("未在输出中找到纯数字分数", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                tbSocre.Text = scoreFound.Value.ToString(CultureInfo.InvariantCulture);

                var sel = cmbApi.SelectedIndex;
                if (sel == 0)
                {
                    var modelNameManual = "人工评分";
                    SaveScoreEntry(_modelName, modelNameManual, scoreFound.Value, rtbStream.Text);
                    return;
                }
                if (sel < 0)
                {
                    MessageBox.Show("请先选择一个打分API", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                var apiIndex = sel - 1;
                if (apiIndex < 0 || apiIndex >= _apis.Count)
                {
                    MessageBox.Show("请先选择一个打分API", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                var api = _apis[apiIndex];
                var targetModel = !string.IsNullOrWhiteSpace(_modelName)
                    ? _modelName
                    : (string.IsNullOrWhiteSpace(api.Model) ? "" : api.Model);
                SaveScoreEntry(_modelName, targetModel, scoreFound.Value, rtbStream.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存分数时出错: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 保存打分结果
        /// </summary>
        /// <param name="modelName">模型名称</param>
        /// <param name="scoreModelName">打分模型名称</param>
        /// <param name="score">打分结果</param>
        /// <param name="evaluation">评估结果</param>
        private void SaveScoreEntry(string modelName, string scoreModelName, double score, string evaluation)
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
                        JArray scoreArray;
                        var existingScore = obj["score"];
                        if (existingScore is JArray arr)
                        {
                            scoreArray = arr;
                        }
                        else
                        {
                            scoreArray = new JArray();
                        }

                        bool found = false;
                        for (int i = scoreArray.Count - 1; i >= 0; i--)
                        {
                            var itemObj = scoreArray[i] as JObject;
                            var smn = itemObj?["scoreModelName"]?.ToString();
                            if (string.Equals(smn, scoreModelName, StringComparison.Ordinal))
                            {
                                if (!found && itemObj != null)
                                {
                                    itemObj["modelName"] = modelName;
                                    itemObj["socre"] = score;
                                    itemObj["evaluation"] = evaluation;
                                    found = true;
                                }
                                else
                                {
                                    scoreArray.RemoveAt(i);
                                }
                            }
                        }
                        if (!found)
                        {
                            var newEntry = new JObject
                            {
                                ["scoreModelName"] = scoreModelName,
                                ["modelName"] = modelName,
                                ["socre"] = score,
                                ["evaluation"] = evaluation
                            };
                            scoreArray.Add(newEntry);
                        }
                        obj["score"] = scoreArray;
                        File.WriteAllText(file, obj.ToString(Newtonsoft.Json.Formatting.Indented));
                        saved = true;
                        break;
                    }
                }
                catch { }
            }
            if (saved)
            {
                MessageBox.Show("分数与评价已保存", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("未找到当前问题文件，保存失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

