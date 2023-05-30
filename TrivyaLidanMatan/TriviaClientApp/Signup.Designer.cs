namespace TriviaClientApp
{
    partial class Signup
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

        private TextBox usernameTextBox;
        private Label label1;
        private TextBox passwordTextBox;
        private TextBox emailTextBox;
        private Button signupButton;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button BackButtonPress;

        private void InitializeComponent()
        {
            label1 = new Label();
            usernameTextBox = new TextBox();
            passwordTextBox = new TextBox();
            emailTextBox = new TextBox();
            signupButton = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            BackButtonPress = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(325, 67);
            label1.Name = "label1";
            label1.Size = new Size(119, 45);
            label1.TabIndex = 0;
            label1.Text = "Signup";
            label1.Click += label1_Click;
            // 
            // usernameTextBox
            // 
            usernameTextBox.Cursor = Cursors.IBeam;
            usernameTextBox.Location = new Point(334, 151);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(100, 23);
            usernameTextBox.TabIndex = 1;
            usernameTextBox.TextChanged += textBox1_TextChanged_1;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(334, 193);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(100, 23);
            passwordTextBox.TabIndex = 2;
            passwordTextBox.UseSystemPasswordChar = true;
            passwordTextBox.TextChanged += passwordTextBox_TextChanged;
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(334, 235);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(100, 23);
            emailTextBox.TabIndex = 3;
            emailTextBox.TextChanged += passwordTextBox_TextChanged;
            // 
            // signupButton
            // 
            signupButton.Location = new Point(334, 278);
            signupButton.Name = "signupButton";
            signupButton.Size = new Size(100, 27);
            signupButton.TabIndex = 4;
            signupButton.Text = "Signup";
            signupButton.UseVisualStyleBackColor = true;
            signupButton.Click += signupButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(268, 154);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 4;
            label2.Text = "Username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(268, 196);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 4;
            label3.Text = "Password";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(278, 243);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 4;
            label4.Text = "Email";
            // 
            // BackButtonPress
            // 
            BackButtonPress.Location = new Point(13, 414);
            BackButtonPress.Name = "BackButtonPress";
            BackButtonPress.Size = new Size(75, 23);
            BackButtonPress.TabIndex = 7;
            BackButtonPress.Text = "Back";
            BackButtonPress.UseVisualStyleBackColor = true;
            BackButtonPress.Click += BackButtonPress_Click;
            // 
            // Signup
            // 
            BackColor = Color.SteelBlue;
            Controls.Add(BackButtonPress);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(signupButton);
            Controls.Add(emailTextBox);
            Controls.Add(passwordTextBox);
            Controls.Add(usernameTextBox);
            Controls.Add(label1);
            Name = "Signup";
            Size = new Size(800, 450);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}