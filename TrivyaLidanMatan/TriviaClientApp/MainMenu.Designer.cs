namespace TriviaClientApp
{
    partial class MainMenu
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
            label1 = new Label();
            userConnected = new Label();
            logoutButton = new Button();
            statisticsButton = new ReaLTaiizor.Controls.ParrotButton();
            exitButton = new ReaLTaiizor.Controls.ParrotButton();
            createQuestionButton = new ReaLTaiizor.Controls.ParrotButton();
            headToHeadButton = new ReaLTaiizor.Controls.ParrotButton();
            joinRoomButton = new ReaLTaiizor.Controls.ParrotButton();
            createRoomButton = new ReaLTaiizor.Controls.ParrotButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(328, 33);
            label1.Name = "label1";
            label1.Size = new Size(137, 65);
            label1.TabIndex = 0;
            label1.Text = "Trivia";
            // 
            // userConnected
            // 
            userConnected.AutoSize = true;
            userConnected.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            userConnected.Location = new Point(328, 98);
            userConnected.Name = "userConnected";
            userConnected.Size = new Size(145, 21);
            userConnected.TabIndex = 2;
            userConnected.Text = "Connected as: error";
            // 
            // logoutButton
            // 
            logoutButton.Location = new Point(12, 415);
            logoutButton.Name = "logoutButton";
            logoutButton.Size = new Size(75, 23);
            logoutButton.TabIndex = 5;
            logoutButton.Text = "Logout";
            logoutButton.UseVisualStyleBackColor = true;
            logoutButton.Click += logoutButton_Click;
            // 
            // statisticsButton
            // 
            statisticsButton.BackgroundColor = Color.FromArgb(255, 255, 255);
            statisticsButton.ButtonImage = null;
            statisticsButton.ButtonStyle = ReaLTaiizor.Controls.ParrotButton.Style.MaterialRounded;
            statisticsButton.ButtonText = "Statistics";
            statisticsButton.ClickBackColor = Color.FromArgb(195, 195, 195);
            statisticsButton.ClickTextColor = Color.Black;
            statisticsButton.CornerRadius = 13;
            statisticsButton.Font = new Font("Berlin Sans FB Demi", 9F, FontStyle.Regular, GraphicsUnit.Point);
            statisticsButton.Horizontal_Alignment = StringAlignment.Center;
            statisticsButton.HoverBackgroundColor = Color.FromArgb(225, 225, 225);
            statisticsButton.HoverTextColor = Color.Black;
            statisticsButton.ImagePosition = ReaLTaiizor.Controls.ParrotButton.ImgPosition.Left;
            statisticsButton.Location = new Point(659, 365);
            statisticsButton.Name = "statisticsButton";
            statisticsButton.Size = new Size(112, 31);
            statisticsButton.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            statisticsButton.TabIndex = 8;
            statisticsButton.TextColor = Color.Black;
            statisticsButton.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            statisticsButton.Vertical_Alignment = StringAlignment.Center;
            statisticsButton.Click += StatisticsButton_Click;
            // 
            // exitButton
            // 
            exitButton.BackgroundColor = Color.FromArgb(255, 255, 255);
            exitButton.ButtonImage = null;
            exitButton.ButtonStyle = ReaLTaiizor.Controls.ParrotButton.Style.MaterialRounded;
            exitButton.ButtonText = "Exit";
            exitButton.ClickBackColor = Color.FromArgb(195, 195, 195);
            exitButton.ClickTextColor = Color.Black;
            exitButton.CornerRadius = 13;
            exitButton.Font = new Font("Berlin Sans FB Demi", 9F, FontStyle.Regular, GraphicsUnit.Point);
            exitButton.Horizontal_Alignment = StringAlignment.Center;
            exitButton.HoverBackgroundColor = Color.FromArgb(225, 225, 225);
            exitButton.HoverTextColor = Color.Black;
            exitButton.ImagePosition = ReaLTaiizor.Controls.ParrotButton.ImgPosition.Left;
            exitButton.Location = new Point(659, 402);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(112, 31);
            exitButton.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            exitButton.TabIndex = 8;
            exitButton.TextColor = Color.Black;
            exitButton.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            exitButton.Vertical_Alignment = StringAlignment.Center;
            exitButton.Click += exitButton_Click;
            // 
            // createQuestionButton
            // 
            createQuestionButton.BackgroundColor = Color.FromArgb(255, 255, 255);
            createQuestionButton.ButtonImage = null;
            createQuestionButton.ButtonStyle = ReaLTaiizor.Controls.ParrotButton.Style.MaterialRounded;
            createQuestionButton.ButtonText = "Create Question";
            createQuestionButton.ClickBackColor = Color.FromArgb(195, 195, 195);
            createQuestionButton.ClickTextColor = Color.Black;
            createQuestionButton.CornerRadius = 13;
            createQuestionButton.Font = new Font("Berlin Sans FB Demi", 9F, FontStyle.Regular, GraphicsUnit.Point);
            createQuestionButton.Horizontal_Alignment = StringAlignment.Center;
            createQuestionButton.HoverBackgroundColor = Color.FromArgb(225, 225, 225);
            createQuestionButton.HoverTextColor = Color.Black;
            createQuestionButton.ImagePosition = ReaLTaiizor.Controls.ParrotButton.ImgPosition.Left;
            createQuestionButton.Location = new Point(659, 328);
            createQuestionButton.Name = "createQuestionButton";
            createQuestionButton.Size = new Size(112, 31);
            createQuestionButton.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            createQuestionButton.TabIndex = 8;
            createQuestionButton.TextColor = Color.Black;
            createQuestionButton.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            createQuestionButton.Vertical_Alignment = StringAlignment.Center;
            createQuestionButton.Click += createQuestionButton_Click;
            // 
            // headToHeadButton
            // 
            headToHeadButton.BackgroundColor = Color.FromArgb(255, 255, 255);
            headToHeadButton.ButtonImage = null;
            headToHeadButton.ButtonStyle = ReaLTaiizor.Controls.ParrotButton.Style.MaterialRounded;
            headToHeadButton.ButtonText = "Head To Head";
            headToHeadButton.ClickBackColor = Color.FromArgb(195, 195, 195);
            headToHeadButton.ClickTextColor = Color.Black;
            headToHeadButton.CornerRadius = 16;
            headToHeadButton.Font = new Font("Berlin Sans FB Demi", 11.2F, FontStyle.Regular, GraphicsUnit.Point);
            headToHeadButton.Horizontal_Alignment = StringAlignment.Center;
            headToHeadButton.HoverBackgroundColor = Color.FromArgb(225, 225, 225);
            headToHeadButton.HoverTextColor = Color.Black;
            headToHeadButton.ImagePosition = ReaLTaiizor.Controls.ParrotButton.ImgPosition.Left;
            headToHeadButton.Location = new Point(328, 171);
            headToHeadButton.Name = "headToHeadButton";
            headToHeadButton.Size = new Size(137, 36);
            headToHeadButton.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            headToHeadButton.TabIndex = 8;
            headToHeadButton.TextColor = Color.Black;
            headToHeadButton.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            headToHeadButton.Vertical_Alignment = StringAlignment.Center;
            headToHeadButton.Click += headToHeadButton_Click;
            // 
            // joinRoomButton
            // 
            joinRoomButton.BackgroundColor = Color.FromArgb(255, 255, 255);
            joinRoomButton.ButtonImage = null;
            joinRoomButton.ButtonStyle = ReaLTaiizor.Controls.ParrotButton.Style.MaterialRounded;
            joinRoomButton.ButtonText = "Join Room";
            joinRoomButton.ClickBackColor = Color.FromArgb(195, 195, 195);
            joinRoomButton.ClickTextColor = Color.Black;
            joinRoomButton.CornerRadius = 16;
            joinRoomButton.Font = new Font("Berlin Sans FB Demi", 11.2F, FontStyle.Regular, GraphicsUnit.Point);
            joinRoomButton.Horizontal_Alignment = StringAlignment.Center;
            joinRoomButton.HoverBackgroundColor = Color.FromArgb(225, 225, 225);
            joinRoomButton.HoverTextColor = Color.Black;
            joinRoomButton.ImagePosition = ReaLTaiizor.Controls.ParrotButton.ImgPosition.Left;
            joinRoomButton.Location = new Point(328, 213);
            joinRoomButton.Name = "joinRoomButton";
            joinRoomButton.Size = new Size(137, 36);
            joinRoomButton.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            joinRoomButton.TabIndex = 8;
            joinRoomButton.TextColor = Color.Black;
            joinRoomButton.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            joinRoomButton.Vertical_Alignment = StringAlignment.Center;
            joinRoomButton.Click += JoinRoomButton_Click;
            // 
            // createRoomButton
            // 
            createRoomButton.BackgroundColor = Color.FromArgb(255, 255, 255);
            createRoomButton.ButtonImage = null;
            createRoomButton.ButtonStyle = ReaLTaiizor.Controls.ParrotButton.Style.MaterialRounded;
            createRoomButton.ButtonText = "Create Room";
            createRoomButton.ClickBackColor = Color.FromArgb(195, 195, 195);
            createRoomButton.ClickTextColor = Color.Black;
            createRoomButton.CornerRadius = 16;
            createRoomButton.Font = new Font("Berlin Sans FB Demi", 11.2F, FontStyle.Regular, GraphicsUnit.Point);
            createRoomButton.Horizontal_Alignment = StringAlignment.Center;
            createRoomButton.HoverBackgroundColor = Color.FromArgb(225, 225, 225);
            createRoomButton.HoverTextColor = Color.Black;
            createRoomButton.ImagePosition = ReaLTaiizor.Controls.ParrotButton.ImgPosition.Left;
            createRoomButton.Location = new Point(328, 255);
            createRoomButton.Name = "createRoomButton";
            createRoomButton.Size = new Size(137, 36);
            createRoomButton.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            createRoomButton.TabIndex = 8;
            createRoomButton.TextColor = Color.Black;
            createRoomButton.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            createRoomButton.Vertical_Alignment = StringAlignment.Center;
            createRoomButton.Click += CreateRoomButton_Click;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.MenuHighlight;
            Controls.Add(exitButton);
            Controls.Add(createRoomButton);
            Controls.Add(joinRoomButton);
            Controls.Add(headToHeadButton);
            Controls.Add(createQuestionButton);
            Controls.Add(statisticsButton);
            Controls.Add(logoutButton);
            Controls.Add(userConnected);
            Controls.Add(label1);
            Name = "MainMenu";
            Load += MainMenu_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void StatisticsButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Label label1;
        private ReaLTaiizor.Controls.ParrotButton statisticsButton;
        private ReaLTaiizor.Controls.ParrotButton button4;
        private Label userConnected;
        private Button logoutButton;
        private ReaLTaiizor.Controls.ParrotButton playButton;
        private ReaLTaiizor.Controls.ParrotButton exitButton;
        private ReaLTaiizor.Controls.ParrotButton createQuestionButton;
        private ReaLTaiizor.Controls.ParrotButton headToHeadButton;
        private ReaLTaiizor.Controls.ParrotButton joinRoomButton;
        private ReaLTaiizor.Controls.ParrotButton createRoomButton;
        private ReaLTaiizor.Controls.ParrotButton parrotButton3;
    }
}