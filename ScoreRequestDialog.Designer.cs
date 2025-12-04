namespace AITest
{
    partial class ScoreRequestDialog
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
            cmbApi = new ComboBox();
            btnStart = new Button();
            rtbStream = new RichTextBox();
            tbSocre = new TextBox();
            btnSaveSocre = new Button();
            SuspendLayout();
            // 
            // cmbApi
            // 
            cmbApi.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbApi.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbApi.FormattingEnabled = true;
            cmbApi.Location = new Point(12, 12);
            cmbApi.Name = "cmbApi";
            cmbApi.Size = new Size(676, 32);
            cmbApi.TabIndex = 0;
            // 
            // btnStart
            // 
            btnStart.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnStart.Location = new Point(694, 12);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(152, 32);
            btnStart.TabIndex = 1;
            btnStart.Text = "开始打分";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // rtbStream
            // 
            rtbStream.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rtbStream.Location = new Point(12, 60);
            rtbStream.Name = "rtbStream";
            rtbStream.Size = new Size(834, 402);
            rtbStream.TabIndex = 2;
            rtbStream.Text = "";
            // 
            // tbSocre
            // 
            tbSocre.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbSocre.Location = new Point(12, 468);
            tbSocre.Name = "tbSocre";
            tbSocre.Size = new Size(834, 30);
            tbSocre.TabIndex = 3;
            tbSocre.KeyPress += tbSocre_KeyPress;
            // 
            // btnSaveSocre
            // 
            btnSaveSocre.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnSaveSocre.Location = new Point(12, 504);
            btnSaveSocre.Name = "btnSaveSocre";
            btnSaveSocre.Size = new Size(834, 34);
            btnSaveSocre.TabIndex = 4;
            btnSaveSocre.Text = "保存分数";
            btnSaveSocre.UseVisualStyleBackColor = true;
            btnSaveSocre.Click += btnSaveSocre_Click;
            // 
            // ScoreRequestDialog
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(858, 550);
            Controls.Add(btnSaveSocre);
            Controls.Add(tbSocre);
            Controls.Add(rtbStream);
            Controls.Add(btnStart);
            Controls.Add(cmbApi);
            Name = "ScoreRequestDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "打分请求";
            ResumeLayout(false);
            PerformLayout();
        }

        private ComboBox cmbApi;
        private Button btnStart;
        private RichTextBox rtbStream;
        private TextBox tbSocre;
        private Button btnSaveSocre;
    }
}

