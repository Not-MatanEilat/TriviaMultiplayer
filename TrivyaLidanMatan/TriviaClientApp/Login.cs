using System.Diagnostics;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json.Linq;

namespace TriviaClientApp
{
    public partial class Login : Page
    {
        private TriviaClient client;
        private const string SECRET_SUPER_FILE_PATH = "SuperSecretTextFile.txt";
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = TriviaClient.GetClient();

            if (File.Exists(SECRET_SUPER_FILE_PATH))
            {
                rememberMeToggle.Checked = true;
                try
                {
                    string[] lines = File.ReadAllLines(SECRET_SUPER_FILE_PATH);
                    usernameBox.Text = lines[0];
                    passwordBox.Text = lines[1];
                }
                catch (IOException ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            soundManager.PlayButtonClickSound();

            JObject result = client.Login(usernameBox.Text, passwordBox.Text);

            if (TriviaClient.IsSuccessResponse(result))
            {
                if (rememberMeToggle.Checked)
                {
                    // write a new file called "SuperSecretTextFile"
                    File.WriteAllText(SECRET_SUPER_FILE_PATH, $"{usernameBox.Text}\n{passwordBox.Text}");
                }
                else
                {
                    File.Delete(SECRET_SUPER_FILE_PATH);
                }

                MainMenu mainMenu = new MainMenu();
                main.ChangePage(mainMenu);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void hopeToggle1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dungeonHeaderLabel1_Click(object sender, EventArgs e)
        {
            soundManager.PlayButtonClickSound();
            rememberMeToggle.Checked = !rememberMeToggle.Checked;
        }

        private void hereTextLink_Click(object sender, EventArgs e)
        {
            soundManager.PlayButtonClickSound();

            Signup signup = new Signup();
            main.ChangePage(signup);
        }

        private void Enter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginButton_Click(sender, e);
            }
        }
    }
}