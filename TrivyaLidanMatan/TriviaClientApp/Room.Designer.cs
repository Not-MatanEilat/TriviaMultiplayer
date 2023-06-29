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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            namesListFlow = new FlowLayoutPanel();
            roomNameLabel = new Label();
            roomCreatorNameLabel = new Label();
            label2 = new Label();
            roomIdLabel = new Label();
            autoRefresh = new System.Windows.Forms.Timer(components);
            BackButtonPress = new ReaLTaiizor.Controls.RoyalButton();
            startGameButton = new ReaLTaiizor.Controls.LostAcceptButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Berlin Sans FB Demi", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(33, 51);
            label1.Name = "label1";
            label1.Size = new Size(90, 25);
            label1.TabIndex = 0;
            label1.Text = "Players:";
            // 
            // namesListFlow
            // 
            namesListFlow.FlowDirection = FlowDirection.TopDown;
            namesListFlow.Location = new Point(33, 84);
            namesListFlow.Name = "namesListFlow";
            namesListFlow.Size = new Size(220, 308);
            namesListFlow.TabIndex = 1;
            namesListFlow.Paint += flowLayoutPanel1_Paint;
            // 
            // roomNameLabel
            // 
            roomNameLabel.Font = new Font("Courier New", 24F, FontStyle.Bold, GraphicsUnit.Point);
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
            roomCreatorNameLabel.Font = new Font("Berlin Sans FB Demi", 14F, FontStyle.Regular, GraphicsUnit.Point);
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
            label2.Font = new Font("Berlin Sans FB Demi", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(651, 84);
            label2.Name = "label2";
            label2.Size = new Size(86, 24);
            label2.TabIndex = 9;
            label2.Text = "Room ID";
            // 
            // roomIdLabel
            // 
            roomIdLabel.Font = new Font("Berlin Sans FB Demi", 11F, FontStyle.Regular, GraphicsUnit.Point);
            roomIdLabel.Location = new Point(620, 112);
            roomIdLabel.Name = "roomIdLabel";
            roomIdLabel.Size = new Size(145, 23);
            roomIdLabel.TabIndex = 10;
            roomIdLabel.Text = "999999";
            roomIdLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // autoRefresh
            // 
            autoRefresh.Enabled = true;
            autoRefresh.Interval = 1000;
            autoRefresh.Tick += autoRefresh_Tick;
            // 
            // BackButtonPress
            // 
            BackButtonPress.BackColor = Color.FromArgb(243, 243, 243);
            BackButtonPress.BorderColor = Color.FromArgb(180, 180, 180);
            BackButtonPress.BorderThickness = 3;
            BackButtonPress.DrawBorder = true;
            BackButtonPress.Font = new Font("Berlin Sans FB Demi", 11F, FontStyle.Regular, GraphicsUnit.Point);
            BackButtonPress.ForeColor = Color.FromArgb(31, 31, 31);
            BackButtonPress.HotTrackColor = Color.FromArgb(221, 221, 221);
            BackButtonPress.Image = null;
            BackButtonPress.LayoutFlags = ReaLTaiizor.Util.RoyalLayoutFlags.ImageBeforeText;
            BackButtonPress.Location = new Point(14, 398);
            BackButtonPress.Name = "BackButtonPress";
            BackButtonPress.PressedColor = Color.FromArgb(243, 243, 243);
            BackButtonPress.PressedForeColor = Color.Black;
            BackButtonPress.Size = new Size(114, 40);
            BackButtonPress.TabIndex = 13;
            BackButtonPress.Text = "Back";
            BackButtonPress.Click += BackButtonPress_Click;
            // 
            // startGameButton
            // 
            startGameButton.BackColor = Color.SeaGreen;
            startGameButton.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            startGameButton.ForeColor = Color.White;
            startGameButton.HoverColor = Color.ForestGreen;
            startGameButton.Image = null;
            startGameButton.Location = new Point(353, 368);
            startGameButton.Name = "startGameButton";
            startGameButton.Size = new Size(137, 36);
            startGameButton.TabIndex = 15;
            startGameButton.Text = "Start Game";
            startGameButton.Click += startGameButton_Click;
            // 
            // Room
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SkyBlue;
            Controls.Add(roomIdLabel);
            Controls.Add(label2);
            Controls.Add(roomCreatorNameLabel);
            Controls.Add(roomNameLabel);
            Controls.Add(namesListFlow);
            Controls.Add(label1);
            Controls.Add(BackButtonPress);
            Controls.Add(startGameButton);
            Name = "Room";
            Load += Room_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private FlowLayoutPanel namesListFlow;
        private Label roomNameLabel;
        private Label roomCreatorNameLabel;
        private Label label2;
        private Label roomIdLabel;
        private System.Windows.Forms.Timer autoRefresh;
        private ReaLTaiizor.Controls.RoyalButton BackButtonPress;
        private ReaLTaiizor.Controls.LostAcceptButton startGameButton;
    }
}