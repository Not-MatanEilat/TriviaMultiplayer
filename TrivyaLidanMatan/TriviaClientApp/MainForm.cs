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

        /// <summary>
        /// get the main form
        /// </summary>
        /// <returns>the main form</returns>
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
        /// <summary>
        /// Changes the page to the given page
        /// </summary>
        /// <param name="page">the page to change to</param>
        public void ChangePage(Page page)
        {
            foreach (Control control in placeholder.Controls)
            {
                placeholder.Controls.Remove(control);
                control.Dispose();
            }

            placeholder.Controls.Add(page);
        }
    }
}
