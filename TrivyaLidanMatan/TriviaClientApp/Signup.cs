using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace TriviaClientApp
{
    public partial class Signup : Page
    {
        private string username;
        private string password;
        private string email;
        public Signup()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void signupButton_Click(object sender, EventArgs e)
        {
            username = usernameBox.Text;
            password = passwordBox.Text;
            email = emailBox.Text;

            TriviaClient client = TriviaClient.GetClient();

            JObject result = client.Signup(username, password, email);

            if (TriviaClient.IsSuccessResponse(result))
            {
                MainMenu menu = new MainMenu();
                main.ChangePage(menu);
            }

        }

        private void BackButtonPress_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            main.ChangePage(login);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void usernameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Enter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                signupButton_Click(sender, e);
            }
        }

        private void signupButton_Click_1(object sender, EventArgs e)
        {

        }
    }
}
