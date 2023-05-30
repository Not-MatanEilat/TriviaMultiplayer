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
        private Mutex mutex = new();
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
            Thread loader = new Thread(loadAllNames);
            loader.Start();

            roomNameLabel.Text = roomName;

            roomCreatorNameLabel.Text = roomCreatorName + "' Room";

            roomIdLabel.Text = roomId.ToString();

        }

        /// <summary>
        /// load all the names of the players in the room
        /// </summary>
        private void loadAllNames()
        {
            try
            {
                mutex.WaitOne();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return;
            }

            TriviaClient client = TriviaClient.GetClient();
            JObject result = client.GetRoomState();
            if (!TriviaClient.IsSuccessResponse(result, false))
            {
                try
                {
                    Invoke(() =>
                    {
                        MainMenu mainMenu = new MainMenu();
                        main.ChangePage(mainMenu);
                    });

                    mutex.ReleaseMutex();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
                
                return;
            }

            JToken playersJson = result["message"]["players"];
            players.Clear();
            List<Control> controls = new();

            if (playersJson != null)
            {
                int i = 0;
                foreach (string player in playersJson)
                {
                    if (i == 0)
                    {
                        roomCreatorName = player;
                    }
                    Label playerLabel = new Label();
                    playerLabel.Text = player;
                    // change to consts later
                    playerLabel.Location = new Point(PLAYER_LABEL_BASE_X, PLAYER_LABEL_BASE_Y + i * PLAYER_LABEL_MARGIN);

                    controls.Add(playerLabel);

                    i++;
                    players.Add(player);
                }
            }

            try
            {
                Invoke(() =>
                {
                    DoubleBuffered = false;
                    namesListFlow.Controls.Clear();
                    namesListFlow.Controls.AddRange(controls.ToArray());
                });

                mutex.ReleaseMutex();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return;
            }
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
                // this is for checking if the player is an admin, the admin is always the first player in the current room
                if (client.Username == players[0])
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
            Thread loader = new Thread(loadAllNames);
            loader.Start();
        }
    }
}
