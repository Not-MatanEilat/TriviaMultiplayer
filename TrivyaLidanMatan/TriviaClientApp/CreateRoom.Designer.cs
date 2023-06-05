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
            label3 = new Label();
            label4 = new Label();
            createRoomButton = new Button();
            label5 = new Label();
            BackButtonPress = new Button();
            timePerQuestionBox = new NumericUpDown();
            maxPlayersBox = new NumericUpDown();
            questionAmountBox = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)timePerQuestionBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)maxPlayersBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)questionAmountBox).BeginInit();
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
            // createRoomButton
            // 
            createRoomButton.Location = new Point(379, 266);
            createRoomButton.Name = "createRoomButton";
            createRoomButton.Size = new Size(75, 23);
            createRoomButton.TabIndex = 5;
            createRoomButton.Text = "Create";
            createRoomButton.UseVisualStyleBackColor = true;
            createRoomButton.Click += button1_Click;
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
            // BackButtonPress
            // 
            BackButtonPress.Location = new Point(12, 404);
            BackButtonPress.Name = "BackButtonPress";
            BackButtonPress.Size = new Size(75, 23);
            BackButtonPress.TabIndex = 6;
            BackButtonPress.Text = "Back";
            BackButtonPress.UseVisualStyleBackColor = true;
            BackButtonPress.Click += BackButtonPress_Click;
            // 
            // timePerQuestionBox
            // 
            timePerQuestionBox.Location = new Point(367, 148);
            timePerQuestionBox.Name = "timePerQuestionBox";
            timePerQuestionBox.Size = new Size(100, 23);
            timePerQuestionBox.TabIndex = 2;
            // 
            // maxPlayersBox
            // 
            maxPlayersBox.Location = new Point(367, 188);
            maxPlayersBox.Name = "maxPlayersBox";
            maxPlayersBox.Size = new Size(100, 23);
            maxPlayersBox.TabIndex = 3;
            // 
            // questionAmountBox
            // 
            questionAmountBox.Location = new Point(367, 228);
            questionAmountBox.Name = "questionAmountBox";
            questionAmountBox.Size = new Size(100, 23);
            questionAmountBox.TabIndex = 4;
            // 
            // CreateRoom
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Green;
            Controls.Add(questionAmountBox);
            Controls.Add(maxPlayersBox);
            Controls.Add(timePerQuestionBox);
            Controls.Add(BackButtonPress);
            Controls.Add(createRoomButton);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(nameRoomTextBox);
            Controls.Add(label1);
            Name = "CreateRoom";
            ((System.ComponentModel.ISupportInitialize)timePerQuestionBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)maxPlayersBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)questionAmountBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox nameRoomTextBox;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button createRoomButton;
        private Label label5;
        private Button BackButtonPress;
        private NumericUpDown timePerQuestionBox;
        private NumericUpDown maxPlayersBox;
        private NumericUpDown questionAmountBox;
    }
}