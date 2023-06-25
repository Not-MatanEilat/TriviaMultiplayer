namespace TriviaClientApp
{
    partial class Game
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            gameOverTImer = new System.Windows.Forms.Timer(components);
            questionNumberLabel = new Label();
            timeLeftLabel = new Label();
            timeLeftTimer = new System.Windows.Forms.Timer(components);
            correctAnswersLabel = new Label();
            nextButtonTimer = new System.Windows.Forms.Timer(components);
            leaveButton = new ReaLTaiizor.Controls.RoyalButton();
            questionLabel = new Label();
            answer1Button = new ReaLTaiizor.Controls.RoyalButton();
            answer3Button = new ReaLTaiizor.Controls.RoyalButton();
            answer4Button = new ReaLTaiizor.Controls.RoyalButton();
            nextButton = new ReaLTaiizor.Controls.LostAcceptButton();
            answer2Button = new ReaLTaiizor.Controls.RoyalButton();
            SuspendLayout();
            // 
            // gameOverTImer
            // 
            gameOverTImer.Interval = 1000;
            gameOverTImer.Tick += gameOverTImer_Tick;
            // 
            // questionNumberLabel
            // 
            questionNumberLabel.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point);
            questionNumberLabel.Location = new Point(342, 25);
            questionNumberLabel.Name = "questionNumberLabel";
            questionNumberLabel.Size = new Size(133, 23);
            questionNumberLabel.TabIndex = 8;
            questionNumberLabel.Text = "Question 1/1";
            questionNumberLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timeLeftLabel
            // 
            timeLeftLabel.AutoSize = true;
            timeLeftLabel.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point);
            timeLeftLabel.Location = new Point(27, 27);
            timeLeftLabel.Name = "timeLeftLabel";
            timeLeftLabel.Size = new Size(138, 18);
            timeLeftLabel.TabIndex = 9;
            timeLeftLabel.Text = "Time Left: 10";
            // 
            // timeLeftTimer
            // 
            timeLeftTimer.Interval = 1000;
            timeLeftTimer.Tick += timeLeftTimer_Tick;
            // 
            // correctAnswersLabel
            // 
            correctAnswersLabel.AutoSize = true;
            correctAnswersLabel.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point);
            correctAnswersLabel.Location = new Point(643, 25);
            correctAnswersLabel.Name = "correctAnswersLabel";
            correctAnswersLabel.Size = new Size(108, 18);
            correctAnswersLabel.TabIndex = 10;
            correctAnswersLabel.Text = "Correct: 0";
            // 
            // nextButtonTimer
            // 
            nextButtonTimer.Interval = 5000;
            nextButtonTimer.Tick += nextButtonTimer_Tick;
            // 
            // leaveButton
            // 
            leaveButton.BackColor = Color.FromArgb(243, 243, 243);
            leaveButton.BorderColor = Color.FromArgb(180, 180, 180);
            leaveButton.BorderThickness = 3;
            leaveButton.DrawBorder = true;
            leaveButton.Font = new Font("Berlin Sans FB Demi", 11F, FontStyle.Regular, GraphicsUnit.Point);
            leaveButton.ForeColor = Color.FromArgb(31, 31, 31);
            leaveButton.HotTrackColor = Color.FromArgb(221, 221, 221);
            leaveButton.Image = null;
            leaveButton.LayoutFlags = ReaLTaiizor.Util.RoyalLayoutFlags.ImageBeforeText;
            leaveButton.Location = new Point(14, 398);
            leaveButton.Name = "leaveButton";
            leaveButton.PressedColor = Color.FromArgb(243, 243, 243);
            leaveButton.PressedForeColor = Color.Black;
            leaveButton.Size = new Size(114, 40);
            leaveButton.TabIndex = 12;
            leaveButton.Text = "Leave";
            leaveButton.Click += BackButtonPress_Click;
            // 
            // questionLabel
            // 
            questionLabel.Font = new Font("Courier New", 16F, FontStyle.Bold, GraphicsUnit.Point);
            questionLabel.Location = new Point(14, 48);
            questionLabel.Name = "questionLabel";
            questionLabel.Size = new Size(783, 61);
            questionLabel.TabIndex = 13;
            questionLabel.Text = "Why this project is the best one?";
            questionLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // answer1Button
            // 
            answer1Button.BackColor = Color.FromArgb(243, 243, 243);
            answer1Button.BorderColor = Color.FromArgb(180, 180, 180);
            answer1Button.BorderThickness = 3;
            answer1Button.DrawBorder = true;
            answer1Button.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            answer1Button.ForeColor = Color.FromArgb(31, 31, 31);
            answer1Button.HotTrackColor = Color.FromArgb(221, 221, 221);
            answer1Button.Image = null;
            answer1Button.LayoutFlags = ReaLTaiizor.Util.RoyalLayoutFlags.ImageBeforeText;
            answer1Button.Location = new Point(175, 112);
            answer1Button.Name = "answer1Button";
            answer1Button.PressedColor = Color.FromArgb(243, 243, 243);
            answer1Button.PressedForeColor = Color.Black;
            answer1Button.Size = new Size(215, 33);
            answer1Button.TabIndex = 14;
            answer1Button.Text = "answer1";
            // 
            // answer3Button
            // 
            answer3Button.BackColor = Color.FromArgb(243, 243, 243);
            answer3Button.BorderColor = Color.FromArgb(180, 180, 180);
            answer3Button.BorderThickness = 3;
            answer3Button.DrawBorder = true;
            answer3Button.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            answer3Button.ForeColor = Color.FromArgb(31, 31, 31);
            answer3Button.HotTrackColor = Color.FromArgb(221, 221, 221);
            answer3Button.Image = null;
            answer3Button.LayoutFlags = ReaLTaiizor.Util.RoyalLayoutFlags.ImageBeforeText;
            answer3Button.Location = new Point(175, 161);
            answer3Button.Name = "answer3Button";
            answer3Button.PressedColor = Color.FromArgb(243, 243, 243);
            answer3Button.PressedForeColor = Color.Black;
            answer3Button.Size = new Size(215, 33);
            answer3Button.TabIndex = 14;
            answer3Button.Text = "answer3";
            // 
            // answer4Button
            // 
            answer4Button.BackColor = Color.FromArgb(243, 243, 243);
            answer4Button.BorderColor = Color.FromArgb(180, 180, 180);
            answer4Button.BorderThickness = 3;
            answer4Button.DrawBorder = true;
            answer4Button.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            answer4Button.ForeColor = Color.FromArgb(31, 31, 31);
            answer4Button.HotTrackColor = Color.FromArgb(221, 221, 221);
            answer4Button.Image = null;
            answer4Button.LayoutFlags = ReaLTaiizor.Util.RoyalLayoutFlags.ImageBeforeText;
            answer4Button.Location = new Point(401, 161);
            answer4Button.Name = "answer4Button";
            answer4Button.PressedColor = Color.FromArgb(243, 243, 243);
            answer4Button.PressedForeColor = Color.Black;
            answer4Button.Size = new Size(215, 33);
            answer4Button.TabIndex = 14;
            answer4Button.Text = "answer4";
            // 
            // nextButton
            // 
            nextButton.BackColor = Color.SeaGreen;
            nextButton.Enabled = false;
            nextButton.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            nextButton.ForeColor = Color.White;
            nextButton.HoverColor = Color.ForestGreen;
            nextButton.Image = null;
            nextButton.Location = new Point(331, 214);
            nextButton.Name = "nextButton";
            nextButton.Size = new Size(123, 31);
            nextButton.TabIndex = 15;
            nextButton.Text = "Next";
            nextButton.Click += nextButton_Click;
            nextButton.KeyDown += Enter;
            // 
            // answer2Button
            // 
            answer2Button.BackColor = Color.FromArgb(243, 243, 243);
            answer2Button.BorderColor = Color.FromArgb(180, 180, 180);
            answer2Button.BorderThickness = 3;
            answer2Button.DrawBorder = true;
            answer2Button.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            answer2Button.ForeColor = Color.FromArgb(31, 31, 31);
            answer2Button.HotTrackColor = Color.FromArgb(221, 221, 221);
            answer2Button.Image = null;
            answer2Button.LayoutFlags = ReaLTaiizor.Util.RoyalLayoutFlags.ImageBeforeText;
            answer2Button.Location = new Point(401, 112);
            answer2Button.Name = "answer2Button";
            answer2Button.PressedColor = Color.FromArgb(243, 243, 243);
            answer2Button.PressedForeColor = Color.Black;
            answer2Button.Size = new Size(215, 33);
            answer2Button.TabIndex = 14;
            answer2Button.Text = "answer2";
            answer2Button.Click += answer2Button_Click;
            // 
            // Game
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DodgerBlue;
            Controls.Add(nextButton);
            Controls.Add(answer4Button);
            Controls.Add(answer3Button);
            Controls.Add(answer2Button);
            Controls.Add(answer1Button);
            Controls.Add(questionLabel);
            Controls.Add(correctAnswersLabel);
            Controls.Add(timeLeftLabel);
            Controls.Add(questionNumberLabel);
            Controls.Add(leaveButton);
            Name = "Game";
            Load += Game_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Timer gameOverTImer;
        private Label questionNumberLabel;
        private Label timeLeftLabel;
        private System.Windows.Forms.Timer timeLeftTimer;
        private Label correctAnswersLabel;
        private System.Windows.Forms.Timer nextButtonTimer;
        private ReaLTaiizor.Controls.RoyalButton leaveButton;
        private Label questionLabel;
        private ReaLTaiizor.Controls.RoyalButton answer1Button;
        private ReaLTaiizor.Controls.RoyalButton answer3Button;
        private ReaLTaiizor.Controls.RoyalButton answer4Button;
        private ReaLTaiizor.Controls.LostAcceptButton nextButton;
        private ReaLTaiizor.Controls.RoyalButton answer2Button;
    }
}
