namespace AITest
{
    partial class ScoreListDialog
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
            listScores = new ListView();
            colModel = new ColumnHeader();
            colScore = new ColumnHeader();
            btnViewEval = new Button();
            SuspendLayout();
            listScores.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listScores.Location = new Point(12, 12);
            listScores.Name = "listScores";
            listScores.Size = new Size(556, 332);
            listScores.TabIndex = 0;
            listScores.View = View.Details;
            listScores.FullRowSelect = true;
            listScores.Columns.AddRange(new ColumnHeader[] { colModel, colScore });
            colModel.Text = "模型名";
            colModel.Width = 360;
            colScore.Text = "分数";
            colScore.Width = 160;
            btnViewEval.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnViewEval.Location = new Point(404, 350);
            btnViewEval.Name = "btnViewEval";
            btnViewEval.Size = new Size(164, 32);
            btnViewEval.TabIndex = 1;
            btnViewEval.Text = "查看评价";
            btnViewEval.UseVisualStyleBackColor = true;
            btnViewEval.Click += btnViewEval_Click;
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(580, 394);
            Controls.Add(btnViewEval);
            Controls.Add(listScores);
            Name = "ScoreListDialog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "分数列表";
            ResumeLayout(false);
        }

        private ListView listScores;
        private ColumnHeader colModel;
        private ColumnHeader colScore;
        private Button btnViewEval;
    }
}

