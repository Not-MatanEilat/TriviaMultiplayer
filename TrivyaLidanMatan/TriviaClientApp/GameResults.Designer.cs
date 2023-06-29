namespace TriviaClientApp
{
    partial class GameResults
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
            resultsFlow = new FlowLayoutPanel();
            leaveButton = new ReaLTaiizor.Controls.RoyalButton();
            SuspendLayout();
            // 
            // resultsFlow
            // 
            resultsFlow.Location = new Point(180, 3);
            resultsFlow.Name = "resultsFlow";
            resultsFlow.Size = new Size(600, 444);
            resultsFlow.TabIndex = 0;
            // 
            // leaveButton
            // 
            leaveButton.BackColor = Color.FromArgb(243, 243, 243);
            leaveButton.BorderColor = Color.FromArgb(180, 180, 180);
            leaveButton.BorderThickness = 3;
            leaveButton.DrawBorder = true;
            leaveButton.Font = new Font("Berlin Sans FB Demi", 11F, FontStyle.Regular, GraphicsUnit.Point);
            leaveButton.ForeColor = Color.FromArgb(31, 31, 31);
            leaveButton.HotTrackColor = Color.FromArgb(221, 221, 221);
            leaveButton.Image = null;
            leaveButton.LayoutFlags = ReaLTaiizor.Util.RoyalLayoutFlags.ImageBeforeText;
            leaveButton.Location = new Point(14, 398);
            leaveButton.Name = "leaveButton";
            leaveButton.PressedColor = Color.FromArgb(243, 243, 243);
            leaveButton.PressedForeColor = Color.Black;
            leaveButton.Size = new Size(114, 40);
            leaveButton.TabIndex = 11;
            leaveButton.Text = "Leave";
            leaveButton.Click += leaveButton_Click;
            // 
            // GameResults
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(resultsFlow);
            Controls.Add(leaveButton);
            Name = "GameResults";
            Load += GameResults_Load;
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel resultsFlow;
        private ReaLTaiizor.Controls.RoyalButton leaveButton;
    }
}
