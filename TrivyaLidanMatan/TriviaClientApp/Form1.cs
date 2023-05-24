using System.Diagnostics;

namespace TriviaClientApp
{
    public partial class Form1 : Form
    {
        private TriviaClient client;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new TriviaClient();
            client.Connect();
            var res = client.Login("lidan", "error12#$");
            Dictionary<string, object> msg = res["message"] as Dictionary<string, object>;
            if (msg != null)
            {
                Debug.WriteLine(msg["status"]);
            }
            
        }
    }
}