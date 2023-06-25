namespace TriviaClientApp
{
    partial class HeadToHeadWaitingRoom
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
            components = new System.ComponentModel.Container();
            getState = new System.Windows.Forms.Timer(components);
            topText = new Label();
            countdownStartGameTimer = new System.Windows.Forms.Timer(components);
            BackButtonPress = new ReaLTaiizor.Controls.RoyalButton();
            SuspendLayout();
            // 
            // getState
            // 
            getState.Enabled = true;
            getState.Interval = 1500;
            getState.Tick += getState_Tick;
            // 
            // topText
            // 
            topText.AutoSize = true;
            topText.Font = new Font("Berlin Sans FB Demi", 21F, FontStyle.Regular, GraphicsUnit.Point);
            topText.Location = new Point(212, 49);
            topText.Name = "topText";
            topText.Size = new Size(388, 33);
            topText.TabIndex = 0;
            topText.Text = "Waiting for another player....";
            // 
            // countdownStartGameTimer
            // 
            countdownStartGameTimer.Interval = 1000;
            countdownStartGameTimer.Tick += countdownStartGameTimer_Tick;
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
            BackButtonPress.Location = new Point(12, 398);
            BackButtonPress.Name = "BackButtonPress";
            BackButtonPress.PressedColor = Color.FromArgb(243, 243, 243);
            BackButtonPress.PressedForeColor = Color.Black;
            BackButtonPress.Size = new Size(114, 40);
            BackButtonPress.TabIndex = 11;
            BackButtonPress.Text = "Back";
            BackButtonPress.Click += BackButtonPress_Click;
            // 
            // HeadToHeadWaitingRoom
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(topText);
            Controls.Add(BackButtonPress);
            Name = "HeadToHeadWaitingRoom";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer getState;
        private Label topText;
        private System.Windows.Forms.Timer countdownStartGameTimer;
        private ReaLTaiizor.Controls.RoyalButton BackButtonPress;
    }
}
