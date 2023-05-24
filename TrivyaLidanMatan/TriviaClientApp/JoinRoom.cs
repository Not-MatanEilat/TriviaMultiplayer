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
            TriviaClient client = TriviaClient.GetClient();
            JObject rooms = client.GetRoomsList();
            int i = 0;

        }

        private void BackButtonPress_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            Close();

        }
    }

}
