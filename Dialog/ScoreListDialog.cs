using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace AITest
{
    public partial class ScoreListDialog : Form
    {
        private readonly string _title;
        private JArray? _scoreArray;

        public ScoreListDialog(string title)
        {
            InitializeComponent();
            _title = title;
            LoadScores();
        }

        private void LoadScores()
        {
            try
            {
                listScores.Items.Clear();
                var folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "questions");
                var files = Directory.GetFiles(folder, "*.json");
                foreach (var file in files)
                {
                    var json = File.ReadAllText(file);
                    var obj = JObject.Parse(json);
                    var t = obj["title"]?.ToString();
                    if (string.Equals(t, _title, StringComparison.Ordinal))
                    {
                        var s = obj["score"] as JArray;
                        _scoreArray = s;
                        if (s != null)
                        {
                            foreach (var item in s.OfType<JObject>())
                            {
                                var model = item["modelName"]?.ToString();
                                var score = item["socre"]?.ToString() ?? "";
                                var lvi = new ListViewItem(new[] { model, score });
                                lvi.Tag = item;
                                listScores.Items.Add(lvi);
                            }
                        }
                        break;
                    }
                }
            }
            catch { }
        }

        private void btnViewEval_Click(object? sender, EventArgs e)
        {
            if (listScores.SelectedItems.Count == 0) return;
            var obj = listScores.SelectedItems[0].Tag as JObject;
            var eval = obj?["evaluation"]?.ToString();
            using var dlg = new EvaluationDialog(eval);
            dlg.ShowDialog(this);
        }
    }
}

