namespace SBP2017.Hippocrates.Bolnica.View
{
    partial class LoginForm
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
            this.txtUser = new MetroFramework.Controls.MetroTextBox();
            this.txtPassword = new MetroFramework.Controls.MetroTextBox();
            this.lblUser = new MetroFramework.Controls.MetroLabel();
            this.lblPassword = new MetroFramework.Controls.MetroLabel();
            this.btnLogin = new MetroFramework.Controls.MetroButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUser
            // 
            // 
            // 
            // 
            this.txtUser.CustomButton.Image = null;
            this.txtUser.CustomButton.Location = new System.Drawing.Point(255, 1);
            this.txtUser.CustomButton.Name = "";
            this.txtUser.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.txtUser.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtUser.CustomButton.TabIndex = 1;
            this.txtUser.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtUser.CustomButton.UseSelectable = true;
            this.txtUser.CustomButton.Visible = false;
            this.txtUser.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtUser.Lines = new string[0];
            this.txtUser.Location = new System.Drawing.Point(243, 304);
            this.txtUser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUser.MaxLength = 32767;
            this.txtUser.Name = "txtUser";
            this.txtUser.PasswordChar = '\0';
            this.txtUser.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtUser.SelectedText = "";
            this.txtUser.SelectionLength = 0;
            this.txtUser.SelectionStart = 0;
            this.txtUser.ShortcutsEnabled = true;
            this.txtUser.Size = new System.Drawing.Size(289, 35);
            this.txtUser.Style = MetroFramework.MetroColorStyle.Green;
            this.txtUser.TabIndex = 0;
            this.txtUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtUser.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.txtUser.UseSelectable = true;
            this.txtUser.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtUser.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtPassword
            // 
            // 
            // 
            // 
            this.txtPassword.CustomButton.Image = null;
            this.txtPassword.CustomButton.Location = new System.Drawing.Point(255, 1);
            this.txtPassword.CustomButton.Name = "";
            this.txtPassword.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.txtPassword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPassword.CustomButton.TabIndex = 1;
            this.txtPassword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPassword.CustomButton.UseSelectable = true;
            this.txtPassword.CustomButton.Visible = false;
            this.txtPassword.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtPassword.Lines = new string[0];
            this.txtPassword.Location = new System.Drawing.Point(243, 395);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPassword.MaxLength = 32767;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPassword.SelectedText = "";
            this.txtPassword.SelectionLength = 0;
            this.txtPassword.SelectionStart = 0;
            this.txtPassword.ShortcutsEnabled = true;
            this.txtPassword.Size = new System.Drawing.Size(289, 35);
            this.txtPassword.Style = MetroFramework.MetroColorStyle.Green;
            this.txtPassword.TabIndex = 1;
            this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPassword.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.txtPassword.UseSelectable = true;
            this.txtPassword.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPassword.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblUser.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblUser.Location = new System.Drawing.Point(351, 265);
            this.lblUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(87, 25);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "Korisnik:";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblUser.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblPassword.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblPassword.Location = new System.Drawing.Point(351, 356);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(82, 25);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Lozinka:";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblPassword.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(335, 453);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(112, 42);
            this.btnLogin.Style = MetroFramework.MetroColorStyle.Green;
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Prijavi se";
            this.btnLogin.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnLogin.UseSelectable = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SBP2017.Hippocrates.Bolnica.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(298, 73);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(182, 156);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // LoginForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(778, 575);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUser);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.Padding = new System.Windows.Forms.Padding(30, 92, 30, 31);
            this.Resizable = false;
            this.ShowIcon = false;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Prijava na sistem";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.VisibleChanged += new System.EventHandler(this.LoginForm_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox txtUser;
        private MetroFramework.Controls.MetroTextBox txtPassword;
        private MetroFramework.Controls.MetroLabel lblUser;
        private MetroFramework.Controls.MetroLabel lblPassword;
        private MetroFramework.Controls.MetroButton btnLogin;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}