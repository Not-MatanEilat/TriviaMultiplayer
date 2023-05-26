using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TriviaClientApp
{
    public partial class JoinRoom : Form
    {

        public const int GROUP_BOX_WIDTH = 300;
        public const int GROUP_BOX_HEIGHT = 154;
        public const int GROUP_BOX_MARGIN = 160;
        public const int GROUP_BOX_BASE_X = 10;
        public const int GROUP_BOX_BASE_Y = 100;
        private Mutex mutex = new();

        public JoinRoom()
        {
            InitializeComponent();
        }

        private void JoinRoom_Load(object sender, EventArgs e)
        {
            Thread loader = new Thread(loadAllRooms);
            loader.Start();
        }

        public void loadAllRooms()
        {

            try
            {
                mutex.WaitOne();
                Invoke(() => roomsListFlow.Controls.Clear());
                Invoke(() => refreshButton.Enabled = false);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return;
            }

            TriviaClient client = TriviaClient.GetClient();
            JObject result = client.GetRoomsList();
            JToken rooms = result["message"]["rooms"];
            if (rooms != null)
            {
                int i = 0;
                foreach (JObject room in rooms)
                {
                    // create everything new for the group box
                    GroupBox groupBox = new GroupBox();

                    groupBox.Size = new Size(GROUP_BOX_WIDTH, GROUP_BOX_HEIGHT);


                    Label roomName = new Label();
                    Label roomPlayersAmount = new Label();
                    Label roomMaxPlayers = new Label();
                    Label roomQuestions = new Label();
                    Label roomId = new Label();
                    Button joinRoomButton = new Button();

                    // set all of the properties to the buttons/labels
                    int roomIdInt = (int)room["id"];
                    roomName.Text = room["name"].ToString();
                    int players = (int)room["currentPlayersAmount"];
                    roomPlayersAmount.Text = "Players: " + players;
                    roomMaxPlayers.Text = "Max Players: " + room["maxPlayers"];
                    roomQuestions.Text = "Questions Amount: " + room["numOfQuestionsInGame"];
                    roomId.Text = room["id"].ToString();


                    roomName.Location = new Point(10, 20);
                    roomPlayersAmount.Location = new Point(10, 40);
                    roomMaxPlayers.Location = new Point(10, 60);
                    roomQuestions.Location = new Point(10, 80);
                    roomId.Location = new Point(10, 100);
                    joinRoomButton.Location = new Point(10, 120);



                    // add them to the group box
                    groupBox.Controls.Add(roomId);
                    groupBox.Controls.Add(roomName);
                    groupBox.Controls.Add(roomPlayersAmount);
                    groupBox.Controls.Add(roomMaxPlayers);
                    groupBox.Controls.Add(roomQuestions);
                    groupBox.Controls.Add(joinRoomButton);

                    // set the properties to the join room groupbox button
                    joinRoomButton.Text = "Join Room";
                    joinRoomButton.Click += JoinRoom_Click;
                    joinRoomButton.TabIndex = 4 + i;


                    groupBox.Location = new Point(GROUP_BOX_BASE_X, GROUP_BOX_BASE_Y + i * GROUP_BOX_MARGIN);
                    try
                    {
                        Invoke(() => roomsListFlow.Controls.Add(groupBox));
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e.Message);
                        return;
                    }


                    i++;
                }
            }
            try
            {
                mutex.ReleaseMutex();
                Invoke(() => refreshButton.Enabled = true);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return;
            }
        }

        private void BackButtonPress_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            Close();

        }

        private void JoinRoom_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            GroupBox groupBox = (GroupBox)button.Parent;
            int roomId = int.Parse(groupBox.Controls[0].Text);
            JoinRoomById(roomId);
        }
        /// <summary>
        /// Join a room by id
        /// </summary>
        /// <param name="roomId">the room id</param>
        public void JoinRoomById(int roomId)
        {
            TriviaClient client = TriviaClient.GetClient();
            JObject result = client.JoinRoom(roomId);
            // this for now until room form
            if ((int)result["code"] == TriviaClient.ERROR_CODE)
            {
                MessageBox.Show(result["message"]["message"].ToString(), "Room ERROR", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Joined room successfully!");
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            Thread loader = new Thread(loadAllRooms);
            loader.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            JoinRoomById((int)roomIdBox.Value);
        }
    }

}
