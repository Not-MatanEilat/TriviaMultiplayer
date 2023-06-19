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
    public partial class JoinRoom : Page
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

            List<Control> controls = new();
            TriviaClient client = TriviaClient.GetClient();
            JObject result = client.GetRoomsList();
            JToken rooms = result["message"]["rooms"];
            if (rooms != null)
            {
                int i = 0;
                foreach (JObject room in rooms)
                {
                    // create everything new for the group box
                    string roomName = room["name"].ToString();
                    int roomId = room["id"].Value<int>();
                    int players = room["currentPlayersAmount"].Value<int>();
                    int maxPlayers = room["maxPlayers"].Value<int>();
                    int questionCount = room["numOfQuestionsInGame"].Value<int>();
                    int timePerQuestion = room["timePerQuestion"].Value<int>();

                    RoomBox box = new RoomBox(roomName, roomId, players, maxPlayers, questionCount, timePerQuestion);

                    box.Location = new Point(GROUP_BOX_BASE_X, GROUP_BOX_BASE_Y + i * GROUP_BOX_MARGIN);
                    box.JoinRoomHandler += JoinRoom_Click;
                    controls.Add(box);


                    i++;
                }
            }


            try
            {
                Invoke(() =>
                {
                    DoubleBuffered = false;
                    roomsListFlow.Controls.AddRange(controls.ToArray());
                    refreshButton.Enabled = true;
                });
                mutex.ReleaseMutex();
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
            main.ChangePage(mainMenu);

        }

        private void JoinRoom_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            RoomBox box = (RoomBox)button.Parent;
            int roomId = box.RoomId;
            string roomName = box.RoomName;
            JoinRoomById(roomId, roomName, getRoomCreatorName(roomId));
        }
        /// <summary>
        /// Join a room by id
        /// </summary>
        /// <param name="roomId">the room id</param>
        public void JoinRoomById(int roomId, string roomName, string roomCreatorName)
        {
            TriviaClient client = TriviaClient.GetClient();
            JObject result = client.JoinRoom(roomId);
            // this for now until room form
            if (TriviaClient.IsSuccessResponse(result))
            {
                Room room = new Room(roomId, roomName, roomCreatorName);
                main.ChangePage(room);
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            Thread loader = new Thread(loadAllRooms);
            loader.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int roomId = (int)roomIdBox.Value;
            try
            {
                JoinRoomById(roomId, getRoomNameById(roomId), getRoomCreatorName(roomId));
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
        }

        /// <summary>
        /// Function will get the name of the room by the given id
        /// </summary>
        /// <param name="roomId">rooms id</param>
        /// <returns>string</returns>
        public string getRoomNameById(int roomId)
        {
            TriviaClient client = TriviaClient.GetClient();
            JObject result = client.GetRoomsList();
            JToken rooms = result["message"]["rooms"];
            if (rooms != null)
            {
                foreach (JObject room in rooms)
                {
                    if ((int)room["id"] == roomId)
                    {
                        return room["name"].ToString();
                    }
                }
            }
            return "";
        }

        /// <summary>
        /// Function will return the name of the creator of the room we are tryina join
        /// </summary>
        /// <param name="roomId">the id of the room</param>
        /// <returns>string</returns>
        public string getRoomCreatorName(int roomId)
        {
            TriviaClient client = TriviaClient.GetClient();
            JObject playersInRoom = client.GetPlayersInRoom(roomId);
            if (TriviaClient.IsSuccessResponse(playersInRoom))
            {
                string roomCreatorName = "";
                // if we'd have 0 players (somehow) we'd get an exception
                if (playersInRoom.Count != 0)
                {
                    roomCreatorName = playersInRoom["message"]["players"][0].ToString();
                }

                return roomCreatorName;
            }

            throw new Exception("Cannot Get Room Creator Name");
        }

        private void AutoRefresh_Tick(object sender, EventArgs e)
        {
            Thread loader = new Thread(loadAllRooms);
            loader.Start();
        }
    }

}
