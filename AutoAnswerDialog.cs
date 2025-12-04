using System;
using System.Windows.Forms;

namespace AITest
{
    public partial class AutoAnswerDialog : Form
    {
        public event Action? OnCancel;

        public AutoAnswerDialog()
        {
            InitializeComponent();
        }

        public void SetStatus(int current, int total, string title)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => SetStatus(current, total, title)));
                return;
            }
            lblStatus.Text = $"正在处理 {current}/{total}: {title}";
        }

        public void AppendLog(string text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => AppendLog(text)));
                return;
            }
            rtbLog.AppendText(text + Environment.NewLine);
            rtbLog.SelectionStart = rtbLog.TextLength;
            rtbLog.ScrollToCaret();
        }

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            btnCancel.Enabled = false;
            OnCancel?.Invoke();
        }
    }
}

