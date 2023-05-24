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
            CreateRoomButton = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            userConnected = new Label();
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
            CreateRoomButton.TabIndex = 1;
            CreateRoomButton.Text = "Create Room";
            CreateRoomButton.UseVisualStyleBackColor = true;
            CreateRoomButton.Click += CreateRoomButton_Click;
            // 
            // button2
            // 
            button2.Location = new Point(344, 167);
            button2.Name = "button2";
            button2.Size = new Size(107, 30);
            button2.TabIndex = 1;
            button2.Text = "Join Room";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(344, 239);
            button3.Name = "button3";
            button3.Size = new Size(107, 30);
            button3.TabIndex = 1;
            button3.Text = "Stats";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(344, 275);
            button4.Name = "button4";
            button4.Size = new Size(107, 30);
            button4.TabIndex = 1;
            button4.Text = "Exit";
            button4.UseVisualStyleBackColor = true;
            // 
            // userConnected
            // 
            userConnected.AutoSize = true;
            userConnected.Location = new Point(563, 88);
            userConnected.Name = "userConnected";
            userConnected.Size = new Size(110, 15);
            userConnected.TabIndex = 2;
            userConnected.Text = "Connected as: error";
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.MenuHighlight;
            ClientSize = new Size(800, 450);
            Controls.Add(userConnected);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(CreateRoomButton);
            Controls.Add(label1);
            Name = "MainMenu";
            Text = "MainMenu";
            Load += MainMenu_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button CreateRoomButton;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label userConnected;
    }
}