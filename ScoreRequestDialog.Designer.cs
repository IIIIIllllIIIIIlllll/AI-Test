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
            rtbStream = new TextBox();
            tbSocre = new TextBox();
            btnSaveSocre = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tbAiAnswer = new TextBox();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
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
            rtbStream.Location = new Point(3, 3);
            rtbStream.Margin = new Padding(0);
            rtbStream.Multiline = true;
            rtbStream.Name = "rtbStream";
            rtbStream.ScrollBars = ScrollBars.Vertical;
            rtbStream.Size = new Size(820, 369);
            rtbStream.TabIndex = 2;
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
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 50);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(834, 412);
            tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(rtbStream);
            tabPage1.Location = new Point(4, 33);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(826, 375);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "评价";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(tbAiAnswer);
            tabPage2.Location = new Point(4, 33);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(826, 375);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "答案";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tbAiAnswer
            // 
            tbAiAnswer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbAiAnswer.Location = new Point(3, 3);
            tbAiAnswer.Margin = new Padding(0);
            tbAiAnswer.Multiline = true;
            tbAiAnswer.Name = "tbAiAnswer";
            tbAiAnswer.ScrollBars = ScrollBars.Vertical;
            tbAiAnswer.Size = new Size(820, 369);
            tbAiAnswer.TabIndex = 3;
            // 
            // ScoreRequestDialog
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(858, 550);
            Controls.Add(tabControl1);
            Controls.Add(btnSaveSocre);
            Controls.Add(tbSocre);
            Controls.Add(btnStart);
            Controls.Add(cmbApi);
            Name = "ScoreRequestDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "打分请求";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private ComboBox cmbApi;
        private Button btnStart;
        private TextBox rtbStream;
        private TextBox tbSocre;
        private Button btnSaveSocre;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TextBox tbAiAnswer;
    }
}

