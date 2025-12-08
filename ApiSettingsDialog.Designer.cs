namespace AITest
{
    partial class ApiSettingsDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            grpConnection = new GroupBox();
            tableLayoutPanelConnection = new TableLayoutPanel();
            txtSystemPrompt = new TextBox();
            lblSystemPrompt = new Label();
            numTopP = new NumericUpDown();
            lblTopP = new Label();
            numMaxTokens = new NumericUpDown();
            lblMaxTokens = new Label();
            numTemperature = new NumericUpDown();
            lblTemperature = new Label();
            lblBaseUrl = new Label();
            txtBaseUrl = new TextBox();
            lblApiKey = new Label();
            txtApiKey = new TextBox();
            lblModel = new Label();
            cmbModel = new ComboBox();
            lblSelectedModelTitle = new Label();
            btnAddModel = new Button();
            btnTestConnection = new Button();
            grpParameters = new GroupBox();
            lstModels = new ListView();
            panelButtons = new Panel();
            btnSave = new Button();
            btnCancel = new Button();
            groupBox1 = new GroupBox();
            btnDeleteModel = new Button();
            grpConnection.SuspendLayout();
            tableLayoutPanelConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numTopP).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMaxTokens).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numTemperature).BeginInit();
            panelButtons.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // grpConnection
            // 
            grpConnection.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpConnection.Controls.Add(tableLayoutPanelConnection);
            grpConnection.Controls.Add(grpParameters);
            grpConnection.Location = new Point(139, 8);
            grpConnection.Margin = new Padding(2);
            grpConnection.Name = "grpConnection";
            grpConnection.Padding = new Padding(2);
            grpConnection.Size = new Size(349, 336);
            grpConnection.TabIndex = 0;
            grpConnection.TabStop = false;
            grpConnection.Text = "配置";
            // 
            // tableLayoutPanelConnection
            // 
            tableLayoutPanelConnection.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanelConnection.AutoSize = true;
            tableLayoutPanelConnection.ColumnCount = 2;
            tableLayoutPanelConnection.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 81F));
            tableLayoutPanelConnection.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelConnection.Controls.Add(txtSystemPrompt, 1, 8);
            tableLayoutPanelConnection.Controls.Add(lblSystemPrompt, 0, 8);
            tableLayoutPanelConnection.Controls.Add(numTopP, 1, 7);
            tableLayoutPanelConnection.Controls.Add(lblTopP, 0, 7);
            tableLayoutPanelConnection.Controls.Add(numMaxTokens, 1, 6);
            tableLayoutPanelConnection.Controls.Add(lblMaxTokens, 0, 6);
            tableLayoutPanelConnection.Controls.Add(numTemperature, 1, 5);
            tableLayoutPanelConnection.Controls.Add(lblTemperature, 0, 5);
            tableLayoutPanelConnection.Controls.Add(lblBaseUrl, 0, 0);
            tableLayoutPanelConnection.Controls.Add(txtBaseUrl, 1, 0);
            tableLayoutPanelConnection.Controls.Add(lblApiKey, 0, 1);
            tableLayoutPanelConnection.Controls.Add(txtApiKey, 1, 1);
            tableLayoutPanelConnection.Controls.Add(lblModel, 0, 2);
            tableLayoutPanelConnection.Controls.Add(cmbModel, 1, 2);
            tableLayoutPanelConnection.Controls.Add(lblSelectedModelTitle, 0, 3);
            tableLayoutPanelConnection.Controls.Add(btnAddModel, 1, 3);
            tableLayoutPanelConnection.Controls.Add(btnTestConnection, 1, 4);
            tableLayoutPanelConnection.Location = new Point(6, 18);
            tableLayoutPanelConnection.Margin = new Padding(2);
            tableLayoutPanelConnection.Name = "tableLayoutPanelConnection";
            tableLayoutPanelConnection.RowCount = 9;
            tableLayoutPanelConnection.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tableLayoutPanelConnection.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tableLayoutPanelConnection.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tableLayoutPanelConnection.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tableLayoutPanelConnection.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tableLayoutPanelConnection.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tableLayoutPanelConnection.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tableLayoutPanelConnection.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tableLayoutPanelConnection.RowStyles.Add(new RowStyle());
            tableLayoutPanelConnection.Size = new Size(336, 312);
            tableLayoutPanelConnection.TabIndex = 0;
            // 
            // txtSystemPrompt
            // 
            txtSystemPrompt.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtSystemPrompt.Location = new Point(83, 226);
            txtSystemPrompt.Margin = new Padding(2);
            txtSystemPrompt.Multiline = true;
            txtSystemPrompt.Name = "txtSystemPrompt";
            txtSystemPrompt.Size = new Size(251, 84);
            txtSystemPrompt.TabIndex = 7;
            // 
            // lblSystemPrompt
            // 
            lblSystemPrompt.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblSystemPrompt.Location = new Point(2, 260);
            lblSystemPrompt.Margin = new Padding(2, 0, 2, 0);
            lblSystemPrompt.Name = "lblSystemPrompt";
            lblSystemPrompt.Size = new Size(77, 16);
            lblSystemPrompt.TabIndex = 6;
            lblSystemPrompt.Text = "系统提示:";
            lblSystemPrompt.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // numTopP
            // 
            numTopP.Anchor = AnchorStyles.Left;
            numTopP.DecimalPlaces = 1;
            numTopP.Location = new Point(83, 198);
            numTopP.Margin = new Padding(2);
            numTopP.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numTopP.Name = "numTopP";
            numTopP.Size = new Size(76, 23);
            numTopP.TabIndex = 5;
            numTopP.Value = new decimal(new int[] { 9, 0, 0, 65536 });
            // 
            // lblTopP
            // 
            lblTopP.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblTopP.Location = new Point(2, 199);
            lblTopP.Margin = new Padding(2, 0, 2, 0);
            lblTopP.Name = "lblTopP";
            lblTopP.Size = new Size(77, 21);
            lblTopP.TabIndex = 4;
            lblTopP.Text = "Top-P:";
            lblTopP.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // numMaxTokens
            // 
            numMaxTokens.Anchor = AnchorStyles.Left;
            numMaxTokens.Location = new Point(83, 170);
            numMaxTokens.Margin = new Padding(2);
            numMaxTokens.Maximum = new decimal(new int[] { 131072, 0, 0, 0 });
            numMaxTokens.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numMaxTokens.Name = "numMaxTokens";
            numMaxTokens.Size = new Size(76, 23);
            numMaxTokens.TabIndex = 3;
            numMaxTokens.Value = new decimal(new int[] { 131072, 0, 0, 0 });
            // 
            // lblMaxTokens
            // 
            lblMaxTokens.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblMaxTokens.Location = new Point(2, 171);
            lblMaxTokens.Margin = new Padding(2, 0, 2, 0);
            lblMaxTokens.Name = "lblMaxTokens";
            lblMaxTokens.Size = new Size(77, 21);
            lblMaxTokens.TabIndex = 2;
            lblMaxTokens.Text = "最大Token数:";
            lblMaxTokens.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // numTemperature
            // 
            numTemperature.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            numTemperature.DecimalPlaces = 1;
            numTemperature.Location = new Point(83, 142);
            numTemperature.Margin = new Padding(2);
            numTemperature.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            numTemperature.Name = "numTemperature";
            numTemperature.Size = new Size(76, 23);
            numTemperature.TabIndex = 1;
            numTemperature.Value = new decimal(new int[] { 7, 0, 0, 65536 });
            // 
            // lblTemperature
            // 
            lblTemperature.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblTemperature.Location = new Point(2, 143);
            lblTemperature.Margin = new Padding(2, 0, 2, 0);
            lblTemperature.Name = "lblTemperature";
            lblTemperature.Size = new Size(77, 21);
            lblTemperature.TabIndex = 0;
            lblTemperature.Text = "温度参数:";
            lblTemperature.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBaseUrl
            // 
            lblBaseUrl.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblBaseUrl.Location = new Point(2, 3);
            lblBaseUrl.Margin = new Padding(2, 0, 2, 0);
            lblBaseUrl.Name = "lblBaseUrl";
            lblBaseUrl.Size = new Size(77, 21);
            lblBaseUrl.TabIndex = 0;
            lblBaseUrl.Text = "API基础URL:";
            lblBaseUrl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtBaseUrl
            // 
            txtBaseUrl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtBaseUrl.Location = new Point(83, 2);
            txtBaseUrl.Margin = new Padding(2);
            txtBaseUrl.Name = "txtBaseUrl";
            txtBaseUrl.Size = new Size(251, 23);
            txtBaseUrl.TabIndex = 1;
            txtBaseUrl.Text = "http://127.0.0.1:8080";
            // 
            // lblApiKey
            // 
            lblApiKey.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblApiKey.Location = new Point(2, 31);
            lblApiKey.Margin = new Padding(2, 0, 2, 0);
            lblApiKey.Name = "lblApiKey";
            lblApiKey.Size = new Size(77, 21);
            lblApiKey.TabIndex = 2;
            lblApiKey.Text = "API密钥:";
            lblApiKey.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtApiKey
            // 
            txtApiKey.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtApiKey.Location = new Point(83, 30);
            txtApiKey.Margin = new Padding(2);
            txtApiKey.Name = "txtApiKey";
            txtApiKey.Size = new Size(251, 23);
            txtApiKey.TabIndex = 3;
            txtApiKey.UseSystemPasswordChar = true;
            // 
            // lblModel
            // 
            lblModel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblModel.Location = new Point(2, 58);
            lblModel.Margin = new Padding(2, 0, 2, 0);
            lblModel.Name = "lblModel";
            lblModel.Size = new Size(77, 23);
            lblModel.TabIndex = 4;
            lblModel.Text = "模型:";
            lblModel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cmbModel
            // 
            cmbModel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cmbModel.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbModel.Location = new Point(83, 58);
            cmbModel.Margin = new Padding(2);
            cmbModel.Name = "cmbModel";
            cmbModel.Size = new Size(251, 25);
            cmbModel.TabIndex = 5;
            // 
            // lblSelectedModelTitle
            // 
            lblSelectedModelTitle.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblSelectedModelTitle.Location = new Point(2, 89);
            lblSelectedModelTitle.Margin = new Padding(2, 0, 2, 0);
            lblSelectedModelTitle.Name = "lblSelectedModelTitle";
            lblSelectedModelTitle.Size = new Size(77, 17);
            lblSelectedModelTitle.TabIndex = 7;
            lblSelectedModelTitle.Text = "添加模型:";
            lblSelectedModelTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnAddModel
            // 
            btnAddModel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnAddModel.Location = new Point(83, 86);
            btnAddModel.Margin = new Padding(2);
            btnAddModel.Name = "btnAddModel";
            btnAddModel.Size = new Size(251, 24);
            btnAddModel.TabIndex = 8;
            btnAddModel.Text = "添加测试模型";
            btnAddModel.UseVisualStyleBackColor = true;
            btnAddModel.Click += btnAddModel_Click;
            // 
            // btnTestConnection
            // 
            btnTestConnection.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnTestConnection.Location = new Point(83, 114);
            btnTestConnection.Margin = new Padding(2);
            btnTestConnection.Name = "btnTestConnection";
            btnTestConnection.Size = new Size(251, 24);
            btnTestConnection.TabIndex = 6;
            btnTestConnection.Text = "测试连接";
            btnTestConnection.UseVisualStyleBackColor = true;
            btnTestConnection.Click += btnTestConnection_Click;
            // 
            // grpParameters
            // 
            grpParameters.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpParameters.AutoSize = true;
            grpParameters.Location = new Point(150, 255);
            grpParameters.Margin = new Padding(2);
            grpParameters.Name = "grpParameters";
            grpParameters.Padding = new Padding(2);
            grpParameters.Size = new Size(196, 24);
            grpParameters.TabIndex = 1;
            grpParameters.TabStop = false;
            grpParameters.Text = "参数设置";
            // 
            // lstModels
            // 
            lstModels.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstModels.Location = new Point(4, 21);
            lstModels.Margin = new Padding(2);
            lstModels.Name = "lstModels";
            lstModels.Size = new Size(121, 282);
            lstModels.TabIndex = 2;
            lstModels.UseCompatibleStateImageBehavior = false;
            lstModels.View = View.List;
            // 
            // panelButtons
            // 
            panelButtons.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            panelButtons.Controls.Add(btnSave);
            panelButtons.Controls.Add(btnCancel);
            panelButtons.Location = new Point(382, 348);
            panelButtons.Margin = new Padding(2);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(105, 28);
            panelButtons.TabIndex = 1;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnSave.Location = new Point(0, 0);
            btnSave.Margin = new Padding(2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(48, 28);
            btnSave.TabIndex = 0;
            btnSave.Text = "保存";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(52, 0);
            btnCancel.Margin = new Padding(2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(53, 28);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "取消";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnDeleteModel);
            groupBox1.Controls.Add(lstModels);
            groupBox1.Location = new Point(8, 8);
            groupBox1.Margin = new Padding(2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2);
            groupBox1.Size = new Size(127, 336);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "待测试模型列表";
            // 
            // btnDeleteModel
            // 
            btnDeleteModel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnDeleteModel.Location = new Point(4, 308);
            btnDeleteModel.Name = "btnDeleteModel";
            btnDeleteModel.Size = new Size(121, 23);
            btnDeleteModel.TabIndex = 3;
            btnDeleteModel.Text = "删除模型";
            btnDeleteModel.UseVisualStyleBackColor = true;
            // 
            // ApiSettingsDialog
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(495, 385);
            Controls.Add(groupBox1);
            Controls.Add(grpConnection);
            Controls.Add(panelButtons);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ApiSettingsDialog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "API设置";
            grpConnection.ResumeLayout(false);
            grpConnection.PerformLayout();
            tableLayoutPanelConnection.ResumeLayout(false);
            tableLayoutPanelConnection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numTopP).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMaxTokens).EndInit();
            ((System.ComponentModel.ISupportInitialize)numTemperature).EndInit();
            panelButtons.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Label lblBaseUrl;
        private TextBox txtBaseUrl;
        private Label lblApiKey;
        private TextBox txtApiKey;
        private Label lblModel;
        private ComboBox cmbModel;
        private Label lblSelectedModelTitle;
        private Button btnAddModel;
        private ListView lstModels;
        private Label lblTemperature;
        private NumericUpDown numTemperature;
        private Label lblMaxTokens;
        private NumericUpDown numMaxTokens;
        private Label lblTopP;
        private NumericUpDown numTopP;
        private Label lblSystemPrompt;
        private TextBox txtSystemPrompt;
        private Button btnTestConnection;
        private Panel panelButtons;
        private Button btnSave;
        private Button btnCancel;
        private GroupBox grpConnection;
        private GroupBox grpParameters;
        private TableLayoutPanel tableLayoutPanelConnection;
        private GroupBox groupBox1;
        private Button btnDeleteModel;
    }
}
