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
            BackButtonPress = new Button();
            countdownStartGameTimer = new System.Windows.Forms.Timer(components);
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
            topText.Font = new Font("Segoe UI", 21F, FontStyle.Regular, GraphicsUnit.Point);
            topText.Location = new Point(212, 49);
            topText.Name = "topText";
            topText.Size = new Size(366, 38);
            topText.TabIndex = 0;
            topText.Text = "Waiting for another player....";
            // 
            // BackButtonPress
            // 
            BackButtonPress.Location = new Point(12, 415);
            BackButtonPress.Name = "BackButtonPress";
            BackButtonPress.Size = new Size(75, 23);
            BackButtonPress.TabIndex = 6;
            BackButtonPress.Text = "Back";
            BackButtonPress.UseVisualStyleBackColor = true;
            BackButtonPress.Click += BackButtonPress_Click;
            // 
            // countdownStartGameTimer
            // 
            countdownStartGameTimer.Interval = 1000;
            countdownStartGameTimer.Tick += countdownStartGameTimer_Tick;
            // 
            // HeadToHeadWaitingRoom
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(BackButtonPress);
            Controls.Add(topText);
            Name = "HeadToHeadWaitingRoom";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer getState;
        private Label topText;
        private Button BackButtonPress;
        private System.Windows.Forms.Timer countdownStartGameTimer;
    }
}
