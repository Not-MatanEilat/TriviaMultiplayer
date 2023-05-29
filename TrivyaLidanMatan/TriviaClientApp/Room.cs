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
    public partial class Room : Form
    {
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
                        mainMenu.Show();
                        Close();
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
                    playerLabel.Location = new Point(10, 20 + i * 20);

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
                if (client.Username == players[0])
                {
                    result = client.CloseRoom();
                }
                else
                {
                    result = client.LeaveRoom();
                }

                if ((int)result["code"] == TriviaClient.ERROR_CODE)
                {
                    MessageBox.Show(result["message"]["message"].ToString(), "Room ERROR", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                MainMenu mainMenu = new MainMenu();
                mainMenu.Show();
                Close();
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
