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
            lblSelectedModelValue = new Label();
            btnTestConnection = new Button();
            grpParameters = new GroupBox();
            panelButtons = new Panel();
            btnSave = new Button();
            btnCancel = new Button();
            grpConnection.SuspendLayout();
            tableLayoutPanelConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numTopP).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMaxTokens).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numTemperature).BeginInit();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // grpConnection
            // 
            grpConnection.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpConnection.Controls.Add(tableLayoutPanelConnection);
            grpConnection.Controls.Add(grpParameters);
            grpConnection.Location = new Point(12, 12);
            grpConnection.Name = "grpConnection";
            grpConnection.Size = new Size(754, 474);
            grpConnection.TabIndex = 0;
            grpConnection.TabStop = false;
            grpConnection.Text = "连接设置";
            // 
            // tableLayoutPanelConnection
            // 
            tableLayoutPanelConnection.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanelConnection.AutoSize = true;
            tableLayoutPanelConnection.ColumnCount = 2;
            tableLayoutPanelConnection.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 128F));
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
            tableLayoutPanelConnection.Controls.Add(lblSelectedModelValue, 1, 3);
            tableLayoutPanelConnection.Controls.Add(btnTestConnection, 1, 4);
            tableLayoutPanelConnection.Location = new Point(10, 25);
            tableLayoutPanelConnection.Name = "tableLayoutPanelConnection";
            tableLayoutPanelConnection.RowCount = 9;
            tableLayoutPanelConnection.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanelConnection.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanelConnection.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanelConnection.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanelConnection.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanelConnection.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanelConnection.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanelConnection.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanelConnection.RowStyles.Add(new RowStyle());
            tableLayoutPanelConnection.Size = new Size(734, 440);
            tableLayoutPanelConnection.TabIndex = 0;
            // 
            // txtSystemPrompt
            // 
            txtSystemPrompt.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtSystemPrompt.Location = new Point(131, 323);
            txtSystemPrompt.Multiline = true;
            txtSystemPrompt.Name = "txtSystemPrompt";
            txtSystemPrompt.Size = new Size(600, 114);
            txtSystemPrompt.TabIndex = 7;
            // 
            // lblSystemPrompt
            // 
            lblSystemPrompt.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblSystemPrompt.Location = new Point(3, 368);
            lblSystemPrompt.Name = "lblSystemPrompt";
            lblSystemPrompt.Size = new Size(122, 23);
            lblSystemPrompt.TabIndex = 6;
            lblSystemPrompt.Text = "系统提示:";
            lblSystemPrompt.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // numTopP
            // 
            numTopP.Anchor = AnchorStyles.Left;
            numTopP.DecimalPlaces = 1;
            numTopP.Location = new Point(131, 285);
            numTopP.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numTopP.Name = "numTopP";
            numTopP.Size = new Size(120, 30);
            numTopP.TabIndex = 5;
            numTopP.Value = new decimal(new int[] { 9, 0, 0, 65536 });
            // 
            // lblTopP
            // 
            lblTopP.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblTopP.Location = new Point(3, 285);
            lblTopP.Name = "lblTopP";
            lblTopP.Size = new Size(122, 30);
            lblTopP.TabIndex = 4;
            lblTopP.Text = "Top-P:";
            lblTopP.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // numMaxTokens
            // 
            numMaxTokens.Anchor = AnchorStyles.Left;
            numMaxTokens.Location = new Point(131, 245);
            numMaxTokens.Maximum = new decimal(new int[] { 131072, 0, 0, 0 });
            numMaxTokens.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numMaxTokens.Name = "numMaxTokens";
            numMaxTokens.Size = new Size(120, 30);
            numMaxTokens.TabIndex = 3;
            numMaxTokens.Value = new decimal(new int[] { 131072, 0, 0, 0 });
            // 
            // lblMaxTokens
            // 
            lblMaxTokens.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblMaxTokens.Location = new Point(3, 245);
            lblMaxTokens.Name = "lblMaxTokens";
            lblMaxTokens.Size = new Size(122, 30);
            lblMaxTokens.TabIndex = 2;
            lblMaxTokens.Text = "最大Token数:";
            lblMaxTokens.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // numTemperature
            // 
            numTemperature.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            numTemperature.DecimalPlaces = 1;
            numTemperature.Location = new Point(131, 203);
            numTemperature.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            numTemperature.Name = "numTemperature";
            numTemperature.Size = new Size(120, 30);
            numTemperature.TabIndex = 1;
            numTemperature.Value = new decimal(new int[] { 7, 0, 0, 65536 });
            // 
            // lblTemperature
            // 
            lblTemperature.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblTemperature.Location = new Point(3, 205);
            lblTemperature.Name = "lblTemperature";
            lblTemperature.Size = new Size(122, 30);
            lblTemperature.TabIndex = 0;
            lblTemperature.Text = "温度参数:";
            lblTemperature.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBaseUrl
            // 
            lblBaseUrl.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblBaseUrl.Location = new Point(3, 5);
            lblBaseUrl.Name = "lblBaseUrl";
            lblBaseUrl.Size = new Size(122, 30);
            lblBaseUrl.TabIndex = 0;
            lblBaseUrl.Text = "API基础URL:";
            lblBaseUrl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtBaseUrl
            // 
            txtBaseUrl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtBaseUrl.Location = new Point(131, 3);
            txtBaseUrl.Name = "txtBaseUrl";
            txtBaseUrl.Size = new Size(600, 30);
            txtBaseUrl.TabIndex = 1;
            txtBaseUrl.Text = "http://127.0.0.1:8080";
            // 
            // lblApiKey
            // 
            lblApiKey.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblApiKey.Location = new Point(3, 45);
            lblApiKey.Name = "lblApiKey";
            lblApiKey.Size = new Size(122, 30);
            lblApiKey.TabIndex = 2;
            lblApiKey.Text = "API密钥:";
            lblApiKey.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtApiKey
            // 
            txtApiKey.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtApiKey.Location = new Point(131, 43);
            txtApiKey.Name = "txtApiKey";
            txtApiKey.Size = new Size(600, 30);
            txtApiKey.TabIndex = 3;
            txtApiKey.UseSystemPasswordChar = true;
            // 
            // lblModel
            // 
            lblModel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblModel.Location = new Point(3, 84);
            lblModel.Name = "lblModel";
            lblModel.Size = new Size(122, 32);
            lblModel.TabIndex = 4;
            lblModel.Text = "模型:";
            lblModel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cmbModel
            // 
            cmbModel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cmbModel.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbModel.Location = new Point(131, 83);
            cmbModel.Name = "cmbModel";
            cmbModel.Size = new Size(600, 32);
            cmbModel.TabIndex = 5;
            // 
            // lblSelectedModelTitle
            // 
            lblSelectedModelTitle.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblSelectedModelTitle.Location = new Point(3, 128);
            lblSelectedModelTitle.Name = "lblSelectedModelTitle";
            lblSelectedModelTitle.Size = new Size(122, 24);
            lblSelectedModelTitle.TabIndex = 7;
            lblSelectedModelTitle.Text = "已选模型:";
            lblSelectedModelTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSelectedModelValue
            // 
            lblSelectedModelValue.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblSelectedModelValue.AutoSize = true;
            lblSelectedModelValue.Location = new Point(131, 128);
            lblSelectedModelValue.Name = "lblSelectedModelValue";
            lblSelectedModelValue.Size = new Size(600, 24);
            lblSelectedModelValue.TabIndex = 8;
            lblSelectedModelValue.Text = "未选择";
            // 
            // btnTestConnection
            // 
            btnTestConnection.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnTestConnection.Location = new Point(131, 163);
            btnTestConnection.Name = "btnTestConnection";
            btnTestConnection.Size = new Size(600, 34);
            btnTestConnection.TabIndex = 6;
            btnTestConnection.Text = "测试连接";
            btnTestConnection.UseVisualStyleBackColor = true;
            btnTestConnection.Click += btnTestConnection_Click;
            // 
            // grpParameters
            // 
            grpParameters.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpParameters.AutoSize = true;
            grpParameters.Location = new Point(235, 360);
            grpParameters.Name = "grpParameters";
            grpParameters.Size = new Size(514, 34);
            grpParameters.TabIndex = 1;
            grpParameters.TabStop = false;
            grpParameters.Text = "参数设置";
            // 
            // panelButtons
            // 
            panelButtons.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            panelButtons.Controls.Add(btnSave);
            panelButtons.Controls.Add(btnCancel);
            panelButtons.Location = new Point(601, 492);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(165, 40);
            panelButtons.TabIndex = 1;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnSave.Location = new Point(0, 0);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 40);
            btnSave.TabIndex = 0;
            btnSave.Text = "保存";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(81, 0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(84, 40);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "取消";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // ApiSettingsDialog
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(778, 544);
            Controls.Add(grpConnection);
            Controls.Add(panelButtons);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ApiSettingsDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "API设置";
            grpConnection.ResumeLayout(false);
            grpConnection.PerformLayout();
            tableLayoutPanelConnection.ResumeLayout(false);
            tableLayoutPanelConnection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numTopP).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMaxTokens).EndInit();
            ((System.ComponentModel.ISupportInitialize)numTemperature).EndInit();
            panelButtons.ResumeLayout(false);
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
        private Label lblSelectedModelValue;
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
    }
}
