﻿namespace TriviaClientApp
{
    partial class JoinRoom
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
            BackButtonPress = new Button();
            roomsListFlow = new FlowLayoutPanel();
            refreshButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(57, 34);
            label1.Name = "label1";
            label1.Size = new Size(210, 50);
            label1.TabIndex = 0;
            label1.Text = "Join Rooms";
            // 
            // BackButtonPress
            // 
            BackButtonPress.Location = new Point(12, 415);
            BackButtonPress.Name = "BackButtonPress";
            BackButtonPress.Size = new Size(75, 23);
            BackButtonPress.TabIndex = 5;
            BackButtonPress.Text = "Back";
            BackButtonPress.UseVisualStyleBackColor = true;
            BackButtonPress.Click += BackButtonPress_Click;
            // 
            // roomsListFlow
            // 
            roomsListFlow.AutoScroll = true;
            roomsListFlow.FlowDirection = FlowDirection.TopDown;
            roomsListFlow.Location = new Point(435, 12);
            roomsListFlow.Name = "roomsListFlow";
            roomsListFlow.Size = new Size(353, 426);
            roomsListFlow.TabIndex = 6;
            roomsListFlow.WrapContents = false;
            // 
            // refreshButton
            // 
            refreshButton.Location = new Point(406, 12);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(23, 23);
            refreshButton.TabIndex = 7;
            refreshButton.TabStop = false;
            refreshButton.Text = "↻";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += refreshButton_Click;
            // 
            // JoinRoom
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 64, 0);
            ClientSize = new Size(800, 450);
            Controls.Add(refreshButton);
            Controls.Add(roomsListFlow);
            Controls.Add(BackButtonPress);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "JoinRoom";
            ShowInTaskbar = false;
            Text = "JoinRoom";
            Load += JoinRoom_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button BackButtonPress;
        private FlowLayoutPanel roomsListFlow;
        private Button refreshButton;
    }
}