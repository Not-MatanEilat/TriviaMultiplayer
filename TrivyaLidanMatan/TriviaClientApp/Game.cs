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
    public partial class Game : Page
    {

        List<Button> answersButtons = new List<Button>();

        public Game()
        {
            InitializeComponent();
            main.AcceptButton = nextButton;
        }

        private void Game_Load(object sender, EventArgs e)
        {
            answersButtons.Add(answer1Button);
            answersButtons.Add(answer2Button);
            answersButtons.Add(answer3Button);
            answersButtons.Add(answer4Button);
            foreach (Button button in answersButtons)
            {
                button.Click += AnswerButton_Click;
            }
            UpdateQuestion();
        }

        private void UpdateQuestion()
        {
            JObject res = TriviaClient.GetClient().GetQuestion();
            if (TriviaClient.IsSuccessResponse(res, false))
            {
                JObject result = (JObject)res["message"];
                questionLabel.Text = result["question"].Value<string>();
                for (int i = 0; i < answersButtons.Count; i++)
                {
                    answersButtons[i].Text = result["answers"][i][1].Value<string>();
                    answersButtons[i].BackColor = Color.FromKnownColor(KnownColor.Control);
                    answersButtons[i].Enabled = true;
                }
                nextButton.Enabled = false;
            }
            else
            {
                foreach (Button answerButton in answersButtons)
                {
                    answerButton.Visible = false;
                }

                nextButton.Visible = false;

                questionLabel.Text = "Waiting for players to finish answering too....";

                gameOverTImer.Start();

            }
        }

        private void AnswerButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            JObject res = TriviaClient.GetClient().SubmitAnswer(answersButtons.IndexOf(button) + 1);
            if (TriviaClient.IsSuccessResponse(res))
            {
                JObject result = (JObject)res["message"];
                for (int i = 0; i < answersButtons.Count; i++)
                {
                    answersButtons[i].Enabled = false;
                }
                if (result["correctAnswer"].Value<bool>())
                {
                    button.BackColor = Color.Green;
                }
                else
                {
                    button.BackColor = Color.Red;
                }
                nextButton.Enabled = true;
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            UpdateQuestion();
        }

        private void gameOverTImer_Tick(object sender, EventArgs e)
        {
            JObject result = TriviaClient.GetClient().GetGameResults();
            if (TriviaClient.IsSuccessResponse(result, false))
            {
                gameOverTImer.Stop();
                GameResults gameResults = new GameResults((JObject)result["message"]);
                main.ChangePage(gameResults);
            }
        }

        private void BackButtonPress_Click(object sender, EventArgs e)
        {
            TriviaClient.GetClient().LeaveGame();
            main.ChangePage(new MainMenu());
        }
    }
}
