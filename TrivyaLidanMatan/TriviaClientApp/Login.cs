using System.Diagnostics;
using System.Text.Json;
using Newtonsoft.Json.Linq;

namespace TriviaClientApp
{
    public partial class Login : UserControl
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

        private void loginButton_Click(object sender, EventArgs e)
        {
            JObject result = client.Login(usernameBox.Text, passwordBox.Text);
            
            if (TriviaClient.IsSuccessResponse(result))
            {
                MainMenu mainMenu = new MainMenu();
                MainForm.ChangePage(mainMenu);
            }
        }

        private void signupButton_Click(object sender, EventArgs e)
        {
            Signup signup = new Signup();
            MainForm.ChangePage(signup);
        }
    }
}