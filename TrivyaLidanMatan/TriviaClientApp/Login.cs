using System.Diagnostics;
using System.Text.Json;

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
            Dictionary<string, object> res = client.Login(usernameBox.Text, passwordBox.Text);

            Dictionary<string, object> message = res["message"] as Dictionary<string, object>;
            if (message != null)
            {
                JsonElement element = (JsonElement)message["status"];
                int status = element.GetInt32();
                if (status == TriviaClient.SUCCESS_CODE)
                {
                    MessageBox.Show("Login Successful!");
                }
                else
                {
                    MessageBox.Show("Login Failed!");
                }
            }
            else
            {
                MessageBox.Show("Login Really Failed!");
            }
        }
    }
}