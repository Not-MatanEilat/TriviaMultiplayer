namespace TriviaClientApp
{
    partial class RoomBox
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
            nameLabel = new Label();
            joinButton = new Button();
            playersAmountLabel = new Label();
            questionsLabel = new Label();
            timeLabel = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(12, 16);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(134, 15);
            nameLabel.TabIndex = 0;
            nameLabel.Text = "{roomName} - {roomId}";
            // 
            // joinButton
            // 
            joinButton.Location = new Point(3, 119);
            joinButton.Name = "joinButton";
            joinButton.Size = new Size(294, 23);
            joinButton.TabIndex = 1;
            joinButton.Text = "Join Room";
            joinButton.UseVisualStyleBackColor = true;
            joinButton.Click += joinButton_Click;
            // 
            // playersAmountLabel
            // 
            playersAmountLabel.AutoSize = true;
            playersAmountLabel.Location = new Point(12, 31);
            playersAmountLabel.Name = "playersAmountLabel";
            playersAmountLabel.Size = new Size(168, 15);
            playersAmountLabel.TabIndex = 2;
            playersAmountLabel.Text = "Players: {players}/{maxPlayers}";
            // 
            // questionsLabel
            // 
            questionsLabel.AutoSize = true;
            questionsLabel.Location = new Point(12, 46);
            questionsLabel.Name = "questionsLabel";
            questionsLabel.Size = new Size(164, 15);
            questionsLabel.TabIndex = 2;
            questionsLabel.Text = "Questions: {questionAmount}";
            // 
            // timeLabel
            // 
            timeLabel.AutoSize = true;
            timeLabel.Location = new Point(12, 61);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(136, 15);
            timeLabel.TabIndex = 2;
            timeLabel.Text = "Time: {timePerQuestion}";
            // 
            // RoomBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Firebrick;
            Controls.Add(timeLabel);
            Controls.Add(questionsLabel);
            Controls.Add(playersAmountLabel);
            Controls.Add(joinButton);
            Controls.Add(nameLabel);
            Name = "RoomBox";
            Size = new Size(300, 154);
            Load += RoomBox_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label nameLabel;
        private Button joinButton;
        private Label playersAmountLabel;
        private Label questionsLabel;
        private Label timeLabel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
