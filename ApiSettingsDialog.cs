using System;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace AITest
{
    public partial class ApiSettingsDialog : Form
    {
        private static readonly string ConfigFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "api_settings.json");
        
        public string ApiBaseUrl { get; private set; } = "http://127.0.0.1:8080";
        public string ApiKey { get; private set; } = "";
        public string Model { get; private set; } = "";
        public double Temperature { get; private set; } = 0.7;
        public int MaxTokens { get; private set; } = 4096;
        public double TopP { get; private set; } = 0.9;
        public string SystemPrompt { get; private set; } = "你是一个专业的AI助手，擅长回答各种学科的问题。请提供准确、详细且易于理解的答案。";

        public ApiSettingsDialog()
        {
            InitializeComponent();
            numMaxTokens.Maximum = int.MaxValue;
            LoadSettings();
        }

        private void LoadSettings()
        {
            try
            {
                // 从JSON配置文件加载设置
                if (File.Exists(ConfigFilePath))
                {
                    var json = File.ReadAllText(ConfigFilePath);
                    var settings = JsonConvert.DeserializeObject<ApiSettings>(json);
                    
                    if (settings != null)
                    {
                        txtBaseUrl.Text = settings.ApiBaseUrl;
                        txtApiKey.Text = settings.ApiKey;
                        cmbModel.Text = settings.Model;
                        lblSelectedModelValue.Text = string.IsNullOrWhiteSpace(settings.Model) ? "未选择" : settings.Model;
                        numTemperature.Value = (decimal)settings.Temperature;
                        numMaxTokens.Value = settings.MaxTokens;
                        numTopP.Value = (decimal)settings.TopP;
                        txtSystemPrompt.Text = string.IsNullOrWhiteSpace(settings.SystemPrompt)
                            ? SystemPrompt
                            : settings.SystemPrompt;
                    }
                }
                else
                {
                    // 使用默认值
                    txtBaseUrl.Text = ApiBaseUrl;
                    txtApiKey.Text = ApiKey;
                    cmbModel.Text = Model;
                    lblSelectedModelValue.Text = string.IsNullOrWhiteSpace(Model) ? "未选择" : Model;
                    numTemperature.Value = (decimal)Temperature;
                    numMaxTokens.Value = MaxTokens;
                    numTopP.Value = (decimal)TopP;
                    txtSystemPrompt.Text = SystemPrompt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载设置时出错: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                // 使用默认值
                txtBaseUrl.Text = ApiBaseUrl;
                txtApiKey.Text = ApiKey;
                cmbModel.Text = Model;
                lblSelectedModelValue.Text = string.IsNullOrWhiteSpace(Model) ? "未选择" : Model;
                numTemperature.Value = (decimal)Temperature;
                numMaxTokens.Value = MaxTokens;
                numTopP.Value = (decimal)TopP;
                txtSystemPrompt.Text = SystemPrompt;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // 验证输入
                if (string.IsNullOrWhiteSpace(txtBaseUrl.Text))
                {
                    MessageBox.Show("API基础URL不能为空", "验证错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBaseUrl.Focus();
                    return;
                }

                // 保存设置
                ApiBaseUrl = txtBaseUrl.Text.Trim();
                ApiKey = txtApiKey.Text.Trim();
                Model = cmbModel.Text.Trim();
                lblSelectedModelValue.Text = string.IsNullOrWhiteSpace(Model) ? "未选择" : Model;
                Temperature = (double)numTemperature.Value;
                MaxTokens = (int)numMaxTokens.Value;
                TopP = (double)numTopP.Value;
                SystemPrompt = txtSystemPrompt.Text;

                // 更新配置文件
                UpdateConfigFile();

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存设置时出错: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateConfigFile()
        {
            try
            {
                var settings = new ApiSettings
                {
                    ApiBaseUrl = ApiBaseUrl,
                    ApiKey = ApiKey,
                    Model = Model,
                    Temperature = Temperature,
                    MaxTokens = MaxTokens,
                    TopP = TopP,
                    SystemPrompt = SystemPrompt
                };

                var json = JsonConvert.SerializeObject(settings, Formatting.Indented);
                File.WriteAllText(ConfigFilePath, json);
            }
            catch (Exception ex)
            {
                throw new Exception($"更新配置文件失败: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private async void btnTestConnection_Click(object sender, EventArgs e)
        {
            try
            {
                btnTestConnection.Enabled = false;
                btnTestConnection.Text = "测试中...";

                string baseUrl = txtBaseUrl.Text.Trim();
                string apiKey = txtApiKey.Text.Trim();

                using (var client = new LlamaWorker.LlamaApiClient(baseUrl, apiKey))
                {
                    var isConnected = await client.TestConnectionAsync();
                    if (isConnected)
                    {
                        var trimmed = baseUrl.TrimEnd('/');
                        var match = Regex.Match(trimmed, @"/v\d+$");
                        var modelsUrl = match.Success ? $"{trimmed}/models" : $"{trimmed}/v1/models";
                        var models = await client.GetModelsAsync(modelsUrl);
                        cmbModel.Items.Clear();
                        if (models != null && models.Count > 0)
                        {
                            cmbModel.Items.AddRange(models.ToArray());
                            if (!string.IsNullOrWhiteSpace(cmbModel.Text))
                            {
                                var index = cmbModel.Items.IndexOf(cmbModel.Text);
                                if (index >= 0) cmbModel.SelectedIndex = index;
                            }
                            if (cmbModel.SelectedIndex < 0) cmbModel.SelectedIndex = 0;
                            lblSelectedModelValue.Text = cmbModel.SelectedItem?.ToString() ?? (string.IsNullOrWhiteSpace(cmbModel.Text) ? "未选择" : cmbModel.Text);
                            MessageBox.Show($"连接成功，已加载{models.Count}个模型", "测试结果", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            lblSelectedModelValue.Text = string.IsNullOrWhiteSpace(cmbModel.Text) ? "未选择" : cmbModel.Text;
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
    }

    // 用于序列化的API设置类
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
