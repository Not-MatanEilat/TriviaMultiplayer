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
            questionLabel = new Label();
            answer1Button = new Button();
            answer2Button = new Button();
            answer3Button = new Button();
            answer4Button = new Button();
            nextButton = new Button();
            gameOverTImer = new System.Windows.Forms.Timer(components);
            questionNumberLabel = new Label();
            timeLeftLabel = new Label();
            timeLeftTimer = new System.Windows.Forms.Timer(components);
            correctAnswersLabel = new Label();
            nextButtonTimer = new System.Windows.Forms.Timer(components);
            leaveButton = new ReaLTaiizor.Controls.RoyalButton();
            SuspendLayout();
            // 
            // questionLabel
            // 
            questionLabel.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            questionLabel.Location = new Point(3, 43);
            questionLabel.Name = "questionLabel";
            questionLabel.Size = new Size(794, 70);
            questionLabel.TabIndex = 0;
            questionLabel.Text = "Why this project is the best one?";
            questionLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // answer1Button
            // 
            answer1Button.Location = new Point(132, 116);
            answer1Button.Name = "answer1Button";
            answer1Button.Size = new Size(260, 30);
            answer1Button.TabIndex = 1;
            answer1Button.Text = "button1";
            answer1Button.UseVisualStyleBackColor = true;
            // 
            // answer2Button
            // 
            answer2Button.Location = new Point(398, 116);
            answer2Button.Name = "answer2Button";
            answer2Button.Size = new Size(260, 30);
            answer2Button.TabIndex = 2;
            answer2Button.Text = "button2";
            answer2Button.UseVisualStyleBackColor = true;
            // 
            // answer3Button
            // 
            answer3Button.Location = new Point(132, 161);
            answer3Button.Name = "answer3Button";
            answer3Button.Size = new Size(260, 30);
            answer3Button.TabIndex = 3;
            answer3Button.Text = "button3";
            answer3Button.UseVisualStyleBackColor = true;
            // 
            // answer4Button
            // 
            answer4Button.Location = new Point(398, 161);
            answer4Button.Name = "answer4Button";
            answer4Button.Size = new Size(260, 30);
            answer4Button.TabIndex = 4;
            answer4Button.Text = "button4";
            answer4Button.UseVisualStyleBackColor = true;
            // 
            // nextButton
            // 
            nextButton.Location = new Point(360, 232);
            nextButton.Name = "nextButton";
            nextButton.Size = new Size(75, 23);
            nextButton.TabIndex = 5;
            nextButton.Text = "Next";
            nextButton.UseVisualStyleBackColor = true;
            nextButton.Click += nextButton_Click;
            // 
            // gameOverTImer
            // 
            gameOverTImer.Interval = 1000;
            gameOverTImer.Tick += gameOverTImer_Tick;
            // 
            // questionNumberLabel
            // 
            questionNumberLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            questionNumberLabel.Location = new Point(345, 20);
            questionNumberLabel.Name = "questionNumberLabel";
            questionNumberLabel.Size = new Size(120, 23);
            questionNumberLabel.TabIndex = 8;
            questionNumberLabel.Text = "Question 1/1";
            questionNumberLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timeLeftLabel
            // 
            timeLeftLabel.AutoSize = true;
            timeLeftLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            timeLeftLabel.Location = new Point(35, 20);
            timeLeftLabel.Name = "timeLeftLabel";
            timeLeftLabel.Size = new Size(99, 21);
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
            correctAnswersLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            correctAnswersLabel.Location = new Point(659, 21);
            correctAnswersLabel.Name = "correctAnswersLabel";
            correctAnswersLabel.Size = new Size(77, 21);
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
            // Game
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DodgerBlue;
            Controls.Add(correctAnswersLabel);
            Controls.Add(timeLeftLabel);
            Controls.Add(questionNumberLabel);
            Controls.Add(nextButton);
            Controls.Add(answer4Button);
            Controls.Add(answer3Button);
            Controls.Add(answer2Button);
            Controls.Add(answer1Button);
            Controls.Add(questionLabel);
            Controls.Add(leaveButton);
            Name = "Game";
            Load += Game_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label questionLabel;
        private Button answer1Button;
        private Button answer2Button;
        private Button answer3Button;
        private Button answer4Button;
        private Button nextButton;
        private System.Windows.Forms.Timer gameOverTImer;
        private Label questionNumberLabel;
        private Label timeLeftLabel;
        private System.Windows.Forms.Timer timeLeftTimer;
        private Label correctAnswersLabel;
        private System.Windows.Forms.Timer nextButtonTimer;
        private ReaLTaiizor.Controls.RoyalButton leaveButton;
    }
}
