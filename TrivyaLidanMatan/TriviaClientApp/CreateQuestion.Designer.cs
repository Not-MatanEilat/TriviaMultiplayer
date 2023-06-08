namespace TriviaClientApp
{
    partial class CreateQuestion
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            questionTextBox = new TextBox();
            correctAnswerTextBox = new TextBox();
            answer2TextBox = new TextBox();
            answer3TextBox = new TextBox();
            answer4TextBox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            BackButtonPress = new Button();
            createQuestionButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(269, 23);
            label1.Name = "label1";
            label1.Size = new Size(250, 45);
            label1.TabIndex = 0;
            label1.Text = "Create Question";
            // 
            // questionTextBox
            // 
            questionTextBox.Location = new Point(336, 107);
            questionTextBox.Name = "questionTextBox";
            questionTextBox.Size = new Size(100, 23);
            questionTextBox.TabIndex = 1;
            // 
            // correctAnswerTextBox
            // 
            correctAnswerTextBox.Location = new Point(336, 157);
            correctAnswerTextBox.Name = "correctAnswerTextBox";
            correctAnswerTextBox.Size = new Size(100, 23);
            correctAnswerTextBox.TabIndex = 2;
            // 
            // answer2TextBox
            // 
            answer2TextBox.Location = new Point(336, 206);
            answer2TextBox.Name = "answer2TextBox";
            answer2TextBox.Size = new Size(100, 23);
            answer2TextBox.TabIndex = 3;
            // 
            // answer3TextBox
            // 
            answer3TextBox.Location = new Point(336, 253);
            answer3TextBox.Name = "answer3TextBox";
            answer3TextBox.Size = new Size(100, 23);
            answer3TextBox.TabIndex = 3;
            // 
            // answer4TextBox
            // 
            answer4TextBox.Location = new Point(336, 301);
            answer4TextBox.Name = "answer4TextBox";
            answer4TextBox.Size = new Size(100, 23);
            answer4TextBox.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(187, 110);
            label2.Name = "label2";
            label2.Size = new Size(143, 15);
            label2.TabIndex = 4;
            label2.Text = "Question (100 Chars Max)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(160, 157);
            label3.Name = "label3";
            label3.Size = new Size(170, 15);
            label3.TabIndex = 5;
            label3.Text = "Correct Answer (20 Chars Max)";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(193, 209);
            label4.Name = "label4";
            label4.Size = new Size(137, 15);
            label4.TabIndex = 6;
            label4.Text = "Answer 2 (20 Chars Max)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(193, 256);
            label5.Name = "label5";
            label5.Size = new Size(137, 15);
            label5.TabIndex = 6;
            label5.Text = "Answer 3 (20 Chars Max)";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(193, 304);
            label6.Name = "label6";
            label6.Size = new Size(137, 15);
            label6.TabIndex = 6;
            label6.Text = "Answer 4 (20 Chars Max)";
            // 
            // BackButtonPress
            // 
            BackButtonPress.Location = new Point(15, 413);
            BackButtonPress.Name = "BackButtonPress";
            BackButtonPress.Size = new Size(75, 23);
            BackButtonPress.TabIndex = 7;
            BackButtonPress.Text = "Back";
            BackButtonPress.UseVisualStyleBackColor = true;
            BackButtonPress.Click += BackButtonPress_Click;
            // 
            // createQuestionButton
            // 
            createQuestionButton.Location = new Point(348, 341);
            createQuestionButton.Name = "createQuestionButton";
            createQuestionButton.Size = new Size(75, 23);
            createQuestionButton.TabIndex = 8;
            createQuestionButton.Text = "Create";
            createQuestionButton.UseVisualStyleBackColor = true;
            createQuestionButton.Click += createQuestionButton_Click;
            // 
            // CreateQuestion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 128, 128);
            Controls.Add(createQuestionButton);
            Controls.Add(BackButtonPress);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(answer4TextBox);
            Controls.Add(answer3TextBox);
            Controls.Add(answer2TextBox);
            Controls.Add(correctAnswerTextBox);
            Controls.Add(questionTextBox);
            Controls.Add(label1);
            Name = "CreateQuestion";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox questionTextBox;
        private TextBox correctAnswerTextBox;
        private TextBox answer2TextBox;
        private TextBox answer3TextBox;
        private TextBox answer4TextBox;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button BackButtonPress;
        private Button createQuestionButton;
    }
}
