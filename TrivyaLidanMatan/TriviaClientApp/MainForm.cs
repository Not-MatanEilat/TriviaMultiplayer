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
            Login login = new Login();
            placeholder.Controls.Add(login);
        }
        public void ChangePage(UserControl UC)
        {
            foreach (Control control in placeholder.Controls)
            {
                placeholder.Controls.Remove(control);
                control.Dispose();
            }

            placeholder.Controls.Add(UC);
        }
    }
}
