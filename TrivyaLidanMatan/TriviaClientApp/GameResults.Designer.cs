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
            leaveButton = new Button();
            SuspendLayout();
            // 
            // resultsFlow
            // 
            resultsFlow.Location = new Point(180, 3);
            resultsFlow.Name = "resultsFlow";
            resultsFlow.Size = new Size(459, 444);
            resultsFlow.TabIndex = 0;
            // 
            // leaveButton
            // 
            leaveButton.Location = new Point(14, 418);
            leaveButton.Name = "leaveButton";
            leaveButton.Size = new Size(75, 23);
            leaveButton.TabIndex = 1;
            leaveButton.Text = "Leave";
            leaveButton.UseVisualStyleBackColor = true;
            leaveButton.Click += leaveButton_Click;
            // 
            // GameResults
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(leaveButton);
            Controls.Add(resultsFlow);
            Name = "GameResults";
            Load += GameResults_Load;
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel resultsFlow;
        private Button leaveButton;
    }
}
