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
    public partial class JoinRoom : Form
    {

        public const int GROUP_BOX_WIDTH = 300;
        public const int GROUP_BOX_HEIGHT = 154;
        public const int GROUP_BOX_MARGIN = 160;

        public JoinRoom()
        {
            InitializeComponent();
        }

        private void JoinRoom_Load(object sender, EventArgs e)
        {
            loadAllRooms();
        }

        public void loadAllRooms()
        {
            roomsListFlow.Controls.Clear();

            TriviaClient client = TriviaClient.GetClient();
            JObject rooms = client.GetRoomsList();
            int i = 0;
            foreach (JObject room in rooms["message"]["rooms"])
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
                roomPlayersAmount.Text = "Players: " + client.GetPlayersInRoom(roomIdInt).Count;
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


                groupBox.Location = new Point(10, 100 + i * GROUP_BOX_MARGIN);


                roomsListFlow.Controls.Add(groupBox);

                i++;
            }

        }

        private void JoinRoomButton_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
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
            TriviaClient client = TriviaClient.GetClient();
            JObject result = client.JoinRoom(roomId);
            // this for now until room form
            if ((int) result["code"] == TriviaClient.ERROR_CODE)
            {
                MessageBox.Show(result["message"]["message"].ToString(), "Room ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Joined room successfully!");
            }
        }
    }

}
