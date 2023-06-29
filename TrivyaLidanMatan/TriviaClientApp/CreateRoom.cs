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
    public partial class CreateRoom : Page
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
            soundManager.PlayButtonClickSound();

            if (AreInputsValid())
            {
                string roomName = nameRoomTextBox.Text;
                int questionsAmount = (int)questionAmountBox.Value;
                int questionTime = (int)timePerQuestionBox.Value;
                int maxPlayers = (int)maxPlayersBox.Value;

                TriviaClient client = TriviaClient.GetClient();
                JObject result = client.CreateRoom(roomName, maxPlayers, questionsAmount, questionTime);

                if (TriviaClient.IsSuccessResponse(result))
                {
                    int roomId = (int)result["message"]["roomId"];
                    Room room = new Room(roomId, roomName, client.Username);
                    main.ChangePage(room);
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
            if (roomName == "")
            {
                MessageBox.Show("Please fill all of the fields");
                return false;
            }
            return true;

        }

        private void maxPlayersTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void BackButtonPress_Click(object sender, EventArgs e)
        {
            soundManager.PlayButtonClickSound();

            MainMenu mainMenu = new MainMenu();
            main.ChangePage(mainMenu);
        }

        private void Enter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }
    }
}
