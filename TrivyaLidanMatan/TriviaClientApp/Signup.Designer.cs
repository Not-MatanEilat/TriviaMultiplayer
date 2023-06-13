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
        private Label label1;
        private Button BackButtonPress;

        private void InitializeComponent()
        {
            label1 = new Label();
            BackButtonPress = new Button();
            usernameBox = new ReaLTaiizor.Controls.DreamTextBox();
            passwordBox = new ReaLTaiizor.Controls.DreamTextBox();
            emailBox = new ReaLTaiizor.Controls.DreamTextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            signupButton = new ReaLTaiizor.Controls.LostAcceptButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Courier New", 45F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(259, 46);
            label1.Name = "label1";
            label1.Size = new Size(245, 67);
            label1.TabIndex = 0;
            label1.Text = "Signup";
            label1.Click += label1_Click;
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
            // usernameBox
            // 
            usernameBox.BackColor = Color.FromArgb(224, 224, 224);
            usernameBox.BorderStyle = BorderStyle.FixedSingle;
            usernameBox.ColorA = Color.Silver;
            usernameBox.ColorB = Color.FromArgb(224, 224, 224);
            usernameBox.ColorC = Color.FromArgb(224, 224, 224);
            usernameBox.ColorD = Color.FromArgb(0, 0, 0, 0);
            usernameBox.ColorE = Color.FromArgb(25, 255, 255, 255);
            usernameBox.ColorF = Color.FromArgb(64, 64, 64);
            usernameBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            usernameBox.ForeColor = Color.Black;
            usernameBox.Location = new Point(278, 134);
            usernameBox.Name = "usernameBox";
            usernameBox.PlaceholderText = "  Username";
            usernameBox.Size = new Size(187, 29);
            usernameBox.TabIndex = 8;
            usernameBox.TextChanged += usernameBox_TextChanged;
            usernameBox.KeyDown += Enter;
            // 
            // passwordBox
            // 
            passwordBox.BackColor = Color.FromArgb(224, 224, 224);
            passwordBox.BorderStyle = BorderStyle.FixedSingle;
            passwordBox.ColorA = Color.Silver;
            passwordBox.ColorB = Color.FromArgb(224, 224, 224);
            passwordBox.ColorC = Color.FromArgb(224, 224, 224);
            passwordBox.ColorD = Color.FromArgb(0, 0, 0, 0);
            passwordBox.ColorE = Color.FromArgb(25, 255, 255, 255);
            passwordBox.ColorF = Color.FromArgb(64, 64, 64);
            passwordBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            passwordBox.ForeColor = Color.Black;
            passwordBox.Location = new Point(278, 169);
            passwordBox.Name = "passwordBox";
            passwordBox.PlaceholderText = "  Password";
            passwordBox.Size = new Size(187, 29);
            passwordBox.TabIndex = 9;
            passwordBox.UseSystemPasswordChar = true;
            passwordBox.KeyDown += Enter;
            // 
            // emailBox
            // 
            emailBox.BackColor = Color.FromArgb(224, 224, 224);
            emailBox.BorderStyle = BorderStyle.FixedSingle;
            emailBox.ColorA = Color.Silver;
            emailBox.ColorB = Color.FromArgb(224, 224, 224);
            emailBox.ColorC = Color.FromArgb(224, 224, 224);
            emailBox.ColorD = Color.FromArgb(0, 0, 0, 0);
            emailBox.ColorE = Color.FromArgb(25, 255, 255, 255);
            emailBox.ColorF = Color.FromArgb(64, 64, 64);
            emailBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            emailBox.ForeColor = Color.Black;
            emailBox.Location = new Point(278, 204);
            emailBox.Name = "emailBox";
            emailBox.PlaceholderText = "  Email";
            emailBox.Size = new Size(187, 29);
            emailBox.TabIndex = 10;
            emailBox.KeyDown += Enter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Berlin Sans FB Demi", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(171, 139);
            label2.Name = "label2";
            label2.Size = new Size(101, 24);
            label2.TabIndex = 11;
            label2.Text = "Username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Berlin Sans FB Demi", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(176, 174);
            label3.Name = "label3";
            label3.Size = new Size(96, 24);
            label3.TabIndex = 12;
            label3.Text = "Password";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Berlin Sans FB Demi", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(212, 204);
            label4.Name = "label4";
            label4.Size = new Size(60, 24);
            label4.TabIndex = 13;
            label4.Text = "Email";
            // 
            // signupButton
            // 
            signupButton.BackColor = Color.SeaGreen;
            signupButton.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            signupButton.ForeColor = Color.White;
            signupButton.HoverColor = Color.ForestGreen;
            signupButton.Image = null;
            signupButton.Location = new Point(302, 250);
            signupButton.Name = "signupButton";
            signupButton.Size = new Size(123, 31);
            signupButton.TabIndex = 14;
            signupButton.Text = "Signup";
            signupButton.Click += signupButton_Click;
            // 
            // Signup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            BackColor = Color.SteelBlue;
            Controls.Add(signupButton);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(emailBox);
            Controls.Add(passwordBox);
            Controls.Add(usernameBox);
            Controls.Add(BackButtonPress);
            Controls.Add(label1);
            Name = "Signup";
            ResumeLayout(false);
            PerformLayout();
        }

        private ReaLTaiizor.Controls.DreamTextBox usernameBox;
        private ReaLTaiizor.Controls.DreamTextBox passwordBox;
        private ReaLTaiizor.Controls.DreamTextBox emailBox;
        private Label label2;
        private Label label3;
        private Label label4;
        private ReaLTaiizor.Controls.LostAcceptButton signupButton;
    }
}