namespace TriviaClientApp
{
    partial class JoinRoom
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
            roomsListFlow = new FlowLayoutPanel();
            refreshButton = new Button();
            AutoRefresh = new System.Windows.Forms.Timer(components);
            backButtonPress = new ReaLTaiizor.Controls.RoyalButton();
            label1 = new Label();
            label2 = new Label();
            roomIdBox = new ReaLTaiizor.Controls.DungeonNumeric();
            button1 = new ReaLTaiizor.Controls.LostAcceptButton();
            SuspendLayout();
            // 
            // roomsListFlow
            // 
            roomsListFlow.AutoScroll = true;
            roomsListFlow.FlowDirection = FlowDirection.TopDown;
            roomsListFlow.Location = new Point(435, 12);
            roomsListFlow.Name = "roomsListFlow";
            roomsListFlow.Size = new Size(353, 426);
            roomsListFlow.TabIndex = 6;
            roomsListFlow.WrapContents = false;
            // 
            // refreshButton
            // 
            refreshButton.Location = new Point(406, 12);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(23, 23);
            refreshButton.TabIndex = 7;
            refreshButton.TabStop = false;
            refreshButton.Text = "↻";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += refreshButton_Click;
            // 
            // AutoRefresh
            // 
            AutoRefresh.Enabled = true;
            AutoRefresh.Interval = 3000;
            AutoRefresh.Tick += AutoRefresh_Tick;
            // 
            // backButtonPress
            // 
            backButtonPress.BackColor = Color.FromArgb(243, 243, 243);
            backButtonPress.BorderColor = Color.FromArgb(180, 180, 180);
            backButtonPress.BorderThickness = 3;
            backButtonPress.DrawBorder = true;
            backButtonPress.Font = new Font("Berlin Sans FB Demi", 11F, FontStyle.Regular, GraphicsUnit.Point);
            backButtonPress.ForeColor = Color.FromArgb(31, 31, 31);
            backButtonPress.HotTrackColor = Color.FromArgb(221, 221, 221);
            backButtonPress.Image = null;
            backButtonPress.LayoutFlags = ReaLTaiizor.Util.RoyalLayoutFlags.ImageBeforeText;
            backButtonPress.Location = new Point(14, 398);
            backButtonPress.Name = "backButtonPress";
            backButtonPress.PressedColor = Color.FromArgb(243, 243, 243);
            backButtonPress.PressedForeColor = Color.Black;
            backButtonPress.Size = new Size(114, 40);
            backButtonPress.TabIndex = 12;
            backButtonPress.Text = "Back";
            backButtonPress.Click += BackButtonPress_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Courier New", 48F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(14, 12);
            label1.Name = "label1";
            label1.Size = new Size(374, 73);
            label1.TabIndex = 13;
            label1.Text = "Join Room";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Courier New", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(68, 85);
            label2.Name = "label2";
            label2.Size = new Size(214, 23);
            label2.TabIndex = 14;
            label2.Text = "Join a room by id";
            // 
            // roomIdBox
            // 
            roomIdBox.BackColor = Color.Transparent;
            roomIdBox.BackColorA = Color.FromArgb(224, 224, 224);
            roomIdBox.BackColorB = Color.FromArgb(254, 254, 254);
            roomIdBox.BorderColor = Color.FromArgb(180, 180, 180);
            roomIdBox.ButtonForeColorA = Color.FromArgb(75, 75, 75);
            roomIdBox.ButtonForeColorB = Color.FromArgb(75, 75, 75);
            roomIdBox.Font = new Font("Tahoma", 11F, FontStyle.Regular, GraphicsUnit.Point);
            roomIdBox.ForeColor = Color.FromArgb(76, 76, 76);
            roomIdBox.Location = new Point(109, 111);
            roomIdBox.Maximum = 100L;
            roomIdBox.Minimum = 0L;
            roomIdBox.MinimumSize = new Size(93, 28);
            roomIdBox.Name = "roomIdBox";
            roomIdBox.Size = new Size(138, 28);
            roomIdBox.TabIndex = 15;
            roomIdBox.Text = "dungeonNumeric1";
            roomIdBox.TextAlignment = ReaLTaiizor.Controls.DungeonNumeric._TextAlignment.Far;
            roomIdBox.Value = 0L;
            // 
            // button1
            // 
            button1.BackColor = Color.SeaGreen;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.HoverColor = Color.ForestGreen;
            button1.Image = null;
            button1.Location = new Point(130, 145);
            button1.Name = "button1";
            button1.Size = new Size(91, 25);
            button1.TabIndex = 16;
            button1.Text = "Join";
            button1.Click += button1_Click;
            // 
            // JoinRoom
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 64, 0);
            Controls.Add(button1);
            Controls.Add(roomIdBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(backButtonPress);
            Controls.Add(refreshButton);
            Controls.Add(roomsListFlow);
            Name = "JoinRoom";
            Load += JoinRoom_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private FlowLayoutPanel roomsListFlow;
        private Button refreshButton;
        private System.Windows.Forms.Timer AutoRefresh;
        private ReaLTaiizor.Controls.RoyalButton backButtonPress;
        private Label label1;
        private Label label2;
        private ReaLTaiizor.Controls.DungeonNumeric roomIdBox;
        private ReaLTaiizor.Controls.LostAcceptButton button1;
    }
}