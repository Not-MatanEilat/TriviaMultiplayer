﻿namespace TriviaClientApp
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
            CreateRoomButton = new Button();
            JoinRoomButton = new Button();
            statisticsButton = new Button();
            button4 = new Button();
            userConnected = new Label();
            logoutButton = new Button();
            createQuestionButton = new Button();
            headToHeaButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(328, 49);
            label1.Name = "label1";
            label1.Size = new Size(137, 65);
            label1.TabIndex = 0;
            label1.Text = "Trivia";
            // 
            // CreateRoomButton
            // 
            CreateRoomButton.Location = new Point(344, 203);
            CreateRoomButton.Name = "CreateRoomButton";
            CreateRoomButton.Size = new Size(107, 30);
            CreateRoomButton.TabIndex = 2;
            CreateRoomButton.Text = "Create Room";
            CreateRoomButton.UseVisualStyleBackColor = true;
            CreateRoomButton.Click += CreateRoomButton_Click;
            // 
            // JoinRoomButton
            // 
            JoinRoomButton.Location = new Point(344, 167);
            JoinRoomButton.Name = "JoinRoomButton";
            JoinRoomButton.Size = new Size(107, 30);
            JoinRoomButton.TabIndex = 1;
            JoinRoomButton.Text = "Join Room";
            JoinRoomButton.UseVisualStyleBackColor = true;
            JoinRoomButton.Click += JoinRoomButton_Click;
            // 
            // statisticsButton
            // 
            statisticsButton.Location = new Point(344, 275);
            statisticsButton.Name = "statisticsButton";
            statisticsButton.Size = new Size(107, 30);
            statisticsButton.TabIndex = 3;
            statisticsButton.Text = "statistics";
            statisticsButton.UseVisualStyleBackColor = true;
            statisticsButton.Click += statisticsButton_Click;
            // 
            // button4
            // 
            button4.Location = new Point(344, 347);
            button4.Name = "button4";
            button4.Size = new Size(107, 30);
            button4.TabIndex = 4;
            button4.Text = "Exit";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // userConnected
            // 
            userConnected.AutoSize = true;
            userConnected.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            userConnected.Location = new Point(328, 127);
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
            // createQuestionButton
            // 
            createQuestionButton.Location = new Point(344, 311);
            createQuestionButton.Name = "createQuestionButton";
            createQuestionButton.Size = new Size(107, 30);
            createQuestionButton.TabIndex = 3;
            createQuestionButton.Text = "Create Question";
            createQuestionButton.UseVisualStyleBackColor = true;
            createQuestionButton.Click += createQuestionButton_Click;
            // 
            // headToHeaButton
            // 
            headToHeaButton.Location = new Point(344, 239);
            headToHeaButton.Name = "headToHeaButton";
            headToHeaButton.Size = new Size(107, 30);
            headToHeaButton.TabIndex = 6;
            headToHeaButton.Text = "Head To Head";
            headToHeaButton.UseVisualStyleBackColor = true;
            headToHeaButton.Click += headToHeaButton_Click;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.MenuHighlight;
            Controls.Add(headToHeaButton);
            Controls.Add(logoutButton);
            Controls.Add(userConnected);
            Controls.Add(button4);
            Controls.Add(createQuestionButton);
            Controls.Add(statisticsButton);
            Controls.Add(JoinRoomButton);
            Controls.Add(CreateRoomButton);
            Controls.Add(label1);
            Name = "MainMenu";
            Load += MainMenu_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button CreateRoomButton;
        private Button button2;
        private Button statisticsButton;
        private Button button4;
        private Label userConnected;
        private Button JoinRoomButton;
        private Button logoutButton;
        private Button createQuestionButton;
        private Button headToHeaButton;
    }
}