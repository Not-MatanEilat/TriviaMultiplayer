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
            nameRoomTextBox = new ReaLTaiizor.Controls.DreamTextBox();
            label2 = new Label();
            timePerQuestionBox = new ReaLTaiizor.Controls.DungeonNumeric();
            label3 = new Label();
            maxPlayersBox = new ReaLTaiizor.Controls.DungeonNumeric();
            label6 = new Label();
            questionAmountBox = new ReaLTaiizor.Controls.DungeonNumeric();
            label4 = new Label();
            createRoomButton = new ReaLTaiizor.Controls.LostAcceptButton();
            label5 = new Label();
            backButtonPress = new ReaLTaiizor.Controls.SkyButton();
            SuspendLayout();
            // 
            // nameRoomTextBox
            // 
            nameRoomTextBox.BackColor = Color.FromArgb(224, 224, 224);
            nameRoomTextBox.BorderStyle = BorderStyle.FixedSingle;
            nameRoomTextBox.ColorA = Color.Silver;
            nameRoomTextBox.ColorB = Color.FromArgb(224, 224, 224);
            nameRoomTextBox.ColorC = Color.FromArgb(224, 224, 224);
            nameRoomTextBox.ColorD = Color.FromArgb(0, 0, 0, 0);
            nameRoomTextBox.ColorE = Color.FromArgb(25, 255, 255, 255);
            nameRoomTextBox.ColorF = Color.FromArgb(64, 64, 64);
            nameRoomTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            nameRoomTextBox.ForeColor = Color.Black;
            nameRoomTextBox.Location = new Point(321, 104);
            nameRoomTextBox.Name = "nameRoomTextBox";
            nameRoomTextBox.PlaceholderText = "   Room Name";
            nameRoomTextBox.Size = new Size(187, 29);
            nameRoomTextBox.TabIndex = 7;
            nameRoomTextBox.KeyDown += Enter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Berlin Sans FB Demi", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(193, 103);
            label2.Name = "label2";
            label2.Size = new Size(122, 24);
            label2.TabIndex = 8;
            label2.Text = "Room Name";
            // 
            // timePerQuestionBox
            // 
            timePerQuestionBox.BackColor = Color.Transparent;
            timePerQuestionBox.BackColorA = Color.FromArgb(224, 224, 224);
            timePerQuestionBox.BackColorB = Color.FromArgb(254, 254, 254);
            timePerQuestionBox.BorderColor = Color.FromArgb(180, 180, 180);
            timePerQuestionBox.ButtonForeColorA = Color.FromArgb(75, 75, 75);
            timePerQuestionBox.ButtonForeColorB = Color.FromArgb(75, 75, 75);
            timePerQuestionBox.Font = new Font("Tahoma", 11F, FontStyle.Regular, GraphicsUnit.Point);
            timePerQuestionBox.ForeColor = Color.FromArgb(76, 76, 76);
            timePerQuestionBox.Location = new Point(321, 139);
            timePerQuestionBox.Maximum = 100L;
            timePerQuestionBox.Minimum = 0L;
            timePerQuestionBox.MinimumSize = new Size(93, 28);
            timePerQuestionBox.Name = "timePerQuestionBox";
            timePerQuestionBox.Size = new Size(187, 28);
            timePerQuestionBox.TabIndex = 10;
            timePerQuestionBox.Text = "dungeonNumeric1";
            timePerQuestionBox.TextAlignment = ReaLTaiizor.Controls.DungeonNumeric._TextAlignment.Near;
            timePerQuestionBox.Value = 0L;
            timePerQuestionBox.KeyDown += Enter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Berlin Sans FB Demi", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(140, 139);
            label3.Name = "label3";
            label3.Size = new Size(175, 24);
            label3.TabIndex = 8;
            label3.Text = "Time Per Question";
            // 
            // maxPlayersBox
            // 
            maxPlayersBox.BackColor = Color.Transparent;
            maxPlayersBox.BackColorA = Color.FromArgb(224, 224, 224);
            maxPlayersBox.BackColorB = Color.FromArgb(254, 254, 254);
            maxPlayersBox.BorderColor = Color.FromArgb(180, 180, 180);
            maxPlayersBox.ButtonForeColorA = Color.FromArgb(75, 75, 75);
            maxPlayersBox.ButtonForeColorB = Color.FromArgb(75, 75, 75);
            maxPlayersBox.Font = new Font("Tahoma", 11F, FontStyle.Regular, GraphicsUnit.Point);
            maxPlayersBox.ForeColor = Color.FromArgb(76, 76, 76);
            maxPlayersBox.Location = new Point(321, 173);
            maxPlayersBox.Maximum = 100L;
            maxPlayersBox.Minimum = 0L;
            maxPlayersBox.MinimumSize = new Size(93, 28);
            maxPlayersBox.Name = "maxPlayersBox";
            maxPlayersBox.Size = new Size(187, 28);
            maxPlayersBox.TabIndex = 10;
            maxPlayersBox.Text = "dungeonNumeric1";
            maxPlayersBox.TextAlignment = ReaLTaiizor.Controls.DungeonNumeric._TextAlignment.Near;
            maxPlayersBox.Value = 0L;
            maxPlayersBox.KeyDown += Enter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Berlin Sans FB Demi", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(195, 173);
            label6.Name = "label6";
            label6.Size = new Size(120, 24);
            label6.TabIndex = 8;
            label6.Text = "Max Players";
            // 
            // questionAmountBox
            // 
            questionAmountBox.BackColor = Color.Transparent;
            questionAmountBox.BackColorA = Color.FromArgb(224, 224, 224);
            questionAmountBox.BackColorB = Color.FromArgb(254, 254, 254);
            questionAmountBox.BorderColor = Color.FromArgb(180, 180, 180);
            questionAmountBox.ButtonForeColorA = Color.FromArgb(75, 75, 75);
            questionAmountBox.ButtonForeColorB = Color.FromArgb(75, 75, 75);
            questionAmountBox.Font = new Font("Tahoma", 11F, FontStyle.Regular, GraphicsUnit.Point);
            questionAmountBox.ForeColor = Color.FromArgb(76, 76, 76);
            questionAmountBox.Location = new Point(321, 207);
            questionAmountBox.Maximum = 100L;
            questionAmountBox.Minimum = 0L;
            questionAmountBox.MinimumSize = new Size(93, 28);
            questionAmountBox.Name = "questionAmountBox";
            questionAmountBox.Size = new Size(187, 28);
            questionAmountBox.TabIndex = 10;
            questionAmountBox.Text = "dungeonNumeric1";
            questionAmountBox.TextAlignment = ReaLTaiizor.Controls.DungeonNumeric._TextAlignment.Near;
            questionAmountBox.Value = 0L;
            questionAmountBox.KeyDown += Enter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Berlin Sans FB Demi", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(142, 207);
            label4.Name = "label4";
            label4.Size = new Size(173, 24);
            label4.TabIndex = 8;
            label4.Text = "Questions Amount";
            // 
            // createRoomButton
            // 
            createRoomButton.BackColor = Color.SeaGreen;
            createRoomButton.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            createRoomButton.ForeColor = Color.White;
            createRoomButton.HoverColor = Color.ForestGreen;
            createRoomButton.Image = null;
            createRoomButton.Location = new Point(341, 254);
            createRoomButton.Name = "createRoomButton";
            createRoomButton.Size = new Size(123, 31);
            createRoomButton.TabIndex = 14;
            createRoomButton.Text = "Create";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Courier New", 45F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(193, 21);
            label5.Name = "label5";
            label5.Size = new Size(425, 67);
            label5.TabIndex = 15;
            label5.Text = "Create Room";
            // 
            // backButtonPress
            // 
            backButtonPress.BackColor = Color.Transparent;
            backButtonPress.DownBGColorA = Color.FromArgb(224, 224, 224);
            backButtonPress.DownBGColorB = Color.FromArgb(224, 224, 224);
            backButtonPress.DownBorderColorA = Color.FromArgb(224, 224, 224);
            backButtonPress.DownBorderColorB = Color.FromArgb(224, 224, 224);
            backButtonPress.DownBorderColorC = Color.FromArgb(224, 224, 224);
            backButtonPress.DownBorderColorD = Color.FromArgb(224, 224, 224);
            backButtonPress.DownForeColor = Color.Black;
            backButtonPress.DownShadowForeColor = Color.Black;
            backButtonPress.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            backButtonPress.ForeColor = Color.Black;
            backButtonPress.HoverBGColorA = Color.FromArgb(224, 224, 224);
            backButtonPress.HoverBGColorB = Color.FromArgb(224, 224, 224);
            backButtonPress.HoverBorderColorA = Color.FromArgb(224, 224, 224);
            backButtonPress.HoverBorderColorB = Color.FromArgb(224, 224, 224);
            backButtonPress.HoverBorderColorC = Color.FromArgb(224, 224, 224);
            backButtonPress.HoverBorderColorD = Color.FromArgb(224, 224, 224);
            backButtonPress.HoverForeColor = Color.Black;
            backButtonPress.HoverShadowForeColor = Color.Black;
            backButtonPress.Location = new Point(21, 407);
            backButtonPress.Name = "backButtonPress";
            backButtonPress.NormalBGColorA = Color.FromArgb(245, 245, 245);
            backButtonPress.NormalBGColorB = Color.FromArgb(230, 230, 230);
            backButtonPress.NormalBorderColorA = Color.FromArgb(252, 252, 252);
            backButtonPress.NormalBorderColorB = Color.FromArgb(249, 249, 249);
            backButtonPress.NormalBorderColorC = Color.FromArgb(189, 189, 189);
            backButtonPress.NormalBorderColorD = Color.FromArgb(200, 168, 168, 168);
            backButtonPress.NormalForeColor = Color.Black;
            backButtonPress.NormalShadowForeColor = Color.FromArgb(200, 255, 255, 255);
            backButtonPress.Size = new Size(98, 26);
            backButtonPress.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            backButtonPress.TabIndex = 16;
            backButtonPress.Text = "Back";
            backButtonPress.Click += BackButtonPress_Click;
            // 
            // CreateRoom
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Green;
            Controls.Add(backButtonPress);
            Controls.Add(label5);
            Controls.Add(createRoomButton);
            Controls.Add(questionAmountBox);
            Controls.Add(maxPlayersBox);
            Controls.Add(timePerQuestionBox);
            Controls.Add(label4);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(nameRoomTextBox);
            Name = "CreateRoom";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ReaLTaiizor.Controls.DreamTextBox nameRoomTextBox;
        private Label label2;
        private ReaLTaiizor.Controls.DungeonNumeric timePerQuestionBox;
        private Label label3;
        private ReaLTaiizor.Controls.DungeonNumeric maxPlayersBox;
        private Label label6;
        private ReaLTaiizor.Controls.DungeonNumeric questionAmountBox;
        private Label label4;
        private ReaLTaiizor.Controls.LostAcceptButton createRoomButton;
        private Label label5;
        private ReaLTaiizor.Controls.SkyButton backButtonPress;
    }
}