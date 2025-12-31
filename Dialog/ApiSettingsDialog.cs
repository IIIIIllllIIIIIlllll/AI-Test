using System;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Linq;
using AITest.DataStruct;
using System.Diagnostics;

namespace AITest
{

    public partial class ApiSettingsDialog : Form
    {

        public ApiSettingsDialog()
        {
            InitializeComponent();
            // 自定义的初始化
            this.Init();
            LoadSettings();
        }


        private void Init()
        {
            numMaxTokens.Maximum = int.MaxValue;
            btnDeleteModel.Click += btnDeleteModel_Click;
            listModels.SelectedIndexChanged += (s, e) =>
            {
                bool selected = listModels.SelectedItems.Count > 0;
                btnDeleteModel.Enabled = selected;
                // 当选择模型时，启用模型配置面板
                if (selected)
                {
                    EnableModelPanel();
                }
                else
                {
                    DisableModelPanel();
                }
            };

            // 添加API配置相关事件处理
            btnAddApi.Click += btnAddApi_Click;
            btnDeleteApi.Click += btnDeleteConfig_Click;
            listApi.SelectedIndexChanged += (s, e) =>
            {
                bool selected = listApi.SelectedItems.Count > 0;
                btnDeleteModel.Enabled = selected;
                if (selected)
                {
                    EnableConfigPanel();
                    LoadSelectedApiConfig();
                }
                else
                {
                    DisableConfigPanel();
                    DisableModelPanel();
                }
            };
            // 给文本框添加事件
            txtBaseUrl.TextChanged += (sender, e) =>
            {
                if(this._selectedConfig != null)
                {
                    this._selectedConfig.ApiBaseUrl = txtBaseUrl.Text;
                }
            };

            txtApiKey.TabIndexChanged += (sender, e) =>
            {
                if (this._selectedConfig != null)
                {
                    this._selectedConfig.ApiKey = txtBaseUrl.Text;
                }
            };
        }


        private void LoadSettings()
        {
            // 默认先禁用所有的组件
            this.DisableConfigPanel();
            this.DisableModelPanel();
            try
            {
                // 从JSON配置文件加载设置
                if (File.Exists(ConfigFilePath))
                {
                    var json = File.ReadAllText(ConfigFilePath);
                    var apiConfigs = JsonConvert.DeserializeObject<List<ApiConfig>>(json);

                    if (apiConfigs != null)
                    {
                        // 加载API配置列表
                        if (apiConfigs.Count > 0)
                        {
                            _apiConfigs.Clear();
                            listApi.Items.Clear();
                            var maxNumber = 0;
                            foreach (var config in apiConfigs)
                            {
                                _apiConfigs.Add(config);
                                listApi.Items.Add(new ListViewItem(config.Name));
                                var match = Regex.Match(config.Name, @"自定义配置(\d+)");
                                if (match.Success && int.TryParse(match.Groups[1].Value, out int number))
                                {
                                    maxNumber = Math.Max(maxNumber, number);
                                }
                            }
                            _configCounter = maxNumber + 1;
                        }

                        // 如果有配置，默认选中第一个
                        if (listApi.Items.Count > 0)
                        {
                            listApi.Items[0].Selected = true;
                        }
                    }
                }
                else
                {
                    // 创建一个默认配置
                    var defaultConfig = new ApiConfig();

                    _apiConfigs.Add(defaultConfig);
                    listApi.Items.Add(new ListViewItem(defaultConfig.Name));
                    listApi.Items[0].Selected = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载设置时出错: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // 创建一个默认配置
                var defaultConfig = new ApiConfig
                {
                    Name = "默认配置",
                    ApiBaseUrl = ApiBaseUrl,
                    ApiKey = ApiKey
                };

                _apiConfigs.Add(defaultConfig);
                listApi.Items.Add(new ListViewItem(defaultConfig.Name));
                listApi.Items[0].Selected = true;
            }
        }



        private void DisableConfigPanel()
        {
            _selectedConfig = null;
            txtBaseUrl.Enabled = false;
            txtApiKey.Enabled = false;
            cmbModel.Enabled = false;
            btnAddModel.Enabled = false;
            btnTestConnection.Enabled = false;
        }

        private void EnableConfigPanel()
        {
            txtBaseUrl.Enabled = true;
            txtApiKey.Enabled = true;
            cmbModel.Enabled = true;
            btnAddModel.Enabled = true;
            btnTestConnection.Enabled = true;
        }


        private void DisableModelPanel()
        {
            numTemperature.Enabled = false;
            numMaxTokens.Enabled = false;
            numTopP.Enabled = false;
            txtSystemPrompt.Enabled = false;
        }

        private void EnableModelPanel()
        {
            numTemperature.Enabled = true;
            numMaxTokens.Enabled = true;
            numTopP.Enabled = true;
            txtSystemPrompt.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
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
                var json = JsonConvert.SerializeObject(this._apiConfigs, Formatting.Indented);
                File.WriteAllText(ConfigFilePath, json);

                Debug.WriteLine("11111111111111111 " + json);
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
                            MessageBox.Show($"连接成功，已加载{models.Count}个模型", "测试结果", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
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

        private void btnAddModel_Click(object? sender, EventArgs e)
        {
            var m = cmbModel.Text.Trim();
            if (string.IsNullOrWhiteSpace(m))
            {
                MessageBox.Show("请先选择一个模型", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // 找到选中的配置项
            if (_selectedConfig == null)
                return;
            // 去重
            foreach(ModelInfo info in _selectedConfig.Models)
            {
                if (info.Model.Equals(m))
                    return;
            }
            ModelInfo modelInfo = new ModelInfo();
            modelInfo.Model = m;
            modelInfo.Api = _selectedConfig.ApiBaseUrl;

            _selectedConfig.Models.Add(modelInfo);
            listModels.Items.Add(new ListViewItem(m));
        }

        private void btnDeleteModel_Click(object? sender, EventArgs e)
        {
            try
            {
                if (listModels.SelectedItems.Count == 0) return;
                if (this._selectedConfig == null) return;

                var toRemove = listModels.SelectedItems[0].Text;

                _selectedConfig.RmoveModel(toRemove);

                foreach (ListViewItem it in listModels.SelectedItems)
                {
                    listModels.Items.Remove(it);
                }

                UpdateConfigFile();
            }
            catch (Exception ex)
            {
                // no prompt
            }
        }

        // 添加API配置
        private void btnAddApi_Click(object sender, EventArgs e)
        {
            try
            {
                var configName = $"自定义配置{_configCounter++}";
                var newConfig = new ApiConfig ();

                _apiConfigs.Add(newConfig);
                listApi.Items.Add(new ListViewItem(configName));

                // 如果是第一个配置，自动选中它
                if (listApi.Items.Count == 1)
                {
                    listApi.Items[0].Selected = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"添加配置失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 删除API配置
        private void btnDeleteConfig_Click(object sender, EventArgs e)
        {
            try
            {
                if (listApi.SelectedItems.Count == 0) return;

                var selectedItems = listApi.SelectedItems.Cast<ListViewItem>().ToList();
                var toRemoveNames = selectedItems.Select(i => i.Text).ToList();

                foreach (var name in toRemoveNames)
                {
                    var config = _apiConfigs.FirstOrDefault(c => c.Name == name);
                    if (config != null)
                    {
                        _apiConfigs.Remove(config);
                    }
                }

                foreach (var item in selectedItems)
                {
                    listApi.Items.Remove(item);
                }

                // 如果删除后没有配置了，禁用配置面板
                if (listApi.Items.Count == 0)
                {
                    DisableConfigPanel();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"删除配置失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 加载选中的API配置
        private void LoadSelectedApiConfig()
        {
            try
            {
                if (listApi.SelectedItems.Count == 0) return;

                var selectedItem = listApi.SelectedItems[0];
                var configName = selectedItem.Text;
                var config = _apiConfigs.FirstOrDefault(c => c.Name == configName);

                if (config != null)
                {
                    _selectedConfig = config;
                    txtBaseUrl.Text = config.ApiBaseUrl;
                    txtApiKey.Text = config.ApiKey;

                    // 加载该配置的模型列表
                    listModels.Items.Clear();
                    if (config.Models != null && config.Models.Count > 0)
                    {
                        foreach (var model in config.Models)
                        {
                            listModels.Items.Add(new ListViewItem(model.Model));
                        }
                    }
                }
                else
                {
                    _selectedConfig = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载配置失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static readonly string ConfigFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "api_settings.json");
        private readonly List<ApiConfig> _apiConfigs = new List<ApiConfig>();


        private ApiConfig? _selectedConfig;


        private int _configCounter = 1;
        public string ApiBaseUrl { get; private set; } = "http://127.0.0.1:8080";
        public string ApiKey { get; private set; } = "";
        public double Temperature { get; private set; } = 0.7;
        public int MaxTokens { get; private set; } = 4096;
        public double TopP { get; private set; } = 0.9;
        public string SystemPrompt { get; private set; } = "你是一个专业的AI助手，擅长回答各种学科的问题。请提供准确、详细且易于理解的答案。";
    }
}
