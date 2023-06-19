namespace TriviaClientApp
{
    partial class HighScore
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            highScores = new Label();
            BackButtonPress = new ReaLTaiizor.Controls.RoyalButton();
            SuspendLayout();
            // 
            // highScores
            // 
            highScores.AutoSize = true;
            highScores.Font = new Font("Berlin Sans FB Demi", 16F, FontStyle.Regular, GraphicsUnit.Point);
            highScores.Location = new Point(288, 97);
            highScores.Name = "highScores";
            highScores.Size = new Size(124, 25);
            highScores.TabIndex = 8;
            highScores.Text = "High Scores";
            // 
            // BackButtonPress
            // 
            BackButtonPress.BackColor = Color.FromArgb(243, 243, 243);
            BackButtonPress.BorderColor = Color.FromArgb(180, 180, 180);
            BackButtonPress.BorderThickness = 3;
            BackButtonPress.DrawBorder = true;
            BackButtonPress.Font = new Font("Berlin Sans FB Demi", 11F, FontStyle.Regular, GraphicsUnit.Point);
            BackButtonPress.ForeColor = Color.FromArgb(31, 31, 31);
            BackButtonPress.HotTrackColor = Color.FromArgb(221, 221, 221);
            BackButtonPress.Image = null;
            BackButtonPress.LayoutFlags = ReaLTaiizor.Util.RoyalLayoutFlags.ImageBeforeText;
            BackButtonPress.Location = new Point(14, 398);
            BackButtonPress.Name = "BackButtonPress";
            BackButtonPress.PressedColor = Color.FromArgb(243, 243, 243);
            BackButtonPress.PressedForeColor = Color.Black;
            BackButtonPress.Size = new Size(114, 40);
            BackButtonPress.TabIndex = 11;
            BackButtonPress.Text = "Back";
            BackButtonPress.Click += BackButtonPress_Click;
            // 
            // HighScore
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CornflowerBlue;
            Controls.Add(BackButtonPress);
            Controls.Add(highScores);
            Name = "HighScore";
            Load += HighScore_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label highScores;
        private ReaLTaiizor.Controls.RoyalButton BackButtonPress;
    }
}