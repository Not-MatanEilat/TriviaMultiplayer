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

        public Page()
        {
            main = MainForm.GetMainForm();
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

        /// <summary>
        /// Will return a new parrot button in a style I made
        /// </summary>
        /// <param name="name">the name of button</param>
        /// <returns>The button made</returns>
        public static ParrotButton CreateNewParrotButton(string name)
        {
            ParrotButton button = new ParrotButton();
            button.BackgroundColor = Color.FromArgb(255, 255, 255);
            button.ButtonImage = null;
            button.ButtonStyle = ReaLTaiizor.Controls.ParrotButton.Style.MaterialRounded;
            button.ClickBackColor = Color.FromArgb(195, 195, 195);
            button.ClickTextColor = Color.Black;
            button.CornerRadius = 13;
            button.Font = new Font("Berlin Sans FB Demi", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button.Horizontal_Alignment = StringAlignment.Center;
            button.HoverBackgroundColor = Color.FromArgb(225, 225, 225);
            button.HoverTextColor = Color.Black;
            button.ImagePosition = ReaLTaiizor.Controls.ParrotButton.ImgPosition.Left;
            button.Location = new Point(339, 255);
            button.Name = name;
            button.Size = new Size(112, 31);
            button.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            button.TabIndex = 8;
            button.TextColor = Color.Black;
            button.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            button.Vertical_Alignment = StringAlignment.Center;

            return button;
        }
    }
}
