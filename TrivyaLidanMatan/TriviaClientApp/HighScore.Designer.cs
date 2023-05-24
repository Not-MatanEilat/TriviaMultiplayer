namespace TriviaClientApp
{
    partial class HighScore
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
            BackButtonPress = new Button();
            highScores = new Label();
            SuspendLayout();
            // 
            // BackButtonPress
            // 
            BackButtonPress.Location = new Point(12, 415);
            BackButtonPress.Name = "BackButtonPress";
            BackButtonPress.Size = new Size(75, 23);
            BackButtonPress.TabIndex = 7;
            BackButtonPress.Text = "Back";
            BackButtonPress.UseVisualStyleBackColor = true;
            BackButtonPress.Click += BackButtonPress_Click;
            // 
            // highScores
            // 
            highScores.AutoSize = true;
            highScores.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            highScores.Location = new Point(288, 97);
            highScores.Name = "highScores";
            highScores.Size = new Size(129, 30);
            highScores.TabIndex = 8;
            highScores.Text = "High Scores";
            // 
            // HighScore
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CornflowerBlue;
            ClientSize = new Size(800, 450);
            Controls.Add(highScores);
            Controls.Add(BackButtonPress);
            Name = "HighScore";
            Text = "HighScore";
            Load += HighScore_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BackButtonPress;
        private Label highScores;
    }
}