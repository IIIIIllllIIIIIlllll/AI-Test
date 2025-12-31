using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace AITest
{
    public partial class AddQuestionDialog : Form
    {
        public string QuestionTitle { get; private set; } = string.Empty;
        public string QuestionContent { get; private set; } = string.Empty;
        public string AnswerContent { get; private set; } = string.Empty;

        public AddQuestionDialog()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("请输入问题标题", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtQuestion.Text))
            {
                MessageBox.Show("请输入问题内容", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAnswer.Text))
            {
                MessageBox.Show("请输入答案内容", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            QuestionTitle = txtTitle.Text;
            QuestionContent = txtQuestion.Text;
            AnswerContent = txtAnswer.Text;
            try
            {
                var folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "questions");
                Directory.CreateDirectory(folder);
                var safe = MakeSafeFileName(QuestionTitle);
                var fileName = $"{DateTime.Now:yyyyMMddHHmmssfff}_{safe}.json";
                var path = Path.Combine(folder, fileName);
                var payload = new { title = QuestionTitle, question = QuestionContent, answer = AnswerContent };
                var json = JsonConvert.SerializeObject(payload, Formatting.Indented);
                File.WriteAllText(path, json, Encoding.UTF8);
            }
            catch
            {
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private static string MakeSafeFileName(string input)
        {
            var sb = new StringBuilder(input);
            foreach (var ch in Path.GetInvalidFileNameChars())
            {
                sb.Replace(ch, '_');
            }
            return sb.ToString().Trim();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
