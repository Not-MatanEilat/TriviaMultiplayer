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
    public partial class Statistics : UserControl
    {
        public Statistics()
        {
            InitializeComponent();
        }

        private void Statistics_Load(object sender, EventArgs e)
        {
            JObject result = TriviaClient.GetClient().GetPersonalStats();
            JArray stats = (JArray)result["message"]["statistics"];
            stats.Insert(0, "Your Statistics:");
            string statsStr = String.Join("\n", stats);
            myStats.Text = statsStr;
        }

        private void BackButtonPress_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            MainForm.ChangePage(mainMenu);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HighScore menu = new HighScore();
            MainForm.ChangePage(menu);
        }
    }
}
