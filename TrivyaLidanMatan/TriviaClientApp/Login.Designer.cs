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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.usernameBox = new ReaLTaiizor.Controls.DreamTextBox();
            this.passwordBox = new ReaLTaiizor.Controls.DreamTextBox();
            this.dungeonHeaderLabel1 = new ReaLTaiizor.Controls.DungeonHeaderLabel();
            this.rememberMeToggle = new ReaLTaiizor.Controls.HopeToggle();
            this.loginButton = new ReaLTaiizor.Controls.LostAcceptButton();
            this.noAccountText = new ReaLTaiizor.Controls.DungeonHeaderLabel();
            this.createAccountText = new ReaLTaiizor.Controls.DungeonHeaderLabel();
            this.hereLinkText = new ReaLTaiizor.Controls.DungeonHeaderLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(338, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 85);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Berlin Sans FB Demi", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(224, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Berlin Sans FB Demi", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(230, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password";
            // 
            // usernameBox
            // 
            this.usernameBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.usernameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usernameBox.ColorA = System.Drawing.Color.Silver;
            this.usernameBox.ColorB = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.usernameBox.ColorC = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.usernameBox.ColorD = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.usernameBox.ColorE = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.usernameBox.ColorF = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.usernameBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.usernameBox.ForeColor = System.Drawing.Color.Black;
            this.usernameBox.Location = new System.Drawing.Point(350, 191);
            this.usernameBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.PlaceholderText = "  Username";
            this.usernameBox.Size = new System.Drawing.Size(213, 34);
            this.usernameBox.TabIndex = 1;
            // 
            // passwordBox
            // 
            this.passwordBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.passwordBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordBox.ColorA = System.Drawing.Color.Silver;
            this.passwordBox.ColorB = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.passwordBox.ColorC = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.passwordBox.ColorD = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.passwordBox.ColorE = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.passwordBox.ColorF = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.passwordBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.passwordBox.ForeColor = System.Drawing.Color.Black;
            this.passwordBox.Location = new System.Drawing.Point(350, 237);
            this.passwordBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PlaceholderText = "  Password";
            this.passwordBox.Size = new System.Drawing.Size(213, 34);
            this.passwordBox.TabIndex = 2;
            this.passwordBox.UseSystemPasswordChar = true;
            // 
            // dungeonHeaderLabel1
            // 
            this.dungeonHeaderLabel1.AutoSize = true;
            this.dungeonHeaderLabel1.BackColor = System.Drawing.Color.Transparent;
            this.dungeonHeaderLabel1.Font = new System.Drawing.Font("Courier New", 17.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dungeonHeaderLabel1.ForeColor = System.Drawing.Color.Black;
            this.dungeonHeaderLabel1.Location = new System.Drawing.Point(386, 307);
            this.dungeonHeaderLabel1.Name = "dungeonHeaderLabel1";
            this.dungeonHeaderLabel1.Size = new System.Drawing.Size(202, 33);
            this.dungeonHeaderLabel1.TabIndex = 11;
            this.dungeonHeaderLabel1.Text = "Remember Me";
            // 
            // rememberMeToggle
            // 
            this.rememberMeToggle.AutoSize = true;
            this.rememberMeToggle.BackColor = System.Drawing.Color.Gray;
            this.rememberMeToggle.BaseColor = System.Drawing.Color.DeepSkyBlue;
            this.rememberMeToggle.BaseColorA = System.Drawing.Color.White;
            this.rememberMeToggle.BaseColorB = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.rememberMeToggle.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.rememberMeToggle.HeadColorA = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.rememberMeToggle.HeadColorB = System.Drawing.Color.White;
            this.rememberMeToggle.HeadColorC = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.rememberMeToggle.HeadColorD = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.rememberMeToggle.Location = new System.Drawing.Point(338, 313);
            this.rememberMeToggle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rememberMeToggle.Name = "rememberMeToggle";
            this.rememberMeToggle.Size = new System.Drawing.Size(48, 20);
            this.rememberMeToggle.TabIndex = 12;
            this.rememberMeToggle.Text = "hopeToggle1";
            this.rememberMeToggle.UseVisualStyleBackColor = false;
            // 
            // loginButton
            // 
            this.loginButton.BackColor = System.Drawing.Color.SeaGreen;
            this.loginButton.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.loginButton.ForeColor = System.Drawing.Color.White;
            this.loginButton.HoverColor = System.Drawing.Color.ForestGreen;
            this.loginButton.Image = null;
            this.loginButton.Location = new System.Drawing.Point(375, 363);
            this.loginButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(141, 41);
            this.loginButton.TabIndex = 13;
            this.loginButton.Text = "Login";
            // 
            // noAccountText
            // 
            this.noAccountText.AutoSize = true;
            this.noAccountText.BackColor = System.Drawing.Color.Transparent;
            this.noAccountText.Font = new System.Drawing.Font("Ebrima", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.noAccountText.ForeColor = System.Drawing.Color.Black;
            this.noAccountText.Location = new System.Drawing.Point(386, 424);
            this.noAccountText.Name = "noAccountText";
            this.noAccountText.Size = new System.Drawing.Size(107, 23);
            this.noAccountText.TabIndex = 11;
            this.noAccountText.Text = "No account?";
            // 
            // createAccountText
            // 
            this.createAccountText.AutoSize = true;
            this.createAccountText.BackColor = System.Drawing.Color.Transparent;
            this.createAccountText.Font = new System.Drawing.Font("Ebrima", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.createAccountText.ForeColor = System.Drawing.Color.Black;
            this.createAccountText.Location = new System.Drawing.Point(350, 449);
            this.createAccountText.Name = "createAccountText";
            this.createAccountText.Size = new System.Drawing.Size(153, 23);
            this.createAccountText.TabIndex = 11;
            this.createAccountText.Text = "Create an account";
            // 
            // hereLinkText
            // 
            this.hereLinkText.AutoSize = true;
            this.hereLinkText.BackColor = System.Drawing.Color.Transparent;
            this.hereLinkText.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hereLinkText.Font = new System.Drawing.Font("Ebrima", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.hereLinkText.ForeColor = System.Drawing.Color.MediumBlue;
            this.hereLinkText.Location = new System.Drawing.Point(497, 449);
            this.hereLinkText.Name = "hereLinkText";
            this.hereLinkText.Size = new System.Drawing.Size(45, 23);
            this.hereLinkText.TabIndex = 11;
            this.hereLinkText.Text = "here";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.rememberMeToggle);
            this.Controls.Add(this.hereLinkText);
            this.Controls.Add(this.createAccountText);
            this.Controls.Add(this.noAccountText);
            this.Controls.Add(this.dungeonHeaderLabel1);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.usernameBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

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