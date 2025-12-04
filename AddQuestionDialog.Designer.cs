using System.Drawing;

namespace AITest
{
    partial class AddQuestionDialog
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
            tableLayoutPanel1 = new TableLayoutPanel();
            lblTitle = new Label();
            txtTitle = new TextBox();
            lblQuestion = new Label();
            txtQuestion = new TextBox();
            lblAnswer = new Label();
            txtAnswer = new TextBox();
            panelButtons = new Panel();
            btnOK = new Button();
            btnCancel = new Button();
            tableLayoutPanel1.SuspendLayout();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(lblTitle, 0, 0);
            tableLayoutPanel1.Controls.Add(txtTitle, 1, 0);
            tableLayoutPanel1.Controls.Add(lblQuestion, 0, 1);
            tableLayoutPanel1.Controls.Add(txtQuestion, 1, 1);
            tableLayoutPanel1.Controls.Add(lblAnswer, 0, 2);
            tableLayoutPanel1.Controls.Add(txtAnswer, 1, 2);
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.Size = new Size(1234, 594);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(3, 8);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(94, 24);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "问题标题:";
            // 
            // txtTitle
            // 
            txtTitle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtTitle.Location = new Point(103, 3);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(1128, 30);
            txtTitle.TabIndex = 1;
            // 
            // lblQuestion
            // 
            lblQuestion.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblQuestion.AutoSize = true;
            lblQuestion.Location = new Point(3, 154);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(94, 24);
            lblQuestion.TabIndex = 2;
            lblQuestion.Text = "问题内容:";
            // 
            // txtQuestion
            // 
            txtQuestion.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtQuestion.Location = new Point(103, 43);
            txtQuestion.Multiline = true;
            txtQuestion.Name = "txtQuestion";
            txtQuestion.ScrollBars = ScrollBars.Vertical;
            txtQuestion.Size = new Size(1128, 246);
            txtQuestion.TabIndex = 3;
            // 
            // lblAnswer
            // 
            lblAnswer.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblAnswer.AutoSize = true;
            lblAnswer.Location = new Point(3, 406);
            lblAnswer.Name = "lblAnswer";
            lblAnswer.Size = new Size(94, 24);
            lblAnswer.TabIndex = 4;
            lblAnswer.Text = "答案内容:";
            // 
            // txtAnswer
            // 
            txtAnswer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtAnswer.Location = new Point(103, 295);
            txtAnswer.Multiline = true;
            txtAnswer.Name = "txtAnswer";
            txtAnswer.ScrollBars = ScrollBars.Vertical;
            txtAnswer.Size = new Size(1128, 246);
            txtAnswer.TabIndex = 5;
            // 
            // panelButtons
            // 
            panelButtons.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            panelButtons.Controls.Add(btnOK);
            panelButtons.Controls.Add(btnCancel);
            panelButtons.Location = new Point(1081, 612);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(165, 40);
            panelButtons.TabIndex = 6;
            // 
            // btnOK
            // 
            btnOK.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnOK.Location = new Point(0, 0);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 40);
            btnOK.TabIndex = 0;
            btnOK.Text = "确定";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnCancel.Location = new Point(81, 0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(84, 40);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "取消";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // AddQuestionDialog
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1258, 664);
            Controls.Add(panelButtons);
            Controls.Add(tableLayoutPanel1);
            MinimumSize = new Size(640, 480);
            Name = "AddQuestionDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "添加问题";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel tableLayoutPanel1;
        private Label lblTitle;
        private TextBox txtTitle;
        private Label lblQuestion;
        private TextBox txtQuestion;
        private Label lblAnswer;
        private TextBox txtAnswer;
        private Panel panelButtons;
        private Button btnOK;
        private Button btnCancel;
    }
}