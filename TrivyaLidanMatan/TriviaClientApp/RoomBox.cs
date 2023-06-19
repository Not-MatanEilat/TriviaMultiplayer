using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TriviaClientApp
{
    public partial class RoomBox : UserControl
    {
        public string RoomName { get; set; }
        public int RoomId { get; set; }
        public int Players { get; set; }
        public int MaxPlayers { get; set; }
        public int QuestionAmount { get; set; }
        public int TimePerQuestion { get; set; }
        public EventHandler JoinRoomHandler { get; set; }

        public RoomBox(string roomName, int roomId, int players, int maxPlayers, int questionAmount, int timePerQuestion)
        {
            InitializeComponent();
            RoomName = roomName;
            RoomId = roomId;
            Players = players;
            MaxPlayers = maxPlayers;
            QuestionAmount = questionAmount;
            TimePerQuestion = timePerQuestion;
        }

        private void RoomBox_Load(object sender, EventArgs e)
        {
            applyPlaceHoldersToControls();
        }

        public void applyPlaceHoldersToControls()
        {
            foreach (Control control in Controls)
            {
                control.Text = applyPlaceHolders(control.Text);
            }
        }

        public string applyPlaceHolders(string text)
        {
            text = text.Replace("{roomName}", RoomName);
            text = text.Replace("{roomId}", RoomId.ToString());
            text = text.Replace("{players}", Players.ToString());
            text = text.Replace("{maxPlayers}", MaxPlayers.ToString());
            text = text.Replace("{questionAmount}", QuestionAmount.ToString());
            text = text.Replace("{timePerQuestion}", TimePerQuestion.ToString());
            return text;
        }

        private void joinButton_Click(object sender, EventArgs e)
        {
            JoinRoomHandler.Invoke(sender, e);
        }
    }
}
