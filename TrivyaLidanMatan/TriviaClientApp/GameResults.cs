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
    public partial class GameResults : Page
    {
        private const int PLAYER_LABEL_BASE_X = 10;
        private const int PLAYER_LABEL_BASE_Y = 20;
        private const int PLAYER_LABEL_MARGIN = 30;

        private JObject results;
        public GameResults(JObject results)
        {
            InitializeComponent();
            this.results = results;
        }

        /// <summary>
        /// Load Results
        /// </summary>
        public void LoadResults()
        {
            resultsFlow.Controls.Clear();
            int i = 0;
            foreach (JToken result in results["results"])
            {
                string resultStr = $"{i + 1}. {result["username"]} - Correct: {result["correctAnswerCount"]} avg speed: {result["averageAnswerTime"].Value<float>() / 1000} secs";
                Label playerLabel = new()
                {
                    Text = resultStr,
                    Location = new Point(PLAYER_LABEL_BASE_X, PLAYER_LABEL_BASE_Y + i * PLAYER_LABEL_MARGIN),
                    AutoSize = true,
                    Font = new Font("Berlin Sans FB Demi", 20F, FontStyle.Regular, GraphicsUnit.Point)
                };

                resultsFlow.Controls.Add(playerLabel);

                i++;
            }
        }

        private void GameResults_Load(object sender, EventArgs e)
        {
            LoadResults();
        }

        private void leaveButton_Click(object sender, EventArgs e)
        {
            soundManager.PlayButtonClickSound();

            TriviaClient.GetClient().LeaveGame();
            main.ChangePage(new MainMenu());
        }
    }
}
