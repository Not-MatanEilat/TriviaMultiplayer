﻿namespace TriviaClientApp
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
            SuspendLayout();
            // 
            // myStats
            // 
            myStats.AutoSize = true;
            myStats.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            myStats.Location = new Point(222, 50);
            myStats.Name = "myStats";
            myStats.Size = new Size(109, 30);
            myStats.TabIndex = 0;
            myStats.Text = "MY STATS";
            // 
            // Statistics
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.RoyalBlue;
            ClientSize = new Size(800, 450);
            Controls.Add(myStats);
            Name = "Statistics";
            Text = "Statistics";
            Load += Statistics_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label myStats;
    }
}