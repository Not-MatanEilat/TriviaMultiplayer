namespace TriviaClientApp
{
    partial class Styles
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
            label2 = new Label();
            backButton = new ReaLTaiizor.Controls.RoyalButton();
            menuButton = new ReaLTaiizor.Controls.ParrotButton();
            submitButton = new ReaLTaiizor.Controls.LostAcceptButton();
            fieldBox = new ReaLTaiizor.Controls.DreamTextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Courier New", 45F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(20, 19);
            label1.Name = "label1";
            label1.Size = new Size(209, 67);
            label1.TabIndex = 1;
            label1.Text = "Title";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Berlin Sans FB Demi", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(35, 86);
            label2.Name = "label2";
            label2.Size = new Size(54, 24);
            label2.TabIndex = 3;
            label2.Text = "Field";
            // 
            // backButton
            // 
            backButton.BackColor = Color.FromArgb(243, 243, 243);
            backButton.BorderColor = Color.FromArgb(180, 180, 180);
            backButton.BorderThickness = 3;
            backButton.DrawBorder = true;
            backButton.Font = new Font("Berlin Sans FB Demi", 11F, FontStyle.Regular, GraphicsUnit.Point);
            backButton.ForeColor = Color.FromArgb(31, 31, 31);
            backButton.HotTrackColor = Color.FromArgb(221, 221, 221);
            backButton.Image = null;
            backButton.LayoutFlags = ReaLTaiizor.Util.RoyalLayoutFlags.ImageBeforeText;
            backButton.Location = new Point(35, 130);
            backButton.Name = "backButton";
            backButton.PressedColor = Color.FromArgb(243, 243, 243);
            backButton.PressedForeColor = Color.Black;
            backButton.Size = new Size(114, 40);
            backButton.TabIndex = 10;
            backButton.Text = "Back";
            // 
            // menuButton
            // 
            menuButton.BackgroundColor = Color.FromArgb(255, 255, 255);
            menuButton.ButtonImage = null;
            menuButton.ButtonStyle = ReaLTaiizor.Controls.ParrotButton.Style.MaterialRounded;
            menuButton.ButtonText = "Menu Button";
            menuButton.ClickBackColor = Color.FromArgb(195, 195, 195);
            menuButton.ClickTextColor = Color.Black;
            menuButton.CornerRadius = 16;
            menuButton.Font = new Font("Berlin Sans FB Demi", 11.2F, FontStyle.Regular, GraphicsUnit.Point);
            menuButton.Horizontal_Alignment = StringAlignment.Center;
            menuButton.HoverBackgroundColor = Color.FromArgb(225, 225, 225);
            menuButton.HoverTextColor = Color.Black;
            menuButton.ImagePosition = ReaLTaiizor.Controls.ParrotButton.ImgPosition.Left;
            menuButton.Location = new Point(35, 176);
            menuButton.Name = "menuButton";
            menuButton.Size = new Size(137, 36);
            menuButton.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            menuButton.TabIndex = 11;
            menuButton.TextColor = Color.Black;
            menuButton.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            menuButton.Vertical_Alignment = StringAlignment.Center;
            // 
            // submitButton
            // 
            submitButton.BackColor = Color.SeaGreen;
            submitButton.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            submitButton.ForeColor = Color.White;
            submitButton.HoverColor = Color.ForestGreen;
            submitButton.Image = null;
            submitButton.Location = new Point(35, 218);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(123, 31);
            submitButton.TabIndex = 14;
            submitButton.Text = "Submit";
            // 
            // fieldBox
            // 
            fieldBox.BackColor = Color.FromArgb(224, 224, 224);
            fieldBox.BorderStyle = BorderStyle.FixedSingle;
            fieldBox.ColorA = Color.Silver;
            fieldBox.ColorB = Color.FromArgb(224, 224, 224);
            fieldBox.ColorC = Color.FromArgb(224, 224, 224);
            fieldBox.ColorD = Color.FromArgb(0, 0, 0, 0);
            fieldBox.ColorE = Color.FromArgb(25, 255, 255, 255);
            fieldBox.ColorF = Color.FromArgb(64, 64, 64);
            fieldBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            fieldBox.ForeColor = Color.Black;
            fieldBox.Location = new Point(35, 255);
            fieldBox.Name = "fieldBox";
            fieldBox.PlaceholderText = "  Field";
            fieldBox.Size = new Size(187, 29);
            fieldBox.TabIndex = 15;
            // 
            // Styles
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(fieldBox);
            Controls.Add(submitButton);
            Controls.Add(menuButton);
            Controls.Add(backButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Styles";
            Size = new Size(902, 383);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ReaLTaiizor.Controls.RoyalButton backButton;
        private ReaLTaiizor.Controls.ParrotButton menuButton;
        private ReaLTaiizor.Controls.LostAcceptButton submitButton;
        private ReaLTaiizor.Controls.DreamTextBox fieldBox;
    }
}
