using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AITest
{
    public class RichTextStreamAppender
    {
        private readonly RichTextBox _target;
        private readonly System.Windows.Forms.Timer _timer;
        private readonly StringBuilder _buffer = new StringBuilder();
        private readonly object _lock = new object();

        public RichTextStreamAppender(RichTextBox target, int intervalMs = 50)
        {
            _target = target;
            _timer = new System.Windows.Forms.Timer { Interval = intervalMs };
            _timer.Tick += FlushTick;
            _timer.Start();
        }

        public void Append(string text)
        {
            lock (_lock) { _buffer.Append(text); }
        }

        private void FlushTick(object? sender, EventArgs e)
        {
            string chunk;
            lock (_lock)
            {
                if (_buffer.Length == 0) return;
                chunk = _buffer.ToString();
                _buffer.Clear();
            }
            SuspendRedraw(_target);
            _target.AppendText(chunk);
            ResumeRedraw(_target);
            if (IsNearBottom(_target))
            {
                _target.SelectionStart = _target.TextLength;
                _target.ScrollToCaret();
            }
        }

        private static bool IsNearBottom(RichTextBox rtb)
        {
            var si = new SCROLLINFO();
            si.cbSize = Marshal.SizeOf<SCROLLINFO>();
            si.fMask = SIF_ALL;
            if (GetScrollInfo(rtb.Handle, SB_VERT, ref si) == 0) return true;
            return si.nPos + si.nPage >= si.nMax - 1;
        }

        private static void SuspendRedraw(Control c)
        {
            SendMessage(c.Handle, WM_SETREDRAW, IntPtr.Zero, IntPtr.Zero);
        }

        private static void ResumeRedraw(Control c)
        {
            SendMessage(c.Handle, WM_SETREDRAW, new IntPtr(1), IntPtr.Zero);
            c.Invalidate();
        }

        private const int SB_VERT = 1;
        private const int SIF_ALL = 0x17;
        private const int WM_SETREDRAW = 0x0B;

        [StructLayout(LayoutKind.Sequential)]
        private struct SCROLLINFO
        {
            public int cbSize;
            public int fMask;
            public int nMin;
            public int nMax;
            public int nPage;
            public int nPos;
            public int nTrackPos;
        }

        [DllImport("user32.dll")]
        private static extern int GetScrollInfo(IntPtr hwnd, int nBar, ref SCROLLINFO lpsi);

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
    }
}

