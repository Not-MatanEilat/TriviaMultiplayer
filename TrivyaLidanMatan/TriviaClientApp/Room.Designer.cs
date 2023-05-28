﻿namespace TriviaClientApp
{
    partial class Room
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
            namesListFlow = new FlowLayoutPanel();
            BackButtonPress = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(33, 37);
            label1.Name = "label1";
            label1.Size = new Size(86, 30);
            label1.TabIndex = 0;
            label1.Text = "Players:";
            // 
            // namesListFlow
            // 
            namesListFlow.Location = new Point(33, 84);
            namesListFlow.Name = "namesListFlow";
            namesListFlow.Size = new Size(220, 320);
            namesListFlow.TabIndex = 1;
            namesListFlow.Paint += flowLayoutPanel1_Paint;
            // 
            // BackButtonPress
            // 
            BackButtonPress.Location = new Point(33, 415);
            BackButtonPress.Name = "BackButtonPress";
            BackButtonPress.Size = new Size(75, 23);
            BackButtonPress.TabIndex = 6;
            BackButtonPress.Text = "Back";
            BackButtonPress.UseVisualStyleBackColor = true;
            BackButtonPress.Click += BackButtonPress_Click;
            // 
            // Room
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 192, 255);
            ClientSize = new Size(800, 450);
            Controls.Add(BackButtonPress);
            Controls.Add(namesListFlow);
            Controls.Add(label1);
            Name = "Room";
            Text = "Room";
            Load += Room_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private FlowLayoutPanel namesListFlow;
        private Button BackButtonPress;
    }
}