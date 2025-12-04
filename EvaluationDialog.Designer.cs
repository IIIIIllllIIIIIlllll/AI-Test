namespace AITest
{
    partial class EvaluationDialog
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
            rtb = new RichTextBox();
            SuspendLayout();
            rtb.Dock = DockStyle.Fill;
            rtb.ReadOnly = true;
            rtb.BorderStyle = BorderStyle.None;
            rtb.Name = "rtb";
            rtb.TabIndex = 0;
            rtb.Text = "";
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 600);
            Controls.Add(rtb);
            Name = "EvaluationDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "完整评价";
            ResumeLayout(false);
        }

        private RichTextBox rtb;
    }
}

