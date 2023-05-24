using System.Diagnostics;

namespace TriviaClientApp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TriviaClient client = TriviaClient.GetClient();
            var res = client.Login("lidan", "error12#$");
            Dictionary<string, object> msg = res["message"] as Dictionary<string, object>;
            if (msg != null)
            {
                Debug.WriteLine(msg["status"]);
            }
            
        }
    }
}