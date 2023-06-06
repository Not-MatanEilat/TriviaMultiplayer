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
            BackButtonPress = new Button();
            gameOverTImer = new System.Windows.Forms.Timer(components);
            questionNumberLabel = new Label();
            timeLeftLabel = new Label();
            timeLeftTimer = new System.Windows.Forms.Timer(components);
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
            // BackButtonPress
            // 
            BackButtonPress.Location = new Point(15, 415);
            BackButtonPress.Name = "BackButtonPress";
            BackButtonPress.Size = new Size(75, 23);
            BackButtonPress.TabIndex = 7;
            BackButtonPress.Text = "Leave";
            BackButtonPress.UseVisualStyleBackColor = true;
            BackButtonPress.Click += BackButtonPress_Click;
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
            // Game
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(timeLeftLabel);
            Controls.Add(questionNumberLabel);
            Controls.Add(BackButtonPress);
            Controls.Add(nextButton);
            Controls.Add(answer4Button);
            Controls.Add(answer3Button);
            Controls.Add(answer2Button);
            Controls.Add(answer1Button);
            Controls.Add(questionLabel);
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
        private Button BackButtonPress;
        private System.Windows.Forms.Timer gameOverTImer;
        private Label questionNumberLabel;
        private Label timeLeftLabel;
        private System.Windows.Forms.Timer timeLeftTimer;
    }
}
