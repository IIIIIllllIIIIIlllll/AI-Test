using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace AITest
{
    public partial class ScoreApiSettingsDialog : Form
    {
        private const string ConfigFileName = "score_api_settings.json";
        private readonly string _configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigFileName);
        private readonly List<ScoreApiSettings> _items = new List<ScoreApiSettings>();

        public ScoreApiSettingsDialog()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void LoadSettings()
        {
            try
            {
                if (File.Exists(_configPath))
                {
                    var json = File.ReadAllText(_configPath);
                    var list = JsonConvert.DeserializeObject<List<ScoreApiSettings>>(json);
                    if (list != null)
                    {
                        _items.Clear();
                        // 兼容旧文件，确保Models非空
                        foreach (var s in list)
                        {
                            if (s.Models == null) s.Models = new List<string>();
                        }
                        _items.AddRange(list);
                    }
                }
            }
            catch { }

            RefreshListBox();
            if (_items.Count > 0)
            {
                lstApis.SelectedIndex = 0;
            }
        }

        private void RefreshListBox()
        {
            lstApis.Items.Clear();
            foreach (var item in _items.Select((x, i) => (x, i)))
            {
                lstApis.Items.Add($"API {item.i + 1}: {item.x.ApiBaseUrl}");
            }
        }

        private void FillFields(ScoreApiSettings s)
        {
            txtBaseUrl.Text = s.ApiBaseUrl;
            txtApiKey.Text = s.ApiKey;
            cmbModel.Text = s.Model;
            lblSelectedModelValue.Text = string.IsNullOrWhiteSpace(s.Model) ? "未选择" : s.Model;
            numTemperature.Value = (decimal)s.Temperature;
            numMaxTokens.Value = s.MaxTokens;
            numTopP.Value = (decimal)s.TopP;
            txtSystemPrompt.Text = string.IsNullOrWhiteSpace(s.SystemPrompt) ? DefaultSystemPrompt : s.SystemPrompt;
        }

        private ScoreApiSettings CollectFields()
        {
            return new ScoreApiSettings
            {
                ApiBaseUrl = txtBaseUrl.Text.Trim(),
                ApiKey = txtApiKey.Text.Trim(),
                Model = cmbModel.Text.Trim(),
                Temperature = (double)numTemperature.Value,
                MaxTokens = (int)numMaxTokens.Value,
                TopP = (double)numTopP.Value,
                SystemPrompt = txtSystemPrompt.Text
            };
        }

        private void lstApis_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (lstApis.SelectedIndex >= 0 && lstApis.SelectedIndex < _items.Count)
            {
                FillFields(_items[lstApis.SelectedIndex]);
                // 同步展示已保存的模型列表到下拉框（不改变选中模型）
                var s = _items[lstApis.SelectedIndex];
                cmbModel.Items.Clear();
                if (s.Models != null && s.Models.Count > 0)
                {
                    cmbModel.Items.AddRange(s.Models.ToArray());
                }
            }
        }

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            var s = new ScoreApiSettings
            {
                ApiBaseUrl = "http://127.0.0.1:8080",
                ApiKey = "",
                Model = "",
                Temperature = 0.7,
                MaxTokens = 4096,
                TopP = 0.9,
                SystemPrompt = DefaultSystemPrompt
            };
            _items.Add(s);
            RefreshListBox();
            lstApis.SelectedIndex = _items.Count - 1;
        }

        private void btnRemove_Click(object? sender, EventArgs e)
        {
            if (lstApis.SelectedIndex >= 0 && lstApis.SelectedIndex < _items.Count)
            {
                _items.RemoveAt(lstApis.SelectedIndex);
                RefreshListBox();
                if (_items.Count > 0) lstApis.SelectedIndex = 0;
                else ClearFields();
            }
        }

        private void ClearFields()
        {
            txtBaseUrl.Text = "";
            txtApiKey.Text = "";
            cmbModel.Items.Clear();
            cmbModel.Text = "";
            lblSelectedModelValue.Text = "未选择";
            numTemperature.Value = 0.7M;
            numMaxTokens.Value = 4096;
            numTopP.Value = 0.9M;
            txtSystemPrompt.Text = DefaultSystemPrompt;
        }

        private async void btnTestConnection_Click(object? sender, EventArgs e)
        {
            btnTestConnection.Enabled = false;
            btnTestConnection.Text = "测试中...";
            try
            {
                var baseUrl = txtBaseUrl.Text.Trim();
                var apiKey = txtApiKey.Text.Trim();
                var currentSettings = CollectFields();
                int index = lstApis.SelectedIndex;
                if (index < 0 || index >= _items.Count)
                {
                    if (_items.Count == 0)
                    {
                        _items.Add(currentSettings);
                        index = 0;
                    }
                    else
                    {
                        _items[0] = currentSettings;
                        index = 0;
                    }
                }
                using (var client = new LlamaWorker.LlamaApiClient(baseUrl, apiKey))
                {
                    var ok = await client.TestConnectionAsync();
                    if (ok)
                    {
                        var trimmed = baseUrl.TrimEnd('/');
                        var match = Regex.Match(trimmed, @"/v\d+$");
                        var modelsUrl = match.Success ? $"{trimmed}/models" : $"{trimmed}/v1/models";
                        var models = await client.GetModelsAsync(modelsUrl);
                        cmbModel.Items.Clear();
                        if (models != null && models.Count > 0)
                        {
                            cmbModel.Items.AddRange(models.ToArray());
                            if (cmbModel.SelectedIndex < 0) cmbModel.SelectedIndex = 0;
                            lblSelectedModelValue.Text = cmbModel.SelectedItem?.ToString() ?? (string.IsNullOrWhiteSpace(cmbModel.Text) ? "未选择" : cmbModel.Text);
                            _items[index].Models.Clear();
                            _items[index].Models.AddRange(models);
                            var json = JsonConvert.SerializeObject(_items, Formatting.Indented);
                            File.WriteAllText(_configPath, json, Encoding.UTF8);
                            MessageBox.Show($"连接成功，已加载{models.Count}个模型", "测试结果", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            lblSelectedModelValue.Text = string.IsNullOrWhiteSpace(cmbModel.Text) ? "未选择" : cmbModel.Text;
                            _items[index].Models.Clear();
                            var json = JsonConvert.SerializeObject(_items, Formatting.Indented);
                            File.WriteAllText(_configPath, json, Encoding.UTF8);
                            MessageBox.Show("连接成功，但未返回任何模型", "测试结果", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("连接失败，请检查URL和API密钥", "测试结果", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"连接测试失败: {ex.Message}", "测试结果", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnTestConnection.Enabled = true;
                btnTestConnection.Text = "测试连接";
            }
        }

        private void btnSave_Click(object? sender, EventArgs e)
        {
            var current = CollectFields();
            var ignoreModel = cmbModel.Items.Count == 0 || cmbModel.SelectedIndex < 0 || string.IsNullOrWhiteSpace(cmbModel.Text);
            if (lstApis.SelectedIndex >= 0 && lstApis.SelectedIndex < _items.Count)
            {
                var existing = _items[lstApis.SelectedIndex];
                var existingModels = existing.Models ?? new List<string>();
                current.Models = new List<string>(existingModels);
                if (ignoreModel) current.Model = existing.Model;
                _items[lstApis.SelectedIndex] = current;
            }
            else
            {
                if (_items.Count == 0)
                {
                    _items.Add(current);
                }
                else
                {
                    var existing = _items[0];
                    var existingModels = existing.Models ?? new List<string>();
                    current.Models = new List<string>(existingModels);
                    if (ignoreModel) current.Model = existing.Model;
                    _items[0] = current;
                }
            }
            try
            {
                var json = JsonConvert.SerializeObject(_items, Formatting.Indented);
                File.WriteAllText(_configPath, json, Encoding.UTF8);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存设置失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private const string DefaultSystemPrompt = "你现在是一个AI模型评价员，用户会提供问题+标准答案，然后会加上AI模型回复的答案，你需要按照100分制给回复进行打分，并且简评回复的优劣。注意，标准答案绝对准确，不用验证题目和标准答案是否有误。";

        private void splitContainerMain_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void groupBoxConfig_Enter(object sender, EventArgs e)
        {

        }
    }

    public class ScoreApiSettings
    {
        public string ApiBaseUrl { get; set; } = "http://127.0.0.1:8080";
        public string ApiKey { get; set; } = "";
        public string Model { get; set; } = "";
        public double Temperature { get; set; } = 0.7;
        public int MaxTokens { get; set; } = 4096;
        public double TopP { get; set; } = 0.9;
        public string SystemPrompt { get; set; } = DefaultSystemPromptStatic;
        public List<string> Models { get; set; } = new List<string>();
        private const string DefaultSystemPromptStatic = "你现在是一个AI模型评价员，用户会提供问题+标准答案，然后会加上AI模型回复的答案，你需要按照100分制给回复进行打分，并且简评回复的优劣。注意，标准答案绝对准确，不用验证题目和标准答案是否有误。";
    }
}
