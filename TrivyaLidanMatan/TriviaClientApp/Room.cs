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

        private Mutex mutex = new();
        public Room()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Room_Load(object sender, EventArgs e)
        {
            Thread loader = new Thread(loadAllNames);
            loader.Start();
        }

        private void loadAllNames()
        {
            try
            {
                mutex.WaitOne();
                Invoke(() => namesListFlow.Controls.Clear());
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return;
            }

            TriviaClient client = TriviaClient.GetClient();
            JObject result = client.GetRoomState();

            JToken players = result["message"]["players"];

            if (players != null)
            {
                int i = 0;
                foreach (string player in players)
                {
                    Label playerLabel = new Label();
                    playerLabel.Text = player;
                    // change to consts later
                    playerLabel.Location = new Point(10, 20 + i * 20);

                    try
                    {
                        Invoke(() => namesListFlow.Controls.Add(playerLabel));
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e.Message);
                        return;
                    }

                    i++;

                }
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BackButtonPress_Click(object sender, EventArgs e)
        {
            TriviaClient client = TriviaClient.GetClient();

            JObject result = client.LeaveRoom();

            if ((int)result["code"] == TriviaClient.ERROR_CODE)
            {
                MessageBox.Show(result["message"]["message"].ToString(), "Room ERROR", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                MainMenu mainMenu = new MainMenu();
                mainMenu.Show();
                Close();
            }
            
        }
    }
}
