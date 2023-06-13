using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bootstrap.BSControl;
using CustomControls.RJControls;
using ReaLTaiizor.Controls;

namespace TriviaClientApp
{
    public partial class MainMenu : Page
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
            main.ChangePage(createRoom);
        }

        private void JoinRoomButton_Click(object sender, EventArgs e)
        {
            JoinRoom joinRoom = new JoinRoom();
            main.ChangePage(joinRoom);


        }

        private void createQuestionButton_Click(object sender, EventArgs e)
        {
            CreateQuestion createQuestion = new CreateQuestion();
            main.ChangePage(createQuestion);
        }

        private void StatisticsButton_Click(object sender, EventArgs e)
        {
            Statistics statistics = new Statistics();
            main.ChangePage(statistics);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            main.Close();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            TriviaClient.GetClient().Logout();
            Login login = new Login();
            main.ChangePage(login);
        }

        private void headToHeadButton_Click(object sender, EventArgs e)
        {
            TriviaClient.GetClient().JoinHeadToHead();
            HeadToHeadWaitingRoom headToHeadWaitingRoom = new HeadToHeadWaitingRoom();
            main.ChangePage(headToHeadWaitingRoom);
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
        }

        private void backButton_Click(object sender, EventArgs e)
        {

        }
    }
}

