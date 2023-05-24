using System.Diagnostics;

namespace TriviaClientApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TriviaClient client = new TriviaClient();
            Dictionary<string, object> dict = new Dictionary<string, object>
            {
                {"username", "david"},
                {"password", "123456"}
            };
            List<byte> msg = client.BuildMessageList(1, "Hello");
            Debug.WriteLine(msg.ToString());
        }
    }
}