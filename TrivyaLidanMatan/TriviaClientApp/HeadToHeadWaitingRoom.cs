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
    public partial class HeadToHeadWaitingRoom : Page
    {
        private RoomData? roomData = null;
        private int countdownTimer = 5;
        public HeadToHeadWaitingRoom()
        {
            InitializeComponent();
        }

        private void getState_Tick(object sender, EventArgs e)
        {
            JObject result = TriviaClient.GetClient().getHeadToHeadState();

            if (TriviaClient.IsSuccessResponse(result, false))
            {
                if (result["message"]["hasGameBegun"].ToObject<bool>())
                {
                    countdownStartGameTimer.Enabled = true;
                    countdownStartGameTimer.Start();


                    roomData = new RoomData();

                    roomData.hasGameBegun = result["message"]["hasGameBegun"].ToObject<bool>();
                    roomData.players = result["message"]["players"].ToObject<List<string>>();
                    roomData.questionCount = result["message"]["questionsAmount"].ToObject<int>();
                    roomData.status = result["message"]["status"].ToObject<int>();
                    roomData.answerTimeout = result["message"]["timePerQuestion"].ToObject<int>();

                    topText.Text = "Game is starting in " + countdownTimer + " seconds";
                }
            }
        }

        private void BackButtonPress_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            main.ChangePage(mainMenu);
        }

        private void countdownStartGameTimer_Tick(object sender, EventArgs e)
        {
            countdownTimer--;
            topText.Text = "Game is starting in " + countdownTimer + " seconds";
            if (countdownTimer == 0)
            {
                if (roomData == null)
                {
                    MessageBox.Show("Something just went wrong");
                }
                else
                {
                    Game game = new Game(roomData, roomData.answerTimeout);
                    main.ChangePage(game);
                }
            }
        }
    }
}
