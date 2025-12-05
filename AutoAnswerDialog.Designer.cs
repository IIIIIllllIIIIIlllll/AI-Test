namespace AITest
{
    partial class AutoAnswerDialog
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
            lblStatus = new Label();
            tbLog = new TextBox();
            btnCancel = new Button();
            btnClose = new Button();
            lblTokensPerSecond = new Label();
            SuspendLayout();
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblStatus.Location = new Point(8, 6);
            lblStatus.Margin = new Padding(2, 0, 2, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(494, 18);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "正在自动答题...";
            // 
            // tbLog
            // 
            tbLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbLog.Location = new Point(8, 27);
            tbLog.Margin = new Padding(2);
            tbLog.Multiline = true;
            tbLog.Name = "tbLog";
            tbLog.ReadOnly = true;
            tbLog.ScrollBars = ScrollBars.Vertical;
            tbLog.Size = new Size(495, 256);
            tbLog.TabIndex = 1;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(321, 287);
            btnCancel.Margin = new Padding(2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(89, 24);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "取消";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Location = new Point(414, 287);
            btnClose.Margin = new Padding(2);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(89, 24);
            btnClose.TabIndex = 3;
            btnClose.Text = "关闭";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lblTokensPerSecond
            // 
            lblTokensPerSecond.AutoSize = true;
            lblTokensPerSecond.Location = new Point(8, 294);
            lblTokensPerSecond.Name = "lblTokensPerSecond";
            lblTokensPerSecond.Size = new Size(0, 17);
            lblTokensPerSecond.TabIndex = 4;
            lblTokensPerSecond.Text = "0 tokens/s";
            // 
            // AutoAnswerDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(509, 319);
            Controls.Add(lblTokensPerSecond);
            Controls.Add(btnClose);
            Controls.Add(btnCancel);
            Controls.Add(tbLog);
            Controls.Add(lblStatus);
            Margin = new Padding(2);
            Name = "AutoAnswerDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "自动答题";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblStatus;
        private TextBox tbLog;
        private Button btnCancel;
        private Button btnClose;
        private Label lblTokensPerSecond;
    }
}

