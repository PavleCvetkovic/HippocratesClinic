namespace SBP2017.Hippocrates.Bolnica.View
{
    partial class SestraBolnicar
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MainTab = new MetroFramework.Controls.MetroTabControl();
            this.TabPagePatienstOnClinic = new MetroFramework.Controls.MetroTabPage();
            this.dgvPatients = new MetroFramework.Controls.MetroGrid();
            this.TabPagePatientsSearch = new MetroFramework.Controls.MetroTabPage();
            this.btnSearch = new MetroFramework.Controls.MetroButton();
            this.txtSearch = new MetroFramework.Controls.MetroTextBox();
            this.lblSearchBy = new MetroFramework.Controls.MetroLabel();
            this.cmbSearchBy = new MetroFramework.Controls.MetroComboBox();
            this.TabPagePatientView = new MetroFramework.Controls.MetroTabPage();
            this.TabPageQueue = new MetroFramework.Controls.MetroTabPage();
            this.TabPageInformation = new MetroFramework.Controls.MetroTabPage();
            this.lblUserName = new MetroFramework.Controls.MetroLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnHealthRecords = new MetroFramework.Controls.MetroButton();
            this.btnRelease = new MetroFramework.Controls.MetroButton();
            this.MainTab.SuspendLayout();
            this.TabPagePatienstOnClinic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).BeginInit();
            this.TabPagePatientsSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // MainTab
            // 
            this.MainTab.Controls.Add(this.TabPagePatienstOnClinic);
            this.MainTab.Controls.Add(this.TabPagePatientsSearch);
            this.MainTab.Controls.Add(this.TabPagePatientView);
            this.MainTab.Controls.Add(this.TabPageQueue);
            this.MainTab.Controls.Add(this.TabPageInformation);
            this.MainTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTab.Location = new System.Drawing.Point(20, 60);
            this.MainTab.Name = "MainTab";
            this.MainTab.SelectedIndex = 1;
            this.MainTab.Size = new System.Drawing.Size(844, 439);
            this.MainTab.Style = MetroFramework.MetroColorStyle.Green;
            this.MainTab.TabIndex = 0;
            this.MainTab.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.MainTab.UseSelectable = true;
            // 
            // TabPagePatienstOnClinic
            // 
            this.TabPagePatienstOnClinic.Controls.Add(this.btnRelease);
            this.TabPagePatienstOnClinic.Controls.Add(this.btnHealthRecords);
            this.TabPagePatienstOnClinic.Controls.Add(this.dgvPatients);
            this.TabPagePatienstOnClinic.HorizontalScrollbarBarColor = true;
            this.TabPagePatienstOnClinic.HorizontalScrollbarHighlightOnWheel = false;
            this.TabPagePatienstOnClinic.HorizontalScrollbarSize = 10;
            this.TabPagePatienstOnClinic.Location = new System.Drawing.Point(4, 38);
            this.TabPagePatienstOnClinic.Name = "TabPagePatienstOnClinic";
            this.TabPagePatienstOnClinic.Size = new System.Drawing.Size(836, 397);
            this.TabPagePatienstOnClinic.Style = MetroFramework.MetroColorStyle.Green;
            this.TabPagePatienstOnClinic.TabIndex = 1;
            this.TabPagePatienstOnClinic.Text = "Pacijenti na klinici";
            this.TabPagePatienstOnClinic.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TabPagePatienstOnClinic.VerticalScrollbarBarColor = true;
            this.TabPagePatienstOnClinic.VerticalScrollbarHighlightOnWheel = false;
            this.TabPagePatienstOnClinic.VerticalScrollbarSize = 10;
            this.TabPagePatienstOnClinic.Enter += new System.EventHandler(this.TabPagePatienstOnClinic_Enter);
            // 
            // dgvPatients
            // 
            this.dgvPatients.AllowUserToResizeRows = false;
            this.dgvPatients.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.dgvPatients.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPatients.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvPatients.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPatients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPatients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPatients.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPatients.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPatients.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvPatients.EnableHeadersVisualStyles = false;
            this.dgvPatients.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgvPatients.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.dgvPatients.Location = new System.Drawing.Point(0, 0);
            this.dgvPatients.Name = "dgvPatients";
            this.dgvPatients.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPatients.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPatients.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvPatients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPatients.Size = new System.Drawing.Size(568, 397);
            this.dgvPatients.Style = MetroFramework.MetroColorStyle.Green;
            this.dgvPatients.TabIndex = 2;
            this.dgvPatients.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // TabPagePatientsSearch
            // 
            this.TabPagePatientsSearch.Controls.Add(this.btnSearch);
            this.TabPagePatientsSearch.Controls.Add(this.txtSearch);
            this.TabPagePatientsSearch.Controls.Add(this.lblSearchBy);
            this.TabPagePatientsSearch.Controls.Add(this.cmbSearchBy);
            this.TabPagePatientsSearch.HorizontalScrollbarBarColor = true;
            this.TabPagePatientsSearch.HorizontalScrollbarHighlightOnWheel = false;
            this.TabPagePatientsSearch.HorizontalScrollbarSize = 10;
            this.TabPagePatientsSearch.Location = new System.Drawing.Point(4, 38);
            this.TabPagePatientsSearch.Name = "TabPagePatientsSearch";
            this.TabPagePatientsSearch.Size = new System.Drawing.Size(836, 397);
            this.TabPagePatientsSearch.Style = MetroFramework.MetroColorStyle.Green;
            this.TabPagePatientsSearch.TabIndex = 0;
            this.TabPagePatientsSearch.Text = "Pretraga pacijenata";
            this.TabPagePatientsSearch.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TabPagePatientsSearch.VerticalScrollbarBarColor = true;
            this.TabPagePatientsSearch.VerticalScrollbarHighlightOnWheel = false;
            this.TabPagePatientsSearch.VerticalScrollbarSize = 10;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(250, 26);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(109, 69);
            this.btnSearch.Style = MetroFramework.MetroColorStyle.Green;
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Pretrazi";
            this.btnSearch.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnSearch.UseSelectable = true;
            // 
            // txtSearch
            // 
            // 
            // 
            // 
            this.txtSearch.CustomButton.Image = null;
            this.txtSearch.CustomButton.Location = new System.Drawing.Point(151, 1);
            this.txtSearch.CustomButton.Name = "";
            this.txtSearch.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtSearch.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtSearch.CustomButton.TabIndex = 1;
            this.txtSearch.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtSearch.CustomButton.UseSelectable = true;
            this.txtSearch.CustomButton.Visible = false;
            this.txtSearch.Lines = new string[0];
            this.txtSearch.Location = new System.Drawing.Point(60, 72);
            this.txtSearch.MaxLength = 32767;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSearch.SelectedText = "";
            this.txtSearch.SelectionLength = 0;
            this.txtSearch.SelectionStart = 0;
            this.txtSearch.ShortcutsEnabled = true;
            this.txtSearch.Size = new System.Drawing.Size(173, 23);
            this.txtSearch.Style = MetroFramework.MetroColorStyle.Green;
            this.txtSearch.TabIndex = 4;
            this.txtSearch.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.txtSearch.UseSelectable = true;
            this.txtSearch.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtSearch.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblSearchBy
            // 
            this.lblSearchBy.AutoSize = true;
            this.lblSearchBy.Location = new System.Drawing.Point(12, 26);
            this.lblSearchBy.Name = "lblSearchBy";
            this.lblSearchBy.Size = new System.Drawing.Size(83, 19);
            this.lblSearchBy.Style = MetroFramework.MetroColorStyle.Green;
            this.lblSearchBy.TabIndex = 3;
            this.lblSearchBy.Text = "Pretraga po:";
            this.lblSearchBy.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // cmbSearchBy
            // 
            this.cmbSearchBy.FormattingEnabled = true;
            this.cmbSearchBy.ItemHeight = 23;
            this.cmbSearchBy.Items.AddRange(new object[] {
            "JMBG",
            "BROJU KREVETA"});
            this.cmbSearchBy.Location = new System.Drawing.Point(111, 26);
            this.cmbSearchBy.Name = "cmbSearchBy";
            this.cmbSearchBy.Size = new System.Drawing.Size(122, 29);
            this.cmbSearchBy.Style = MetroFramework.MetroColorStyle.Green;
            this.cmbSearchBy.TabIndex = 2;
            this.cmbSearchBy.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.cmbSearchBy.UseSelectable = true;
            // 
            // TabPagePatientView
            // 
            this.TabPagePatientView.HorizontalScrollbarBarColor = true;
            this.TabPagePatientView.HorizontalScrollbarHighlightOnWheel = false;
            this.TabPagePatientView.HorizontalScrollbarSize = 10;
            this.TabPagePatientView.Location = new System.Drawing.Point(4, 38);
            this.TabPagePatientView.Name = "TabPagePatientView";
            this.TabPagePatientView.Size = new System.Drawing.Size(836, 397);
            this.TabPagePatientView.TabIndex = 2;
            this.TabPagePatientView.Text = "Karton pacijenta";
            this.TabPagePatientView.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TabPagePatientView.VerticalScrollbarBarColor = true;
            this.TabPagePatientView.VerticalScrollbarHighlightOnWheel = false;
            this.TabPagePatientView.VerticalScrollbarSize = 10;
            // 
            // TabPageQueue
            // 
            this.TabPageQueue.HorizontalScrollbarBarColor = true;
            this.TabPageQueue.HorizontalScrollbarHighlightOnWheel = false;
            this.TabPageQueue.HorizontalScrollbarSize = 10;
            this.TabPageQueue.Location = new System.Drawing.Point(4, 38);
            this.TabPageQueue.Name = "TabPageQueue";
            this.TabPageQueue.Size = new System.Drawing.Size(836, 397);
            this.TabPageQueue.TabIndex = 3;
            this.TabPageQueue.Text = "Lista cekanja";
            this.TabPageQueue.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TabPageQueue.VerticalScrollbarBarColor = true;
            this.TabPageQueue.VerticalScrollbarHighlightOnWheel = false;
            this.TabPageQueue.VerticalScrollbarSize = 10;
            // 
            // TabPageInformation
            // 
            this.TabPageInformation.HorizontalScrollbarBarColor = true;
            this.TabPageInformation.HorizontalScrollbarHighlightOnWheel = false;
            this.TabPageInformation.HorizontalScrollbarSize = 10;
            this.TabPageInformation.Location = new System.Drawing.Point(4, 38);
            this.TabPageInformation.Name = "TabPageInformation";
            this.TabPageInformation.Size = new System.Drawing.Size(836, 397);
            this.TabPageInformation.TabIndex = 4;
            this.TabPageInformation.Text = "Informacije o klinici";
            this.TabPageInformation.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TabPageInformation.VerticalScrollbarBarColor = true;
            this.TabPageInformation.VerticalScrollbarHighlightOnWheel = false;
            this.TabPageInformation.VerticalScrollbarSize = 10;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(158, 29);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(31, 19);
            this.lblUserName.Style = MetroFramework.MetroColorStyle.Green;
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "Ime";
            this.lblUserName.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::SBP2017.Hippocrates.Bolnica.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(771, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(86, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btnHealthRecords
            // 
            this.btnHealthRecords.Location = new System.Drawing.Point(592, 24);
            this.btnHealthRecords.Name = "btnHealthRecords";
            this.btnHealthRecords.Size = new System.Drawing.Size(111, 41);
            this.btnHealthRecords.Style = MetroFramework.MetroColorStyle.Green;
            this.btnHealthRecords.TabIndex = 3;
            this.btnHealthRecords.Text = "Uvid u karton";
            this.btnHealthRecords.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnHealthRecords.UseSelectable = true;
            // 
            // btnRelease
            // 
            this.btnRelease.Location = new System.Drawing.Point(592, 87);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(111, 46);
            this.btnRelease.Style = MetroFramework.MetroColorStyle.Green;
            this.btnRelease.TabIndex = 4;
            this.btnRelease.Text = "Otpusti sa klinike";
            this.btnRelease.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnRelease.UseSelectable = true;
            // 
            // SestraBolnicar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 519);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.MainTab);
            this.Name = "SestraBolnicar";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Dobrodosli";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.SestraBolnicar_Load);
            this.MainTab.ResumeLayout(false);
            this.TabPagePatienstOnClinic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).EndInit();
            this.TabPagePatientsSearch.ResumeLayout(false);
            this.TabPagePatientsSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl MainTab;
        private MetroFramework.Controls.MetroTabPage TabPagePatientsSearch;
        private MetroFramework.Controls.MetroTabPage TabPagePatienstOnClinic;
        private MetroFramework.Controls.MetroLabel lblUserName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroTabPage TabPagePatientView;
        private MetroFramework.Controls.MetroTabPage TabPageQueue;
        private MetroFramework.Controls.MetroTabPage TabPageInformation;
        private MetroFramework.Controls.MetroGrid dgvPatients;
        private MetroFramework.Controls.MetroComboBox cmbSearchBy;
        private MetroFramework.Controls.MetroButton btnSearch;
        private MetroFramework.Controls.MetroTextBox txtSearch;
        private MetroFramework.Controls.MetroLabel lblSearchBy;
        private MetroFramework.Controls.MetroButton btnRelease;
        private MetroFramework.Controls.MetroButton btnHealthRecords;
    }
}