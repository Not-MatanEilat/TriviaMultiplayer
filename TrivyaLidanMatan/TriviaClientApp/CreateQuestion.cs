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

            JObject res = TriviaClient.GetClient().AddQuestion(question, correctAnswer, answer2, answer3, answer4);

            if (TriviaClient.IsSuccessResponse(res))
            {
                MessageBox.Show("Question was added successfully!");
            }
        }
    }
}
