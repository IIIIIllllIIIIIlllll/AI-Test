using System;
using System.Text;
using System.Windows.Forms;

namespace AITest
{
    public partial class AutoAnswerDialog : Form
    {
        public event Action? OnCancel;
        private readonly StringBuilder _streamBuffer = new StringBuilder();
        private readonly System.Diagnostics.Stopwatch _tokenStopwatch = new System.Diagnostics.Stopwatch();
        private int _totalTokens = 0;

        public AutoAnswerDialog()
        {
            InitializeComponent();
            btnClose.Enabled = false;
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
            tbLog.AppendText(text + Environment.NewLine);
            tbLog.SelectionStart = tbLog.TextLength;
            tbLog.ScrollToCaret();
        }

        public void OnStreamChunk(string chunk)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => OnStreamChunk(chunk)));
                return;
            }
            _streamBuffer.Append(chunk);
            _totalTokens++;
            UpdateTokensPerSecond();
        }

        private void UpdateTokensPerSecond()
        {
            if (!_tokenStopwatch.IsRunning) _tokenStopwatch.Start();
            var elapsed = _tokenStopwatch.Elapsed.TotalSeconds;
            var tps = elapsed > 0 ? _totalTokens / elapsed : 0;
            lblTokensPerSecond.Text = $"{tps:F1} tokens/s";
        }

        public void OnFinished()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(OnFinished));
                return;
            }
            _tokenStopwatch.Stop();
            btnClose.Enabled = true;
            try
            {
                tbLog.AppendText("自动任务已完成" + Environment.NewLine);
                tbLog.SelectionStart = tbLog.TextLength;
                tbLog.ScrollToCaret();
            }
            catch { }
        }

        public string GetStreamedContent()
        {
            return _streamBuffer.ToString();
        }

        public void ResetStreamMetrics()
        {
            _streamBuffer.Clear();
            _totalTokens = 0;
            _tokenStopwatch.Reset();
            lblTokensPerSecond.Text = "0 tokens/s";
        }

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            btnCancel.Enabled = false;
            OnCancel?.Invoke();
        }

        private void btnClose_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}

