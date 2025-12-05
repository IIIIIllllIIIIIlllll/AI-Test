namespace AITest
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            listQuestions = new ListView();
            btnAddQuestion = new Button();
            toolStrip1 = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            toolStripButton2 = new ToolStripButton();
            splitContainer1 = new SplitContainer();
            groupBox1 = new GroupBox();
            tbQuestion = new RichTextBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tbAnswer = new TextBox();
            tabPage2 = new TabPage();
            listModels = new ListView();
            tbAiAnswerBox = new TextBox();
            tabPage3 = new TabPage();
            btnViewEvaluation = new Button();
            listSocre = new ListView();
            btnShowAnswer = new Button();
            btnSubmitQuestion = new Button();
            btnAuto = new Button();
            groupBox3 = new GroupBox();
            groupBox = new GroupBox();
            listFiles = new ListView();
            btnDeleteFile = new Button();
            btnDeleteQuestion = new Button();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox.SuspendLayout();
            SuspendLayout();
            // 
            // listQuestions
            // 
            listQuestions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listQuestions.Location = new Point(6, 29);
            listQuestions.Name = "listQuestions";
            listQuestions.Size = new Size(244, 633);
            listQuestions.TabIndex = 0;
            listQuestions.UseCompatibleStateImageBehavior = false;
            // 
            // btnAddQuestion
            // 
            btnAddQuestion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAddQuestion.Location = new Point(12, 718);
            btnAddQuestion.Name = "btnAddQuestion";
            btnAddQuestion.Size = new Size(256, 34);
            btnAddQuestion.TabIndex = 1;
            btnAddQuestion.Text = "添加问题";
            btnAddQuestion.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1, toolStripButton2 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1578, 33);
            toolStrip1.TabIndex = 2;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(151, 28);
            toolStripButton1.Text = "设置答题模型API";
            // 
            // toolStripButton2
            // 
            toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(151, 28);
            toolStripButton2.Text = "设置打分模型API";
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(274, 36);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(groupBox1);
            splitContainer1.Panel1.RightToLeft = RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tabControl1);
            splitContainer1.Panel2.RightToLeft = RightToLeft.No;
            splitContainer1.RightToLeft = RightToLeft.No;
            splitContainer1.Size = new Size(1030, 796);
            splitContainer1.SplitterDistance = 465;
            splitContainer1.TabIndex = 3;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(tbQuestion);
            groupBox1.Location = new Point(0, 8);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1027, 454);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "问题";
            // 
            // tbQuestion
            // 
            tbQuestion.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbQuestion.Location = new Point(6, 29);
            tbQuestion.MaxLength = 131072;
            tbQuestion.Name = "tbQuestion";
            tbQuestion.Size = new Size(1015, 419);
            tbQuestion.TabIndex = 0;
            tbQuestion.Text = "";
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(6, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1021, 323);
            tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(tbAnswer);
            tabPage1.Location = new Point(4, 33);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1013, 286);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "标准答案";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tbAnswer
            // 
            tbAnswer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbAnswer.Location = new Point(6, 6);
            tbAnswer.MaxLength = 131072;
            tbAnswer.Multiline = true;
            tbAnswer.Name = "tbAnswer";
            tbAnswer.ScrollBars = ScrollBars.Vertical;
            tbAnswer.Size = new Size(1001, 277);
            tbAnswer.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(listModels);
            tabPage2.Controls.Add(tbAiAnswerBox);
            tabPage2.Location = new Point(4, 33);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1013, 286);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "AI答案";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // listModels
            // 
            listModels.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listModels.Location = new Point(6, 6);
            listModels.Name = "listModels";
            listModels.Size = new Size(256, 274);
            listModels.TabIndex = 2;
            listModels.UseCompatibleStateImageBehavior = false;
            // 
            // tbAiAnswerBox
            // 
            tbAiAnswerBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbAiAnswerBox.Location = new Point(268, 6);
            tbAiAnswerBox.MaxLength = 131072;
            tbAiAnswerBox.Multiline = true;
            tbAiAnswerBox.Name = "tbAiAnswerBox";
            tbAiAnswerBox.ScrollBars = ScrollBars.Vertical;
            tbAiAnswerBox.Size = new Size(739, 277);
            tbAiAnswerBox.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(btnViewEvaluation);
            tabPage3.Controls.Add(listSocre);
            tabPage3.Location = new Point(4, 33);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(1013, 286);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "得分情况";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnViewEvaluation
            // 
            btnViewEvaluation.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnViewEvaluation.Location = new Point(857, 246);
            btnViewEvaluation.Name = "btnViewEvaluation";
            btnViewEvaluation.Size = new Size(153, 34);
            btnViewEvaluation.TabIndex = 11;
            btnViewEvaluation.Text = "查看评价";
            btnViewEvaluation.UseVisualStyleBackColor = true;
            // 
            // listSocre
            // 
            listSocre.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listSocre.Location = new Point(3, 3);
            listSocre.Name = "listSocre";
            listSocre.Size = new Size(1007, 238);
            listSocre.TabIndex = 10;
            listSocre.UseCompatibleStateImageBehavior = false;
            // 
            // btnShowAnswer
            // 
            btnShowAnswer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnShowAnswer.Location = new Point(1310, 502);
            btnShowAnswer.Name = "btnShowAnswer";
            btnShowAnswer.Size = new Size(256, 34);
            btnShowAnswer.TabIndex = 5;
            btnShowAnswer.Text = "开始打分";
            btnShowAnswer.UseVisualStyleBackColor = true;
            // 
            // btnSubmitQuestion
            // 
            btnSubmitQuestion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSubmitQuestion.Location = new Point(1310, 464);
            btnSubmitQuestion.Name = "btnSubmitQuestion";
            btnSubmitQuestion.Size = new Size(256, 34);
            btnSubmitQuestion.TabIndex = 6;
            btnSubmitQuestion.Text = "回答问题";
            btnSubmitQuestion.UseVisualStyleBackColor = true;
            // 
            // btnAuto
            // 
            btnAuto.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAuto.Location = new Point(12, 798);
            btnAuto.Name = "btnAuto";
            btnAuto.Size = new Size(256, 34);
            btnAuto.TabIndex = 9;
            btnAuto.Text = "自动答题";
            btnAuto.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox3.Controls.Add(listQuestions);
            groupBox3.Location = new Point(12, 44);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(256, 668);
            groupBox3.TabIndex = 11;
            groupBox3.TabStop = false;
            groupBox3.Text = "问题列表";
            // 
            // groupBox
            // 
            groupBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox.Controls.Add(listFiles);
            groupBox.Location = new Point(1310, 44);
            groupBox.Name = "groupBox";
            groupBox.Size = new Size(256, 374);
            groupBox.TabIndex = 12;
            groupBox.TabStop = false;
            groupBox.Text = "附件列表";
            // 
            // listFiles
            // 
            listFiles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listFiles.Location = new Point(6, 29);
            listFiles.Name = "listFiles";
            listFiles.Size = new Size(244, 339);
            listFiles.TabIndex = 0;
            listFiles.UseCompatibleStateImageBehavior = false;
            // 
            // btnDeleteFile
            // 
            btnDeleteFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDeleteFile.Enabled = false;
            btnDeleteFile.Location = new Point(1310, 424);
            btnDeleteFile.Name = "btnDeleteFile";
            btnDeleteFile.Size = new Size(256, 34);
            btnDeleteFile.TabIndex = 13;
            btnDeleteFile.Text = "删除文件";
            btnDeleteFile.UseVisualStyleBackColor = true;
            // 
            // btnDeleteQuestion
            // 
            btnDeleteQuestion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDeleteQuestion.Location = new Point(12, 758);
            btnDeleteQuestion.Name = "btnDeleteQuestion";
            btnDeleteQuestion.Size = new Size(256, 34);
            btnDeleteQuestion.TabIndex = 14;
            btnDeleteQuestion.Text = "删除问题";
            btnDeleteQuestion.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1578, 844);
            Controls.Add(btnDeleteQuestion);
            Controls.Add(btnDeleteFile);
            Controls.Add(groupBox);
            Controls.Add(groupBox3);
            Controls.Add(btnAuto);
            Controls.Add(btnSubmitQuestion);
            Controls.Add(btnShowAnswer);
            Controls.Add(splitContainer1);
            Controls.Add(toolStrip1);
            Controls.Add(btnAddQuestion);
            Name = "MainWindow";
            Text = "AI答题器";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listQuestions;
        private Button btnAddQuestion;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private SplitContainer splitContainer1;
        private RichTextBox tbQuestion;
        private TextBox tbAnswer;
        private Button btnShowAnswer;
        private Button btnSubmitQuestion;
        private Button btnAuto;
        private ListView listSocre;
        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private GroupBox groupBox;
        private ListView listFiles;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TextBox tbAiAnswerBox;
        private Button btnDeleteFile;
        private Button btnDeleteQuestion;
        private ListView listModels;
        private TabPage tabPage3;
        private Button btnViewEvaluation;
    }
}
