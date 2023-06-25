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
    public partial class CreateQuestion : Page
    {
        public CreateQuestion()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void BackButtonPress_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            main.ChangePage(mainMenu);
        }

        private void createQuestionButton_Click(object sender, EventArgs e)
        {
            string question = questionTextBox.Text;
            string correctAnswer = correctAnswerTextBox.Text;
            string answer2 = answer2TextBox.Text;
            string answer3 = answer3TextBox.Text;
            string answer4 = answer4TextBox.Text;

            if (question.Length == 0 || correctAnswer.Length == 0 || answer2.Length == 0 || answer3.Length == 0 ||
                answer4.Length == 0)
            {
                MessageBox.Show("Please fill all fields, a field can't be empty there");
            }
            else
            {
                JObject res = TriviaClient.GetClient().AddQuestion(question, correctAnswer, answer2, answer3, answer4);

                if (TriviaClient.IsSuccessResponse(res))
                {
                    MessageBox.Show("Question was added successfully!");
                    MainMenu mainMenu = new MainMenu();
                    main.ChangePage(mainMenu);
                }
            }
        }

        private void createRoomButton_Click(object sender, EventArgs e)
        {

        }
    }
}
