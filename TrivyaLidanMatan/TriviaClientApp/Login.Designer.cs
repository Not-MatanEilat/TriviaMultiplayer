namespace TriviaClientApp
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            usernameBox = new ReaLTaiizor.Controls.DreamTextBox();
            passwordBox = new ReaLTaiizor.Controls.DreamTextBox();
            dungeonHeaderLabel1 = new ReaLTaiizor.Controls.DungeonHeaderLabel();
            rememberMeToggle = new ReaLTaiizor.Controls.HopeToggle();
            loginButton = new ReaLTaiizor.Controls.LostAcceptButton();
            noAccountText = new ReaLTaiizor.Controls.DungeonHeaderLabel();
            createAccountText = new ReaLTaiizor.Controls.DungeonHeaderLabel();
            hereLinkText = new ReaLTaiizor.Controls.DungeonHeaderLabel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Courier New", 45F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(296, 39);
            label1.Name = "label1";
            label1.Size = new Size(209, 67);
            label1.TabIndex = 0;
            label1.Text = "Login";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Berlin Sans FB Demi", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(196, 145);
            label2.Name = "label2";
            label2.Size = new Size(101, 24);
            label2.TabIndex = 2;
            label2.Text = "Username";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Berlin Sans FB Demi", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(201, 181);
            label3.Name = "label3";
            label3.Size = new Size(96, 24);
            label3.TabIndex = 4;
            label3.Text = "Password";
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
            usernameBox.Location = new Point(306, 143);
            usernameBox.Name = "usernameBox";
            usernameBox.PlaceholderText = "  Username";
            usernameBox.Size = new Size(187, 29);
            usernameBox.TabIndex = 1;
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
            passwordBox.Location = new Point(306, 178);
            passwordBox.Name = "passwordBox";
            passwordBox.PlaceholderText = "  Password";
            passwordBox.Size = new Size(187, 29);
            passwordBox.TabIndex = 2;
            passwordBox.UseSystemPasswordChar = true;
            passwordBox.KeyDown += Enter;
            // 
            // dungeonHeaderLabel1
            // 
            dungeonHeaderLabel1.AutoSize = true;
            dungeonHeaderLabel1.BackColor = Color.Transparent;
            dungeonHeaderLabel1.Font = new Font("Courier New", 17.2F, FontStyle.Bold, GraphicsUnit.Point);
            dungeonHeaderLabel1.ForeColor = Color.Black;
            dungeonHeaderLabel1.Location = new Point(338, 230);
            dungeonHeaderLabel1.Name = "dungeonHeaderLabel1";
            dungeonHeaderLabel1.Size = new Size(166, 27);
            dungeonHeaderLabel1.TabIndex = 11;
            dungeonHeaderLabel1.Text = "Remember Me";
            dungeonHeaderLabel1.Click += dungeonHeaderLabel1_Click;
            // 
            // rememberMeToggle
            // 
            rememberMeToggle.AutoSize = true;
            rememberMeToggle.BackColor = Color.Gray;
            rememberMeToggle.BaseColor = Color.DeepSkyBlue;
            rememberMeToggle.BaseColorA = Color.White;
            rememberMeToggle.BaseColorB = Color.FromArgb(100, 64, 158, 255);
            rememberMeToggle.ForeColor = Color.DeepSkyBlue;
            rememberMeToggle.HeadColorA = Color.FromArgb(220, 223, 230);
            rememberMeToggle.HeadColorB = Color.White;
            rememberMeToggle.HeadColorC = Color.FromArgb(64, 158, 255);
            rememberMeToggle.HeadColorD = Color.FromArgb(64, 158, 255);
            rememberMeToggle.Location = new Point(296, 235);
            rememberMeToggle.Name = "rememberMeToggle";
            rememberMeToggle.Size = new Size(48, 20);
            rememberMeToggle.TabIndex = 12;
            rememberMeToggle.Text = "hopeToggle1";
            rememberMeToggle.UseVisualStyleBackColor = false;
            rememberMeToggle.CheckedChanged += hopeToggle1_CheckedChanged;
            // 
            // loginButton
            // 
            loginButton.BackColor = Color.SeaGreen;
            loginButton.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            loginButton.ForeColor = Color.White;
            loginButton.HoverColor = Color.ForestGreen;
            loginButton.Image = null;
            loginButton.Location = new Point(328, 272);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(123, 31);
            loginButton.TabIndex = 13;
            loginButton.Text = "Login";
            loginButton.Click += loginButton_Click;
            // 
            // noAccountText
            // 
            noAccountText.AutoSize = true;
            noAccountText.BackColor = Color.Transparent;
            noAccountText.Font = new Font("Ebrima", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            noAccountText.ForeColor = Color.Black;
            noAccountText.Location = new Point(338, 318);
            noAccountText.Name = "noAccountText";
            noAccountText.Size = new Size(91, 19);
            noAccountText.TabIndex = 11;
            noAccountText.Text = "No account?";
            // 
            // createAccountText
            // 
            createAccountText.AutoSize = true;
            createAccountText.BackColor = Color.Transparent;
            createAccountText.Font = new Font("Ebrima", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            createAccountText.ForeColor = Color.Black;
            createAccountText.Location = new Point(306, 337);
            createAccountText.Name = "createAccountText";
            createAccountText.Size = new Size(129, 19);
            createAccountText.TabIndex = 11;
            createAccountText.Text = "Create an account";
            // 
            // hereLinkText
            // 
            hereLinkText.AutoSize = true;
            hereLinkText.BackColor = Color.Transparent;
            hereLinkText.Font = new Font("Ebrima", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            hereLinkText.ForeColor = Color.MediumBlue;
            hereLinkText.Location = new Point(435, 337);
            hereLinkText.Name = "hereLinkText";
            hereLinkText.Size = new Size(39, 19);
            hereLinkText.TabIndex = 11;
            hereLinkText.Text = "here";
            hereLinkText.Click += hereTextLink_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DeepSkyBlue;
            Controls.Add(loginButton);
            Controls.Add(rememberMeToggle);
            Controls.Add(hereLinkText);
            Controls.Add(createAccountText);
            Controls.Add(noAccountText);
            Controls.Add(dungeonHeaderLabel1);
            Controls.Add(passwordBox);
            Controls.Add(usernameBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Login";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private ReaLTaiizor.Controls.SkyTextBox skyTextBox1;
        private ReaLTaiizor.Controls.DreamTextBox usernameBox;
        private ReaLTaiizor.Controls.DreamTextBox passwordBox;
        private ReaLTaiizor.Controls.DungeonHeaderLabel dungeonHeaderLabel1;
        private ReaLTaiizor.Controls.HopeToggle rememberMeToggle;
        private ReaLTaiizor.Controls.LostAcceptButton loginButton;
        private ReaLTaiizor.Controls.DungeonHeaderLabel noAccountText;
        private ReaLTaiizor.Controls.DungeonHeaderLabel createAccountText;
        private ReaLTaiizor.Controls.DungeonHeaderLabel hereLinkText;
    }
}