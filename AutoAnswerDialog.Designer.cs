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
            rtbLog = new RichTextBox();
            btnCancel = new Button();
            SuspendLayout();
            lblStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblStatus.Location = new Point(12, 9);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(776, 26);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "正在自动答题...";
            rtbLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rtbLog.Location = new Point(12, 38);
            rtbLog.Name = "rtbLog";
            rtbLog.Size = new Size(776, 360);
            rtbLog.TabIndex = 1;
            rtbLog.Text = "";
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(648, 404);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(140, 34);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "取消";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancel);
            Controls.Add(rtbLog);
            Controls.Add(lblStatus);
            Name = "AutoAnswerDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "自动答题";
            ResumeLayout(false);
        }

        private Label lblStatus;
        private RichTextBox rtbLog;
        private Button btnCancel;
    }
}

