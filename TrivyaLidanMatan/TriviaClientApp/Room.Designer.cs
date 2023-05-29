namespace TriviaClientApp
{
    partial class Room
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
            namesListFlow = new FlowLayoutPanel();
            BackButtonPress = new Button();
            roomNameLabel = new Label();
            roomCreatorNameLabel = new Label();
            label2 = new Label();
            roomIdLabel = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(33, 51);
            label1.Name = "label1";
            label1.Size = new Size(86, 30);
            label1.TabIndex = 0;
            label1.Text = "Players:";
            label1.Click += label1_Click_1;
            // 
            // namesListFlow
            // 
            namesListFlow.FlowDirection = FlowDirection.TopDown;
            namesListFlow.Location = new Point(33, 84);
            namesListFlow.Name = "namesListFlow";
            namesListFlow.Size = new Size(220, 320);
            namesListFlow.TabIndex = 1;
            namesListFlow.Paint += flowLayoutPanel1_Paint;
            // 
            // BackButtonPress
            // 
            BackButtonPress.Location = new Point(33, 415);
            BackButtonPress.Name = "BackButtonPress";
            BackButtonPress.Size = new Size(75, 23);
            BackButtonPress.TabIndex = 6;
            BackButtonPress.Text = "Back";
            BackButtonPress.UseVisualStyleBackColor = true;
            BackButtonPress.Click += BackButtonPress_Click;
            // 
            // roomNameLabel
            // 
            roomNameLabel.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            roomNameLabel.Location = new Point(231, 0);
            roomNameLabel.Name = "roomNameLabel";
            roomNameLabel.Size = new Size(355, 45);
            roomNameLabel.TabIndex = 7;
            roomNameLabel.Text = "ErrorNameRoom";
            roomNameLabel.TextAlign = ContentAlignment.MiddleCenter;
            roomNameLabel.Click += label2_Click;
            // 
            // roomCreatorNameLabel
            // 
            roomCreatorNameLabel.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            roomCreatorNameLabel.Location = new Point(249, 45);
            roomCreatorNameLabel.Name = "roomCreatorNameLabel";
            roomCreatorNameLabel.Size = new Size(314, 36);
            roomCreatorNameLabel.TabIndex = 8;
            roomCreatorNameLabel.Text = "ErrorRoomCreator'sName";
            roomCreatorNameLabel.TextAlign = ContentAlignment.MiddleCenter;
            roomCreatorNameLabel.Click += roomCreatorNameLabel_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(651, 84);
            label2.Name = "label2";
            label2.Size = new Size(88, 28);
            label2.TabIndex = 9;
            label2.Text = "Room ID";
            // 
            // roomIdLabel
            // 
            roomIdLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            roomIdLabel.Location = new Point(620, 112);
            roomIdLabel.Name = "roomIdLabel";
            roomIdLabel.Size = new Size(145, 23);
            roomIdLabel.TabIndex = 10;
            roomIdLabel.Text = "999999";
            roomIdLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Room
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 192, 255);
            ClientSize = new Size(800, 450);
            Controls.Add(roomIdLabel);
            Controls.Add(label2);
            Controls.Add(roomCreatorNameLabel);
            Controls.Add(roomNameLabel);
            Controls.Add(BackButtonPress);
            Controls.Add(namesListFlow);
            Controls.Add(label1);
            Name = "Room";
            Text = "Room";
            Load += Room_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private FlowLayoutPanel namesListFlow;
        private Button BackButtonPress;
        private Label roomNameLabel;
        private Label roomCreatorNameLabel;
        private Label label2;
        private Label roomIdLabel;
    }
}