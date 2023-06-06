using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Timer = System.Threading.Timer;

namespace TriviaClientApp
{
    public partial class Game : Page
    {

        List<Button> answersButtons = new List<Button>();
        List<Button> AnswersButtonsOriginal = new List<Button>();
        private int timePerQuestion;
        private string correctAnswer;
        private RoomData roomData;
        private int questionNumber;
        public Game(RoomData roomData, int timePerQuestion)
        {
            InitializeComponent();
            main.AcceptButton = nextButton;
            this.roomData = roomData;
            this.questionNumber = 0;
            this.timePerQuestion = timePerQuestion;
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
            questionTimeTimer.Interval = timePerQuestion * 1000;
        }

        private void UpdateQuestion()
        {
            JObject res = TriviaClient.GetClient().GetQuestion();
            if (TriviaClient.IsSuccessResponse(res, false))
            {
                JObject result = (JObject)res["message"];
                questionLabel.Text = result["question"].Value<string>();

                // first one alwatys correct
                correctAnswer = result["answers"][0][1].Value<string>();

                for (int i = 0; i < answersButtons.Count; i++)
                {
                    answersButtons[i].Text = result["answers"][i][1].Value<string>();
                    answersButtons[i].BackColor = Color.FromKnownColor(KnownColor.Control);
                    answersButtons[i].Enabled = true;
                }

                Random rnd = new Random();

                // shuffle the list buttons
                var randomized = answersButtons.OrderBy(item => rnd.Next());

                AnswersButtonsOriginal = answersButtons;
                answersButtons = randomized.ToList();

                nextButton.Enabled = false;

                questionNumber++;
                questionNumberLabel.Text = $"Question {questionNumber}/{roomData.questionCount}";
            }
            else
            {
                foreach (Button answerButton in answersButtons)
                {
                    answerButton.Visible = false;
                }

                nextButton.Visible = false;
                questionNumberLabel.Visible = false;

                questionLabel.Text = "Waiting for players to finish answering too....";

                gameOverTImer.Start();

            }
        }

        private void AnswerButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            JObject res = TriviaClient.GetClient().SubmitAnswer(AnswersButtonsOriginal.IndexOf(button) + 1);
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
                    GetButtonByAnswer(correctAnswer).BackColor = Color.Green;
                    button.BackColor = Color.Red;
                }
                nextButton.Enabled = true;
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            UpdateQuestion();

            // reset the answer timer
            questionTimeTimer.Stop();
            questionTimeTimer.Start();

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

        /// <summary>
        /// Will get button by the given answer
        /// </summary>
        /// <param name="answer">The function to get the button by</param>
        /// <returns>Button</returns>
        private Button GetButtonByAnswer(string answer)
        {
            foreach (Button button in answersButtons)
            {
                if (button.Text == answer)
                {
                    return button;
                }
            }
            return null;
        }

        private void BackButtonPress_Click(object sender, EventArgs e)
        {
            TriviaClient.GetClient().LeaveGame();
            main.ChangePage(new MainMenu());
        }

        private void questionTimeTimer_Tick(object sender, EventArgs e)
        {
            // submit wrong answer purposely
            TriviaClient.GetClient().SubmitAnswer(-1);
            UpdateQuestion();
        }
    }
}
