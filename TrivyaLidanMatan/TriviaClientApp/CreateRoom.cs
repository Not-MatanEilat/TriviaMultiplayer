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
    public partial class CreateRoom : Form
    {
        public CreateRoom()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (AreInputsValid())
            {
                string roomName = nameRoomTextBox.Text;
                int questionsAmount = int.Parse(amountQuestionsTextBox.Text);
                int questionTime = int.Parse(amountQuestionsTextBox.Text);
                int maxPlayers = int.Parse(maxPlayersTextBox.Text);

                TriviaClient client = TriviaClient.GetClient();
                JObject result = client.CreateRoom(roomName, maxPlayers, questionsAmount, questionTime);

                if ((int)result["code"] == TriviaClient.ERROR_CODE)
                {
                    MessageBox.Show(result["message"]["message"].ToString(), "Room ERROR", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    // msg for now, later will be form
                    Room room = new Room();
                    room.Show();
                    Close();
                }


            }
        }

        private void nameRoomTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Checks if the inputs are valid
        /// </summary>
        /// <returns>true if the inputs are valid</returns>
        private bool AreInputsValid()
        {
            string roomName = nameRoomTextBox.Text;
            string questionsAmount = amountQuestionsTextBox.Text;
            string questionTime = amountQuestionsTextBox.Text;
            string maxPlayers = maxPlayersTextBox.Text;
            if (roomName == "" || questionTime == "" || questionsAmount == "" || maxPlayers == "")
            {
                MessageBox.Show("Please fill all of the fields");
                return false;
            }

            if (int.TryParse(questionTime, out int questionTimeInt))
            {
                if (questionTimeInt < 6)
                {
                    MessageBox.Show("Question time must be at least 6 seconds");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Question time must be a number");
                return false;
            }

            if (int.TryParse(questionsAmount, out int questionsAmountInt))
            {
                if (questionsAmountInt < 3)
                {
                    MessageBox.Show("Questions Amount must be at least 3");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Questions Amount must be a number");
                return false;
            }

            if (int.TryParse(maxPlayers, out int maxPlayersInt))
            {
                if (maxPlayersInt < 2)
                {
                    MessageBox.Show("Max players must be at least 2");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Max players must be a number");
                return false;
            }
            return true;

        }

        private void maxPlayersTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void BackButtonPress_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            Close();
        }
    }
}
