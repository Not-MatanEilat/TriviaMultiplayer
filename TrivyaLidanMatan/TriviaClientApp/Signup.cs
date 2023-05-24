using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TriviaClientApp
{
    public partial class Signup : Form
    {
        private string username;
        private string password;
        private string email;
        public Signup()
        {
            InitializeComponent();
        }

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
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(398, 109);
            label1.Name = "label1";
            label1.Size = new Size(100, 37);
            label1.TabIndex = 0;
            label1.Text = "Signup";
            label1.Click += label1_Click;
            // 
            // usernameTextBox
            // 
            usernameTextBox.Cursor = Cursors.IBeam;
            usernameTextBox.Location = new Point(398, 194);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(100, 23);
            usernameTextBox.TabIndex = 1;
            usernameTextBox.TextChanged += textBox1_TextChanged_1;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(398, 236);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Size = new Size(100, 23);
            passwordTextBox.TabIndex = 2;
            passwordTextBox.TextChanged += passwordTextBox_TextChanged;
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(398, 278);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(100, 23);
            emailTextBox.TabIndex = 2;
            emailTextBox.TextChanged += passwordTextBox_TextChanged;
            // 
            // signupButton
            // 
            signupButton.Location = new Point(410, 334);
            signupButton.Name = "signupButton";
            signupButton.Size = new Size(75, 24);
            signupButton.TabIndex = 3;
            signupButton.Text = "Signup";
            signupButton.UseVisualStyleBackColor = true;
            signupButton.Click += signupButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(332, 197);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 4;
            label2.Text = "Username";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(332, 239);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 4;
            label3.Text = "Password";
            label3.Click += label2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(342, 286);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 4;
            label4.Text = "Email";
            label4.Click += label2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 5;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Signup
            // 
            ClientSize = new Size(920, 435);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(signupButton);
            Controls.Add(emailTextBox);
            Controls.Add(passwordTextBox);
            Controls.Add(usernameTextBox);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Signup";
            Text = "Signup";
            ResumeLayout(false);
            PerformLayout();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void signupButton_Click(object sender, EventArgs e)
        {
            username = usernameTextBox.Text;
            password = passwordTextBox.Text;
            email = emailTextBox.Text;

            TriviaClient client = TriviaClient.GetClient();

            Dictionary<string, object> result = client.Signup(username, password, email);

            Dictionary<string, object> message = result["message"] as Dictionary<string, object>;
            if (message != null)
            {
                JsonElement element = (JsonElement)message["status"];
                int status = element.GetInt32();
                if (status == TriviaClient.SUCCESS_CODE)
                {
                    MessageBox.Show("Signup Successful!");
                }
                else
                {
                    MessageBox.Show("Signup Failed!");
                }
            }
            else
            {
                MessageBox.Show("An error has occured");
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            Close();
        }
    }
}
