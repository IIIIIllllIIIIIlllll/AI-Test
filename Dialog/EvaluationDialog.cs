using System.Windows.Forms;

namespace AITest
{
    public partial class EvaluationDialog : Form
    {
        public EvaluationDialog(string text)
        {
            InitializeComponent();
            rtb.Text = text ?? string.Empty;
        }
    }
}

