using System.Drawing;

namespace AITest
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            toolStrip = new ToolStrip();
            btnSettings = new ToolStripButton();
            btnScoreSettings = new ToolStripButton();
            splitContainerLR = new SplitContainer();
            groupBoxList = new GroupBox();
            splitContainerListButton = new SplitContainer();
            listBoxQuestions = new ListBox();
            btnAddQuestion = new Button();
            splitContainerMiddleRight = new SplitContainer();
            splitContainerQuestion = new SplitContainer();
            groupBoxQuestion = new GroupBox();
            rtbQuestion = new RichTextBox();
            groupBoxStandard = new GroupBox();
            rtbStandard = new RichTextBox();
            groupBoxAI = new GroupBox();
            rtbAI = new RichTextBox();
            btnGetAIAnswer = new Button();
            toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerLR).BeginInit();
            splitContainerLR.Panel1.SuspendLayout();
            splitContainerLR.Panel2.SuspendLayout();
            splitContainerLR.SuspendLayout();
            groupBoxList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerListButton).BeginInit();
            splitContainerListButton.Panel1.SuspendLayout();
            splitContainerListButton.Panel2.SuspendLayout();
            splitContainerListButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerMiddleRight).BeginInit();
            splitContainerMiddleRight.Panel1.SuspendLayout();
            splitContainerMiddleRight.Panel2.SuspendLayout();
            splitContainerMiddleRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerQuestion).BeginInit();
            splitContainerQuestion.Panel1.SuspendLayout();
            splitContainerQuestion.Panel2.SuspendLayout();
            splitContainerQuestion.SuspendLayout();
            groupBoxQuestion.SuspendLayout();
            groupBoxStandard.SuspendLayout();
            groupBoxAI.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip
            // 
            toolStrip.ImageScalingSize = new Size(24, 24);
            toolStrip.Items.AddRange(new ToolStripItem[] { btnSettings, btnScoreSettings });
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(1258, 33);
            toolStrip.TabIndex = 17;
            toolStrip.Text = "工具栏";
            // 
            // btnSettings
            // 
            btnSettings.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(151, 28);
            btnSettings.Text = "设置测试模型API";
            btnSettings.Click += BtnSettings_Click;
            // 
            // btnScoreSettings
            // 
            btnScoreSettings.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnScoreSettings.Name = "btnScoreSettings";
            btnScoreSettings.Size = new Size(151, 28);
            btnScoreSettings.Text = "设置打分模型API";
            btnScoreSettings.Click += BtnScoreSettings_Click;
            // 
            // splitContainerLR
            // 
            splitContainerLR.Dock = DockStyle.Fill;
            splitContainerLR.Location = new Point(0, 0);
            splitContainerLR.Margin = new Padding(5);
            splitContainerLR.Name = "splitContainerLR";
            // 
            // splitContainerLR.Panel1
            // 
            splitContainerLR.Panel1.Controls.Add(groupBoxList);
            splitContainerLR.Panel1MinSize = 200;
            // 
            // splitContainerLR.Panel2
            // 
            splitContainerLR.Panel2.Controls.Add(splitContainerMiddleRight);
            splitContainerLR.Size = new Size(1258, 664);
            splitContainerLR.SplitterDistance = 314;
            splitContainerLR.SplitterWidth = 8;
            splitContainerLR.TabIndex = 0;
            // 
            // groupBoxList
            // 
            groupBoxList.Controls.Add(splitContainerListButton);
            groupBoxList.Dock = DockStyle.Fill;
            groupBoxList.Location = new Point(0, 0);
            groupBoxList.Margin = new Padding(5);
            groupBoxList.Name = "groupBoxList";
            groupBoxList.Padding = new Padding(5);
            groupBoxList.Size = new Size(314, 664);
            groupBoxList.TabIndex = 0;
            groupBoxList.TabStop = false;
            groupBoxList.Text = "问题列表";
            // 
            // splitContainerListButton
            // 
            splitContainerListButton.Dock = DockStyle.Fill;
            splitContainerListButton.Location = new Point(5, 28);
            splitContainerListButton.Name = "splitContainerListButton";
            splitContainerListButton.Orientation = Orientation.Horizontal;
            // 
            // splitContainerListButton.Panel1
            // 
            splitContainerListButton.Panel1.Controls.Add(listBoxQuestions);
            // 
            // splitContainerListButton.Panel2
            // 
            splitContainerListButton.Panel2.Controls.Add(btnAddQuestion);
            splitContainerListButton.Size = new Size(304, 631);
            splitContainerListButton.SplitterDistance = 592;
            splitContainerListButton.SplitterWidth = 8;
            splitContainerListButton.TabIndex = 0;
            // 
            // listBoxQuestions
            // 
            listBoxQuestions.Dock = DockStyle.Fill;
            listBoxQuestions.FormattingEnabled = true;
            listBoxQuestions.ItemHeight = 24;
            listBoxQuestions.Location = new Point(0, 0);
            listBoxQuestions.Margin = new Padding(5);
            listBoxQuestions.Name = "listBoxQuestions";
            listBoxQuestions.Size = new Size(304, 592);
            listBoxQuestions.TabIndex = 0;
            // 
            // btnAddQuestion
            // 
            btnAddQuestion.Dock = DockStyle.Fill;
            btnAddQuestion.Location = new Point(0, 0);
            btnAddQuestion.Name = "btnAddQuestion";
            btnAddQuestion.Size = new Size(304, 31);
            btnAddQuestion.TabIndex = 0;
            btnAddQuestion.Text = "添加问题";
            btnAddQuestion.UseVisualStyleBackColor = true;
            // 
            // splitContainerMiddleRight
            // 
            splitContainerMiddleRight.Dock = DockStyle.Fill;
            splitContainerMiddleRight.Location = new Point(0, 0);
            splitContainerMiddleRight.Margin = new Padding(5);
            splitContainerMiddleRight.Name = "splitContainerMiddleRight";
            // 
            // splitContainerMiddleRight.Panel1
            // 
            splitContainerMiddleRight.Panel1.Controls.Add(splitContainerQuestion);
            // 
            // splitContainerMiddleRight.Panel2
            // 
            splitContainerMiddleRight.Panel2.Controls.Add(groupBoxAI);
            splitContainerMiddleRight.Size = new Size(936, 664);
            splitContainerMiddleRight.SplitterDistance = 577;
            splitContainerMiddleRight.SplitterWidth = 8;
            splitContainerMiddleRight.TabIndex = 1;
            // 
            // splitContainerQuestion
            // 
            splitContainerQuestion.Dock = DockStyle.Fill;
            splitContainerQuestion.Location = new Point(0, 0);
            splitContainerQuestion.Name = "splitContainerQuestion";
            splitContainerQuestion.Orientation = Orientation.Horizontal;
            // 
            // splitContainerQuestion.Panel1
            // 
            splitContainerQuestion.Panel1.Controls.Add(groupBoxQuestion);
            // 
            // splitContainerQuestion.Panel2
            // 
            splitContainerQuestion.Panel2.Controls.Add(groupBoxStandard);
            splitContainerQuestion.Size = new Size(577, 664);
            splitContainerQuestion.SplitterDistance = 332;
            splitContainerQuestion.SplitterWidth = 8;
            splitContainerQuestion.TabIndex = 0;
            // 
            // groupBoxQuestion
            // 
            groupBoxQuestion.Controls.Add(rtbQuestion);
            groupBoxQuestion.Dock = DockStyle.Fill;
            groupBoxQuestion.Location = new Point(0, 0);
            groupBoxQuestion.Name = "groupBoxQuestion";
            groupBoxQuestion.Size = new Size(577, 332);
            groupBoxQuestion.TabIndex = 0;
            groupBoxQuestion.TabStop = false;
            groupBoxQuestion.Text = "问题";
            // 
            // rtbQuestion
            // 
            rtbQuestion.Dock = DockStyle.Fill;
            rtbQuestion.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            rtbQuestion.Location = new Point(3, 26);
            rtbQuestion.Name = "rtbQuestion";
            rtbQuestion.ReadOnly = true;
            rtbQuestion.Size = new Size(571, 303);
            rtbQuestion.TabIndex = 0;
            rtbQuestion.Text = "";
            // 
            // groupBoxStandard
            // 
            groupBoxStandard.Controls.Add(rtbStandard);
            groupBoxStandard.Dock = DockStyle.Fill;
            groupBoxStandard.Location = new Point(0, 0);
            groupBoxStandard.Name = "groupBoxStandard";
            groupBoxStandard.Size = new Size(577, 324);
            groupBoxStandard.TabIndex = 0;
            groupBoxStandard.TabStop = false;
            groupBoxStandard.Text = "标准答案";
            // 
            // rtbStandard
            // 
            rtbStandard.Dock = DockStyle.Fill;
            rtbStandard.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            rtbStandard.Location = new Point(3, 26);
            rtbStandard.Name = "rtbStandard";
            rtbStandard.ReadOnly = true;
            rtbStandard.Size = new Size(571, 295);
            rtbStandard.TabIndex = 0;
            rtbStandard.Text = "";
            // 
            // groupBoxAI
            // 
            groupBoxAI.Controls.Add(rtbAI);
            groupBoxAI.Controls.Add(btnGetAIAnswer);
            groupBoxAI.Dock = DockStyle.Fill;
            groupBoxAI.Location = new Point(0, 0);
            groupBoxAI.Name = "groupBoxAI";
            groupBoxAI.Size = new Size(351, 664);
            groupBoxAI.TabIndex = 0;
            groupBoxAI.TabStop = false;
            groupBoxAI.Text = "AI答案";
            // 
            // rtbAI
            // 
            rtbAI.BorderStyle = BorderStyle.None;
            rtbAI.Dock = DockStyle.Fill;
            rtbAI.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            rtbAI.Location = new Point(3, 26);
            rtbAI.Name = "rtbAI";
            rtbAI.Size = new Size(345, 576);
            rtbAI.TabIndex = 0;
            rtbAI.Text = "";
            // 
            // btnGetAIAnswer
            // 
            btnGetAIAnswer.Dock = DockStyle.Bottom;
            btnGetAIAnswer.Location = new Point(3, 602);
            btnGetAIAnswer.Name = "btnGetAIAnswer";
            btnGetAIAnswer.Size = new Size(345, 59);
            btnGetAIAnswer.TabIndex = 1;
            btnGetAIAnswer.Text = "回答问题";
            btnGetAIAnswer.UseVisualStyleBackColor = true;
            btnGetAIAnswer.Click += BtnGetAIAnswer_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1258, 664);
            Controls.Add(toolStrip);
            Controls.Add(splitContainerLR);
            Margin = new Padding(5);
            MinimumSize = new Size(800, 600);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AI做题助手";
            Load += Form1_Load;
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            splitContainerLR.Panel1.ResumeLayout(false);
            splitContainerLR.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerLR).EndInit();
            splitContainerLR.ResumeLayout(false);
            groupBoxList.ResumeLayout(false);
            splitContainerListButton.Panel1.ResumeLayout(false);
            splitContainerListButton.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerListButton).EndInit();
            splitContainerListButton.ResumeLayout(false);
            splitContainerMiddleRight.Panel1.ResumeLayout(false);
            splitContainerMiddleRight.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerMiddleRight).EndInit();
            splitContainerMiddleRight.ResumeLayout(false);
            splitContainerQuestion.Panel1.ResumeLayout(false);
            splitContainerQuestion.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerQuestion).EndInit();
            splitContainerQuestion.ResumeLayout(false);
            groupBoxQuestion.ResumeLayout(false);
            groupBoxStandard.ResumeLayout(false);
            groupBoxAI.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ToolStrip toolStrip;
        private ToolStripButton btnSettings;
        private ToolStripButton btnScoreSettings;
        private SplitContainer splitContainerLR;
        private GroupBox groupBoxList;
        private ListBox listBoxQuestions;
        private SplitContainer splitContainerMiddleRight;
        private SplitContainer splitContainerQuestion;
        private GroupBox groupBoxQuestion;
        private RichTextBox rtbQuestion;
        private GroupBox groupBoxStandard;
        private RichTextBox rtbStandard;
        private GroupBox groupBoxAI;
        private RichTextBox rtbAI;
        private Button btnGetAIAnswer;
        private Button btnAddQuestion;
        private SplitContainer splitContainerListButton;
    }
}
