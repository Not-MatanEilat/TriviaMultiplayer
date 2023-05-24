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
    public partial class MainMenu : Form
    {

        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            string username = TriviaClient.GetClient().Username;
            userConnected.Text = "Connected as: " + username;
        }

        private void CreateRoomButton_Click(object sender, EventArgs e)
        {
            CreateRoom createRoom = new CreateRoom();
            createRoom.Show();
            Close();
        }

        private void JoinRoomButton_Click(object sender, EventArgs e)
        {
            JoinRoom joinRoom = new JoinRoom();
            joinRoom.Show();
            Close();

        }
    }
}
