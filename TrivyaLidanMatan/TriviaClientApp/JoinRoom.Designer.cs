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
            label1 = new Label();
            BackButtonPress = new Button();
            roomsListFlow = new FlowLayoutPanel();
            refreshButton = new Button();
            roomIdBox = new NumericUpDown();
            button1 = new Button();
            label2 = new Label();
            AutoRefresh = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)roomIdBox).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(57, 34);
            label1.Name = "label1";
            label1.Size = new Size(210, 50);
            label1.TabIndex = 0;
            label1.Text = "Join Rooms";
            // 
            // BackButtonPress
            // 
            BackButtonPress.Location = new Point(12, 415);
            BackButtonPress.Name = "BackButtonPress";
            BackButtonPress.Size = new Size(75, 23);
            BackButtonPress.TabIndex = 5;
            BackButtonPress.Text = "Back";
            BackButtonPress.UseVisualStyleBackColor = true;
            BackButtonPress.Click += BackButtonPress_Click;
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
            // roomIdBox
            // 
            roomIdBox.Location = new Point(92, 116);
            roomIdBox.Name = "roomIdBox";
            roomIdBox.Size = new Size(120, 23);
            roomIdBox.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(118, 145);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 3;
            button1.Text = "Join";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(92, 98);
            label2.Name = "label2";
            label2.Size = new Size(92, 15);
            label2.TabIndex = 10;
            label2.Text = "Join Room By Id";
            // 
            // AutoRefresh
            // 
            AutoRefresh.Enabled = true;
            AutoRefresh.Interval = 3000;
            AutoRefresh.Tick += AutoRefresh_Tick;
            // 
            // JoinRoom
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 64, 0);
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(roomIdBox);
            Controls.Add(refreshButton);
            Controls.Add(roomsListFlow);
            Controls.Add(BackButtonPress);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "JoinRoom";
            ShowInTaskbar = false;
            Text = "JoinRoom";
            Load += JoinRoom_Load;
            ((System.ComponentModel.ISupportInitialize)roomIdBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button BackButtonPress;
        private FlowLayoutPanel roomsListFlow;
        private Button refreshButton;
        private NumericUpDown roomIdBox;
        private Button button1;
        private Label label2;
        private System.Windows.Forms.Timer AutoRefresh;
    }
}