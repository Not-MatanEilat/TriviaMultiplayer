using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReaLTaiizor.Controls;

namespace TriviaClientApp
{
    public partial class Page : UserControl
    {
        public MainForm main;
        public SoundManager soundManager;

        public Page()
        {
            main = MainForm.GetMainForm();
            soundManager = SoundManager.GetSoundManager();
            InitializeComponent();
        }

        public void InvokeSafe(Action action)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(action);
                }
                else
                {
                    action();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }
    }
}
