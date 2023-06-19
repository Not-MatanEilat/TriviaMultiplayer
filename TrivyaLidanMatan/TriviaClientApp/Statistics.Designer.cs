namespace TriviaClientApp
{
    partial class Statistics
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
            myStats = new Label();
            highScoreButton = new ReaLTaiizor.Controls.ParrotButton();
            BackButtonPress = new ReaLTaiizor.Controls.RoyalButton();
            SuspendLayout();
            // 
            // myStats
            // 
            myStats.AutoSize = true;
            myStats.Font = new Font("Berlin Sans FB Demi", 16F, FontStyle.Regular, GraphicsUnit.Point);
            myStats.Location = new Point(222, 50);
            myStats.Name = "myStats";
            myStats.Size = new Size(107, 25);
            myStats.TabIndex = 0;
            myStats.Text = "MY STATS";
            // 
            // highScoreButton
            // 
            highScoreButton.BackgroundColor = Color.FromArgb(255, 255, 255);
            highScoreButton.ButtonImage = null;
            highScoreButton.ButtonStyle = ReaLTaiizor.Controls.ParrotButton.Style.MaterialRounded;
            highScoreButton.ButtonText = "High Score";
            highScoreButton.ClickBackColor = Color.FromArgb(195, 195, 195);
            highScoreButton.ClickTextColor = Color.Black;
            highScoreButton.CornerRadius = 16;
            highScoreButton.Font = new Font("Berlin Sans FB Demi", 11.2F, FontStyle.Regular, GraphicsUnit.Point);
            highScoreButton.Horizontal_Alignment = StringAlignment.Center;
            highScoreButton.HoverBackgroundColor = Color.FromArgb(225, 225, 225);
            highScoreButton.HoverTextColor = Color.Black;
            highScoreButton.ImagePosition = ReaLTaiizor.Controls.ParrotButton.ImgPosition.Left;
            highScoreButton.Location = new Point(332, 398);
            highScoreButton.Name = "highScoreButton";
            highScoreButton.Size = new Size(166, 40);
            highScoreButton.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            highScoreButton.TabIndex = 12;
            highScoreButton.TextColor = Color.Black;
            highScoreButton.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            highScoreButton.Vertical_Alignment = StringAlignment.Center;
            highScoreButton.Click += button1_Click;
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
            BackButtonPress.TabIndex = 13;
            BackButtonPress.Text = "Back";
            BackButtonPress.Click += BackButtonPress_Click;
            // 
            // Statistics
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.RoyalBlue;
            Controls.Add(myStats);
            Controls.Add(highScoreButton);
            Controls.Add(BackButtonPress);
            Name = "Statistics";
            Load += Statistics_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label myStats;
        private ReaLTaiizor.Controls.ParrotButton highScoreButton;
        private ReaLTaiizor.Controls.RoyalButton BackButtonPress;
    }
}