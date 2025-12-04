using System.Drawing;

namespace AITest
{
    partial class ScoreApiSettingsDialog
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            splitContainerMain = new SplitContainer();
            groupBoxList = new GroupBox();
            tableLayoutList = new TableLayoutPanel();
            lstApis = new ListBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnAdd = new Button();
            btnRemove = new Button();
            groupBoxConfig = new GroupBox();
            tableConfig = new TableLayoutPanel();
            txtBaseUrl = new TextBox();
            lblApiKey = new Label();
            txtApiKey = new TextBox();
            lblModel = new Label();
            cmbModel = new ComboBox();
            lblSelectedModelTitle = new Label();
            lblSelectedModelValue = new Label();
            btnTestConnection = new Button();
            lblTemperature = new Label();
            numTemperature = new NumericUpDown();
            lblMaxTokens = new Label();
            numMaxTokens = new NumericUpDown();
            lblTopP = new Label();
            numTopP = new NumericUpDown();
            lblSystemPrompt = new Label();
            txtSystemPrompt = new TextBox();
            lblBaseUrl = new Label();
            flowButtons = new FlowLayoutPanel();
            btnSave = new Button();
            btnCancel = new Button();
            panelButtons = new Panel();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            groupBoxList.SuspendLayout();
            tableLayoutList.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            groupBoxConfig.SuspendLayout();
            tableConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numTemperature).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMaxTokens).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numTopP).BeginInit();
            flowButtons.SuspendLayout();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainerMain
            // 
            splitContainerMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainerMain.FixedPanel = FixedPanel.Panel1;
            splitContainerMain.Location = new Point(0, 0);
            splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            splitContainerMain.Panel1.Controls.Add(groupBoxList);
            splitContainerMain.Panel1MinSize = 200;
            // 
            // splitContainerMain.Panel2
            // 
            splitContainerMain.Panel2.Controls.Add(groupBoxConfig);
            splitContainerMain.Size = new Size(778, 500);
            splitContainerMain.SplitterDistance = 200;
            splitContainerMain.TabIndex = 0;
            splitContainerMain.SplitterMoved += splitContainerMain_SplitterMoved;
            // 
            // groupBoxList
            // 
            groupBoxList.Controls.Add(tableLayoutList);
            groupBoxList.Dock = DockStyle.Fill;
            groupBoxList.Location = new Point(0, 0);
            groupBoxList.Name = "groupBoxList";
            groupBoxList.Size = new Size(200, 500);
            groupBoxList.TabIndex = 0;
            groupBoxList.TabStop = false;
            groupBoxList.Text = "打分API列表";
            // 
            // tableLayoutList
            // 
            tableLayoutList.ColumnCount = 1;
            tableLayoutList.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutList.Controls.Add(lstApis, 0, 0);
            tableLayoutList.Controls.Add(tableLayoutPanel1, 0, 1);
            tableLayoutList.Dock = DockStyle.Fill;
            tableLayoutList.Location = new Point(3, 26);
            tableLayoutList.Name = "tableLayoutList";
            tableLayoutList.RowCount = 2;
            tableLayoutList.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutList.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutList.Size = new Size(194, 471);
            tableLayoutList.TabIndex = 0;
            // 
            // lstApis
            // 
            lstApis.Dock = DockStyle.Fill;
            lstApis.ItemHeight = 24;
            lstApis.Location = new Point(3, 3);
            lstApis.Name = "lstApis";
            lstApis.Size = new Size(188, 425);
            lstApis.TabIndex = 0;
            lstApis.SelectedIndexChanged += lstApis_SelectedIndexChanged;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(btnAdd, 0, 0);
            tableLayoutPanel1.Controls.Add(btnRemove, 1, 0);
            tableLayoutPanel1.Location = new Point(3, 434);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(188, 34);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnAdd.Font = new Font("Microsoft YaHei UI", 8F);
            btnAdd.Location = new Point(3, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(88, 28);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "添加";
            btnAdd.Click += btnAdd_Click;
            // 
            // btnRemove
            // 
            btnRemove.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnRemove.Font = new Font("Microsoft YaHei UI", 8F);
            btnRemove.Location = new Point(97, 3);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(88, 28);
            btnRemove.TabIndex = 1;
            btnRemove.Text = "删除";
            btnRemove.Click += btnRemove_Click;
            // 
            // groupBoxConfig
            // 
            groupBoxConfig.Controls.Add(tableConfig);
            groupBoxConfig.Dock = DockStyle.Fill;
            groupBoxConfig.Location = new Point(0, 0);
            groupBoxConfig.Name = "groupBoxConfig";
            groupBoxConfig.Size = new Size(574, 500);
            groupBoxConfig.TabIndex = 0;
            groupBoxConfig.TabStop = false;
            groupBoxConfig.Text = "配置";
            groupBoxConfig.Enter += groupBoxConfig_Enter;
            // 
            // tableConfig
            // 
            tableConfig.ColumnCount = 2;
            tableConfig.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 128F));
            tableConfig.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableConfig.Controls.Add(txtBaseUrl, 1, 0);
            tableConfig.Controls.Add(lblApiKey, 0, 1);
            tableConfig.Controls.Add(txtApiKey, 1, 1);
            tableConfig.Controls.Add(lblModel, 0, 2);
            tableConfig.Controls.Add(cmbModel, 1, 2);
            tableConfig.Controls.Add(lblSelectedModelTitle, 0, 3);
            tableConfig.Controls.Add(lblSelectedModelValue, 1, 3);
            tableConfig.Controls.Add(btnTestConnection, 1, 4);
            tableConfig.Controls.Add(lblTemperature, 0, 5);
            tableConfig.Controls.Add(numTemperature, 1, 5);
            tableConfig.Controls.Add(lblMaxTokens, 0, 6);
            tableConfig.Controls.Add(numMaxTokens, 1, 6);
            tableConfig.Controls.Add(lblTopP, 0, 7);
            tableConfig.Controls.Add(numTopP, 1, 7);
            tableConfig.Controls.Add(lblSystemPrompt, 0, 8);
            tableConfig.Controls.Add(txtSystemPrompt, 1, 8);
            tableConfig.Controls.Add(lblBaseUrl, 0, 0);
            tableConfig.Dock = DockStyle.Fill;
            tableConfig.Location = new Point(3, 26);
            tableConfig.Name = "tableConfig";
            tableConfig.RowCount = 9;
            tableConfig.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableConfig.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableConfig.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableConfig.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableConfig.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableConfig.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableConfig.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableConfig.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableConfig.RowStyles.Add(new RowStyle());
            tableConfig.Size = new Size(568, 471);
            tableConfig.TabIndex = 0;
            // 
            // txtBaseUrl
            // 
            txtBaseUrl.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtBaseUrl.Location = new Point(131, 5);
            txtBaseUrl.Name = "txtBaseUrl";
            txtBaseUrl.Size = new Size(434, 30);
            txtBaseUrl.TabIndex = 1;
            // 
            // lblApiKey
            // 
            lblApiKey.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblApiKey.Location = new Point(3, 40);
            lblApiKey.Name = "lblApiKey";
            lblApiKey.Size = new Size(122, 40);
            lblApiKey.TabIndex = 2;
            lblApiKey.Text = "API密钥:";
            lblApiKey.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtApiKey
            // 
            txtApiKey.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtApiKey.Location = new Point(131, 45);
            txtApiKey.Name = "txtApiKey";
            txtApiKey.Size = new Size(434, 30);
            txtApiKey.TabIndex = 3;
            // 
            // lblModel
            // 
            lblModel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblModel.Location = new Point(3, 80);
            lblModel.Name = "lblModel";
            lblModel.Size = new Size(122, 40);
            lblModel.TabIndex = 4;
            lblModel.Text = "模型:";
            lblModel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cmbModel
            // 
            cmbModel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cmbModel.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbModel.Location = new Point(131, 84);
            cmbModel.Name = "cmbModel";
            cmbModel.Size = new Size(434, 32);
            cmbModel.TabIndex = 5;
            // 
            // lblSelectedModelTitle
            // 
            lblSelectedModelTitle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblSelectedModelTitle.Location = new Point(3, 120);
            lblSelectedModelTitle.Name = "lblSelectedModelTitle";
            lblSelectedModelTitle.Size = new Size(122, 40);
            lblSelectedModelTitle.TabIndex = 6;
            lblSelectedModelTitle.Text = "已选模型:";
            lblSelectedModelTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSelectedModelValue
            // 
            lblSelectedModelValue.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblSelectedModelValue.Location = new Point(131, 128);
            lblSelectedModelValue.Name = "lblSelectedModelValue";
            lblSelectedModelValue.Size = new Size(434, 23);
            lblSelectedModelValue.TabIndex = 7;
            lblSelectedModelValue.Text = "未选择";
            // 
            // btnTestConnection
            // 
            btnTestConnection.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnTestConnection.Location = new Point(131, 163);
            btnTestConnection.Name = "btnTestConnection";
            btnTestConnection.Size = new Size(434, 34);
            btnTestConnection.TabIndex = 8;
            btnTestConnection.Text = "测试连接";
            btnTestConnection.Click += btnTestConnection_Click;
            // 
            // lblTemperature
            // 
            lblTemperature.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblTemperature.Location = new Point(3, 200);
            lblTemperature.Name = "lblTemperature";
            lblTemperature.Size = new Size(122, 40);
            lblTemperature.TabIndex = 9;
            lblTemperature.Text = "温度参数:";
            lblTemperature.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // numTemperature
            // 
            numTemperature.Anchor = AnchorStyles.Left;
            numTemperature.DecimalPlaces = 1;
            numTemperature.Location = new Point(131, 205);
            numTemperature.Name = "numTemperature";
            numTemperature.Size = new Size(120, 30);
            numTemperature.TabIndex = 10;
            numTemperature.Value = new decimal(new int[] { 7, 0, 0, 65536 });
            // 
            // lblMaxTokens
            // 
            lblMaxTokens.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblMaxTokens.Location = new Point(3, 240);
            lblMaxTokens.Name = "lblMaxTokens";
            lblMaxTokens.Size = new Size(122, 40);
            lblMaxTokens.TabIndex = 11;
            lblMaxTokens.Text = "最大Token数:";
            lblMaxTokens.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // numMaxTokens
            // 
            numMaxTokens.Anchor = AnchorStyles.Left;
            numMaxTokens.Location = new Point(131, 245);
            numMaxTokens.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            numMaxTokens.Name = "numMaxTokens";
            numMaxTokens.Size = new Size(120, 30);
            numMaxTokens.TabIndex = 12;
            numMaxTokens.Value = new decimal(new int[] { 131072, 0, 0, 0 });
            // 
            // lblTopP
            // 
            lblTopP.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblTopP.Location = new Point(3, 280);
            lblTopP.Name = "lblTopP";
            lblTopP.Size = new Size(122, 40);
            lblTopP.TabIndex = 13;
            lblTopP.Text = "Top-P:";
            lblTopP.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // numTopP
            // 
            numTopP.Anchor = AnchorStyles.Left;
            numTopP.DecimalPlaces = 1;
            numTopP.Location = new Point(131, 285);
            numTopP.Name = "numTopP";
            numTopP.Size = new Size(120, 30);
            numTopP.TabIndex = 14;
            numTopP.Value = new decimal(new int[] { 9, 0, 0, 65536 });
            // 
            // lblSystemPrompt
            // 
            lblSystemPrompt.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblSystemPrompt.Location = new Point(3, 320);
            lblSystemPrompt.Name = "lblSystemPrompt";
            lblSystemPrompt.Size = new Size(122, 151);
            lblSystemPrompt.TabIndex = 15;
            lblSystemPrompt.Text = "系统提示:";
            lblSystemPrompt.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtSystemPrompt
            // 
            txtSystemPrompt.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtSystemPrompt.Location = new Point(131, 323);
            txtSystemPrompt.Multiline = true;
            txtSystemPrompt.Name = "txtSystemPrompt";
            txtSystemPrompt.ScrollBars = ScrollBars.Both;
            txtSystemPrompt.Size = new Size(434, 145);
            txtSystemPrompt.TabIndex = 16;
            // 
            // lblBaseUrl
            // 
            lblBaseUrl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblBaseUrl.Location = new Point(3, 0);
            lblBaseUrl.Name = "lblBaseUrl";
            lblBaseUrl.Size = new Size(122, 40);
            lblBaseUrl.TabIndex = 0;
            lblBaseUrl.Text = "API基础URL:";
            lblBaseUrl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flowButtons
            // 
            flowButtons.AutoSize = true;
            flowButtons.Controls.Add(btnSave);
            flowButtons.Controls.Add(btnCancel);
            flowButtons.Dock = DockStyle.Right;
            flowButtons.FlowDirection = FlowDirection.RightToLeft;
            flowButtons.Location = new Point(606, 0);
            flowButtons.Name = "flowButtons";
            flowButtons.Size = new Size(172, 44);
            flowButtons.TabIndex = 0;
            flowButtons.WrapContents = false;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(89, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(80, 38);
            btnSave.TabIndex = 0;
            btnSave.Text = "保存";
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(3, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(80, 38);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "取消";
            btnCancel.Click += btnCancel_Click;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(flowButtons);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(0, 500);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(778, 44);
            panelButtons.TabIndex = 1;
            // 
            // ScoreApiSettingsDialog
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(778, 544);
            Controls.Add(splitContainerMain);
            Controls.Add(panelButtons);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ScoreApiSettingsDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "设置打分模型API";
            splitContainerMain.Panel1.ResumeLayout(false);
            splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            groupBoxList.ResumeLayout(false);
            tableLayoutList.ResumeLayout(false);
            tableLayoutList.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            groupBoxConfig.ResumeLayout(false);
            tableConfig.ResumeLayout(false);
            tableConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numTemperature).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMaxTokens).EndInit();
            ((System.ComponentModel.ISupportInitialize)numTopP).EndInit();
            flowButtons.ResumeLayout(false);
            panelButtons.ResumeLayout(false);
            panelButtons.PerformLayout();
            ResumeLayout(false);
        }

        private SplitContainer splitContainerMain;
        private GroupBox groupBoxList;
        private TableLayoutPanel tableLayoutList;
        private ListBox lstApis;
        private Button btnAdd;
        private Button btnRemove;
        private GroupBox groupBoxConfig;
        private TableLayoutPanel tableConfig;
        private TextBox txtBaseUrl;
        private Label lblApiKey;
        private TextBox txtApiKey;
        private Label lblModel;
        private ComboBox cmbModel;
        private Label lblSelectedModelTitle;
        private Label lblSelectedModelValue;
        private Button btnTestConnection;
        private Label lblTemperature;
        private NumericUpDown numTemperature;
        private Label lblMaxTokens;
        private NumericUpDown numMaxTokens;
        private Label lblTopP;
        private NumericUpDown numTopP;
        private Label lblSystemPrompt;
        private TextBox txtSystemPrompt;
        private Label lblBaseUrl;
        private FlowLayoutPanel flowButtons;
        private Button btnSave;
        private Button btnCancel;
        private Panel panelButtons;
        private TableLayoutPanel tableLayoutPanel1;
    }
}
