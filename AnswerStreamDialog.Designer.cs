namespace AITest
{
    partial class AnswerStreamDialog
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
            tbOut = new TextBox();
            btnCancel = new Button();
            btnSave = new Button();
            btnRedo = new Button();
            comModels = new ComboBox();
            SuspendLayout();
            // 
            // tbOut
            // 
            tbOut.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbOut.Location = new Point(12, 50);
            tbOut.Multiline = true;
            tbOut.Name = "tbOut";
            tbOut.ScrollBars = ScrollBars.Vertical;
            tbOut.Size = new Size(776, 340);
            tbOut.TabIndex = 0;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCancel.Location = new Point(12, 404);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 34);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "取消";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.Location = new Point(668, 404);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 34);
            btnSave.TabIndex = 2;
            btnSave.Text = "保存";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnRedo
            // 
            btnRedo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRedo.Location = new Point(542, 404);
            btnRedo.Name = "btnRedo";
            btnRedo.Size = new Size(120, 34);
            btnRedo.TabIndex = 3;
            btnRedo.Text = "作答";
            btnRedo.UseVisualStyleBackColor = true;
            btnRedo.Click += btnRedo_Click;
            // 
            // comModels
            // 
            comModels.FormattingEnabled = true;
            comModels.DropDownStyle = ComboBoxStyle.DropDownList;
            comModels.Location = new Point(12, 12);
            comModels.Name = "comModels";
            comModels.Size = new Size(776, 32);
            comModels.TabIndex = 4;
            // 
            // AnswerStreamDialog
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(comModels);
            Controls.Add(btnRedo);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(tbOut);
            Name = "AnswerStreamDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "答题";
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox tbOut;
        private Button btnCancel;
        private Button btnSave;
        private Button btnRedo;
        private ComboBox comModels;
    }
}

