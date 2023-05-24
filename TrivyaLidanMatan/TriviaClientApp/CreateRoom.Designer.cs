namespace TriviaClientApp
{
    partial class CreateRoom
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
            nameRoomTextBox = new TextBox();
            label2 = new Label();
            amountQuestionsTextBox = new TextBox();
            label3 = new Label();
            maxPlayersTextBox = new TextBox();
            label4 = new Label();
            button1 = new Button();
            questionsAmountTextBox = new TextBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(295, 33);
            label1.Name = "label1";
            label1.Size = new Size(235, 50);
            label1.TabIndex = 0;
            label1.Text = "Create Room";
            // 
            // nameRoomTextBox
            // 
            nameRoomTextBox.Location = new Point(367, 108);
            nameRoomTextBox.Name = "nameRoomTextBox";
            nameRoomTextBox.Size = new Size(100, 23);
            nameRoomTextBox.TabIndex = 1;
            nameRoomTextBox.TextChanged += nameRoomTextBox_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(287, 111);
            label2.Name = "label2";
            label2.Size = new Size(74, 15);
            label2.TabIndex = 2;
            label2.Text = "Room Name";
            // 
            // amountQuestionsTextBox
            // 
            amountQuestionsTextBox.Location = new Point(367, 147);
            amountQuestionsTextBox.Name = "amountQuestionsTextBox";
            amountQuestionsTextBox.Size = new Size(100, 23);
            amountQuestionsTextBox.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(257, 150);
            label3.Name = "label3";
            label3.Size = new Size(104, 15);
            label3.TabIndex = 2;
            label3.Text = "Time Per Question";
            label3.Click += label3_Click;
            // 
            // maxPlayersTextBox
            // 
            maxPlayersTextBox.Location = new Point(367, 187);
            maxPlayersTextBox.Name = "maxPlayersTextBox";
            maxPlayersTextBox.Size = new Size(100, 23);
            maxPlayersTextBox.TabIndex = 1;
            maxPlayersTextBox.TextChanged += maxPlayersTextBox_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(287, 190);
            label4.Name = "label4";
            label4.Size = new Size(70, 15);
            label4.TabIndex = 2;
            label4.Text = "Max Players";
            label4.Click += label3_Click;
            // 
            // button1
            // 
            button1.Location = new Point(379, 266);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 3;
            button1.Text = "Create";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // questionsAmountTextBox
            // 
            questionsAmountTextBox.Location = new Point(367, 227);
            questionsAmountTextBox.Name = "questionsAmountTextBox";
            questionsAmountTextBox.Size = new Size(100, 23);
            questionsAmountTextBox.TabIndex = 1;
            questionsAmountTextBox.TextChanged += maxPlayersTextBox_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(250, 230);
            label5.Name = "label5";
            label5.Size = new Size(107, 15);
            label5.TabIndex = 2;
            label5.Text = "Questions Amount";
            label5.Click += label3_Click;
            // 
            // CreateRoom
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Green;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(questionsAmountTextBox);
            Controls.Add(maxPlayersTextBox);
            Controls.Add(amountQuestionsTextBox);
            Controls.Add(nameRoomTextBox);
            Controls.Add(label1);
            Name = "CreateRoom";
            Text = "CreateRoom";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox nameRoomTextBox;
        private Label label2;
        private TextBox amountQuestionsTextBox;
        private Label label3;
        private TextBox maxPlayersTextBox;
        private Label label4;
        private Button button1;
        private TextBox questionsAmountTextBox;
        private Label label5;
    }
}