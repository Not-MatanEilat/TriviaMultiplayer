using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace TriviaClientApp
{
    public partial class HighScore : Page
    {
        public HighScore()
        {
            InitializeComponent();
        }

        private void HighScore_Load(object sender, EventArgs e)
        {
            TriviaClient client = TriviaClient.GetClient();
            JObject result = client.GetHighScores();
            JArray stats = (JArray)result["message"]["highscores"];
            stats.Insert(0, "High Scores:");
            string statsStr = String.Join("\n", stats);
            highScores.Text = statsStr;
            int i = 0;
        }

        private void BackButtonPress_Click(object sender, EventArgs e)
        {
            soundManager.PlayButtonClickSound();

            Statistics menu = new Statistics();
            main.ChangePage(menu);
        }
    }
}
