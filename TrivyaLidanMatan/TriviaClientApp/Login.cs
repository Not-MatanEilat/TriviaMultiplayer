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
            
            if (TriviaClient.IsSuccessResponse(result))
            {
                MainMenu mainMenu = new MainMenu();
                mainMenu.Show();
                Close();
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