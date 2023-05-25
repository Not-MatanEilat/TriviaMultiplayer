using System.Diagnostics;
using System.Text.Json;
using Newtonsoft.Json.Linq;

namespace TriviaClientApp
{
    public partial class Login : Form
    {
        private TriviaClient client;
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = TriviaClient.GetClient();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            JObject result = client.Login(usernameBox.Text, passwordBox.Text);

            if (result["message"] != null)
            {
                int status = (int)result["code"];
                if (status != TriviaClient.ERROR_CODE)
                {
                    MainMenu mainMenu = new MainMenu();
                    mainMenu.Show();
                    Close();
                }
                else
                {
                     MessageBox.Show(result["message"]["message"].ToString(), "Login ERROR", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Login Really Failed!");
            }
        }

        private void signupButton_Click(object sender, EventArgs e)
        {
            Signup signup = new Signup();
            signup.Show();
            Close();
        }
    }
}