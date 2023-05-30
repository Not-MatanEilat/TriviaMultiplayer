using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TriviaClientApp
{
    public partial class MainForm : Form
    {
        private static Panel? _placeholder = null;
        private static MainForm? instance = null;

        public static MainForm GetMainForm()
        {
            return instance;
        }

        public MainForm()
        {
            instance = this;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _placeholder = placeholder;
            Login login = new Login();
            placeholder.Controls.Add(login);
        }
        public static void ChangePage(UserControl UC)
        {
            foreach (Control control in _placeholder.Controls)
            {
                _placeholder.Controls.Remove(control);
                control.Dispose();
            }

            _placeholder.Controls.Add(UC);
        }
    }
}
