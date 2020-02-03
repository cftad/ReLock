namespace SharpLocker
{
    partial class Main
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
            this.Username = new System.Windows.Forms.Label();
            this.LoginBox = new System.Windows.Forms.TextBox();
            this.Status = new System.Windows.Forms.Label();
            this.ProfileImage = new System.Windows.Forms.PictureBox();
            this.LoginBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ProfileImage)).BeginInit();
            this.SuspendLayout();
            // 
            // Username
            // 
            this.Username.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Username.AutoSize = true;
            this.Username.Font = new System.Drawing.Font("Segoe UI", 33F);
            this.Username.ForeColor = System.Drawing.Color.White;
            this.Username.Location = new System.Drawing.Point(246, 217);
            this.Username.MinimumSize = new System.Drawing.Size(403, 0);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(403, 60);
            this.Username.TabIndex = 4;
            this.Username.Text = "USERNAME";
            this.Username.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoginBox
            // 
            this.LoginBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LoginBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.LoginBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.LoginBox.Location = new System.Drawing.Point(244, 324);
            this.LoginBox.Name = "LoginBox";
            this.LoginBox.Size = new System.Drawing.Size(364, 38);
            this.LoginBox.TabIndex = 6;
            this.LoginBox.TextChanged += new System.EventHandler(this.LoginBox_TextChanged);
            // 
            // Status
            // 
            this.Status.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Status.AutoSize = true;
            this.Status.BackColor = System.Drawing.Color.Transparent;
            this.Status.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Status.ForeColor = System.Drawing.Color.White;
            this.Status.Location = new System.Drawing.Point(412, 277);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(71, 25);
            this.Status.TabIndex = 8;
            this.Status.Text = "Locked";
            // 
            // ProfileImage
            // 
            this.ProfileImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ProfileImage.BackColor = System.Drawing.Color.Transparent;
            this.ProfileImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ProfileImage.Image = global::SharpLocker.Properties.Resources.thumb_14400082930User;
            this.ProfileImage.Location = new System.Drawing.Point(345, 31);
            this.ProfileImage.Name = "ProfileImage";
            this.ProfileImage.Size = new System.Drawing.Size(199, 199);
            this.ProfileImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ProfileImage.TabIndex = 1;
            this.ProfileImage.TabStop = false;
            // 
            // LoginBtn
            // 
            this.LoginBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LoginBtn.AutoSize = true;
            this.LoginBtn.BackColor = System.Drawing.Color.Transparent;
            this.LoginBtn.BackgroundImage = global::SharpLocker.Properties.Resources.arrow;
            this.LoginBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LoginBtn.Location = new System.Drawing.Point(597, 324);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(45, 38);
            this.LoginBtn.TabIndex = 9;
            this.LoginBtn.UseVisualStyleBackColor = false;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // Main
            // 
            this.AcceptButton = this.LoginBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LoginBtn);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.LoginBox);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.ProfileImage);
            this.Name = "Main";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ProfileImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox ProfileImage;
        private System.Windows.Forms.Label Username;
        private System.Windows.Forms.TextBox LoginBox;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.Button LoginBtn;
    }
}

