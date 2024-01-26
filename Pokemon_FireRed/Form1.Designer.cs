namespace Pokemon_FireRed
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbTitleScreen = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbTitleScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // pbTitleScreen
            // 
            this.pbTitleScreen.Image = global::Pokemon_FireRed.Properties.Resources.TitleScreen;
            this.pbTitleScreen.Location = new System.Drawing.Point(-1, -3);
            this.pbTitleScreen.Name = "pbTitleScreen";
            this.pbTitleScreen.Size = new System.Drawing.Size(500, 352);
            this.pbTitleScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTitleScreen.TabIndex = 1;
            this.pbTitleScreen.TabStop = false;
            this.pbTitleScreen.Click += new System.EventHandler(this.pbTitleScreen_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 788);
            this.Controls.Add(this.pbTitleScreen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.pbTitleScreen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pbTitleScreen;
    }
}
