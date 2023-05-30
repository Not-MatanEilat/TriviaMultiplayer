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
    public partial class MainMenu : UserControl
    {

        public MainMenu()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            string username = TriviaClient.GetClient().Username;
            userConnected.Text = "Connected as: " + username;
        }

        private void CreateRoomButton_Click(object sender, EventArgs e)
        {
            CreateRoom createRoom = new CreateRoom();
            MainForm.ChangePage(createRoom);
        }

        private void JoinRoomButton_Click(object sender, EventArgs e)
        {
            JoinRoom joinRoom = new JoinRoom();
            MainForm.ChangePage(joinRoom);


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Statistics statistics = new Statistics();
            MainForm.ChangePage(statistics);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainForm.GetMainForm().Close();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            TriviaClient.GetClient().Logout();
            Login login = new Login();
            MainForm.ChangePage(login);
        }
    }
}
