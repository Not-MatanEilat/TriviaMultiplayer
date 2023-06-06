using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace TriviaClientApp
{
    public partial class Room : Page
    {
        private const int PLAYER_LABEL_BASE_X = 10;
        private const int PLAYER_LABEL_BASE_Y = 20;
        private const int PLAYER_LABEL_MARGIN = 20;

        private string roomName;
        private List<string> players = new();
        private string roomCreatorName;
        private int roomId;
        public Room(int roomId, string roomName, string roomCreatorName)
        {
            InitializeComponent();
            this.roomName = roomName;
            this.roomCreatorName = roomCreatorName;
            this.roomId = roomId;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Room_Load(object sender, EventArgs e)
        {
            Thread loader = new Thread(roomHandler);
            loader.Start();

            roomNameLabel.Text = roomName;

            roomCreatorNameLabel.Text = roomCreatorName + "' Room";

            roomIdLabel.Text = roomId.ToString();

            if (IsAdmin())
            {
                startGameButton.Visible = true;
            }
            else
            {
                startGameButton.Visible = false;
            }
        }

        /// <summary>
        /// load all the names of the players in the room
        /// </summary>
        /// <param name="roomState">The current state of the room</param>
        private void LoadAllNames(JObject roomState)
        {

            if (!TriviaClient.IsSuccessResponse(roomState, false))
            {
                InvokeSafe(() =>
                {
                    MainMenu mainMenu = new MainMenu();
                    main.ChangePage(mainMenu);
                });

                return;
            }

            JToken playersJson = roomState["message"]["players"];
            players.Clear();
            List<Control> controls = new();

            if (playersJson != null)
            {
                int i = 0;
                foreach (string player in playersJson)
                {
                    Label playerLabel = new Label();
                    playerLabel.Text = player;
                    playerLabel.Location = new Point(PLAYER_LABEL_BASE_X, PLAYER_LABEL_BASE_Y + i * PLAYER_LABEL_MARGIN);
                    if (i == 0)
                    {
                        roomCreatorName = player;
                        playerLabel.Text += "👑";
                    }

                    controls.Add(playerLabel);

                    i++;
                    players.Add(player);
                }
            }
            InvokeSafe(() =>
            {
                DoubleBuffered = false;
                namesListFlow.Controls.Clear();
                namesListFlow.Controls.AddRange(controls.ToArray());
            });

        }

        /// <summary>
        /// Function to check if the game has begun, if it did begin, go into its page's
        /// </summary>
        /// <param name="roomState">The current state of the room</param>
        private void CheckGameHasBegun(JObject roomState)
        {
            if (roomState["message"]["hasGameBegun"].Value<bool>())
            {
                InvokeSafe(() =>
                {
                    main.ChangePage(new Game());
                });
            }
        }

        /// <summary>
        /// functions that happens on each clock timer (3 seconds)
        /// </summary>
        private void roomHandler()
        {
            TriviaClient client = TriviaClient.GetClient();
            JObject result = client.GetRoomState();

            LoadAllNames(result);
            CheckGameHasBegun(result);
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BackButtonPress_Click(object sender, EventArgs e)
        {
            TriviaClient client = TriviaClient.GetClient();

            JObject result;

            if (players.Count == 0)
            {
                MessageBox.Show("Something went wrong", "Room ERROR", MessageBoxButtons.OK,
                                       MessageBoxIcon.Error);
            }
            else
            {
                if (IsAdmin())
                {
                    client.CloseRoom();
                }
                else
                {
                    client.LeaveRoom();
                }

                MainMenu mainMenu = new MainMenu();
                main.ChangePage(mainMenu);
            }


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void roomCreatorNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void autoRefresh_Tick(object sender, EventArgs e)
        {
            Thread loader = new Thread(roomHandler);
            loader.Start();
        }

        /// <summary>
        /// Returns true or false based on if the current player is the admin of the room
        /// </summary>
        /// <returns>True Or False</returns>
        private bool IsAdmin()
        {
            return roomCreatorName == TriviaClient.GetClient().Username;
        }

        private void startGameButton_Click(object sender, EventArgs e)
        {
            startGameButton.Enabled = false;
            TriviaClient.GetClient().StartGame();
            Thread.Sleep(500);
            main.ChangePage(new Game());
        }
    }
}
