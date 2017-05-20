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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MainTab = new MetroFramework.Controls.MetroTabControl();
            this.TabPagePatienstOnClinic = new MetroFramework.Controls.MetroTabPage();
            this.btnRelease = new MetroFramework.Controls.MetroButton();
            this.btnHealthRecords = new MetroFramework.Controls.MetroButton();
            this.dgvPatients = new MetroFramework.Controls.MetroGrid();
            this.TabPagePatientsSearch = new MetroFramework.Controls.MetroTabPage();
            this.btnSearch = new MetroFramework.Controls.MetroButton();
            this.lblSearchBy = new MetroFramework.Controls.MetroLabel();
            this.cmbSearchBy = new MetroFramework.Controls.MetroComboBox();
            this.TabPageQueue = new MetroFramework.Controls.MetroTabPage();
            this.btnAcceptPatient = new MetroFramework.Controls.MetroButton();
            this.dgvQueue = new MetroFramework.Controls.MetroGrid();
            this.TabPagePatientView = new MetroFramework.Controls.MetroTabPage();
            this.TabPageInformation = new MetroFramework.Controls.MetroTabPage();
            this.lblCSName = new MetroFramework.Controls.MetroLabel();
            this.lblVacantBeds = new MetroFramework.Controls.MetroLabel();
            this.lblAdressClinic = new MetroFramework.Controls.MetroLabel();
            this.lblClinicName = new MetroFramework.Controls.MetroLabel();
            this.lblCCName = new MetroFramework.Controls.MetroLabel();
            this.lblChiefName = new MetroFramework.Controls.MetroLabel();
            this.lblVacant = new MetroFramework.Controls.MetroLabel();
            this.lblAdress = new MetroFramework.Controls.MetroLabel();
            this.lblClinic = new MetroFramework.Controls.MetroLabel();
            this.lblClinicCenter = new MetroFramework.Controls.MetroLabel();
            this.lblUserName = new MetroFramework.Controls.MetroLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtSearch = new MetroFramework.Controls.MetroTextBox();
            this.MainTab.SuspendLayout();
            this.TabPagePatienstOnClinic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).BeginInit();
            this.TabPagePatientsSearch.SuspendLayout();
            this.TabPageQueue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueue)).BeginInit();
            this.TabPageInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // MainTab
            // 
            this.MainTab.Controls.Add(this.TabPagePatienstOnClinic);
            this.MainTab.Controls.Add(this.TabPagePatientsSearch);
            this.MainTab.Controls.Add(this.TabPageQueue);
            this.MainTab.Controls.Add(this.TabPagePatientView);
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
            // 
            // btnRelease
            // 
            this.btnRelease.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRelease.Location = new System.Drawing.Point(592, 87);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(111, 46);
            this.btnRelease.Style = MetroFramework.MetroColorStyle.Green;
            this.btnRelease.TabIndex = 4;
            this.btnRelease.Text = "Otpusti sa klinike";
            this.btnRelease.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnRelease.UseSelectable = true;
            // 
            // btnHealthRecords
            // 
            this.btnHealthRecords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHealthRecords.Location = new System.Drawing.Point(592, 24);
            this.btnHealthRecords.Name = "btnHealthRecords";
            this.btnHealthRecords.Size = new System.Drawing.Size(111, 41);
            this.btnHealthRecords.Style = MetroFramework.MetroColorStyle.Green;
            this.btnHealthRecords.TabIndex = 3;
            this.btnHealthRecords.Text = "Uvid u karton";
            this.btnHealthRecords.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnHealthRecords.UseSelectable = true;
            // 
            // dgvPatients
            // 
            this.dgvPatients.AllowUserToAddRows = false;
            this.dgvPatients.AllowUserToDeleteRows = false;
            this.dgvPatients.AllowUserToResizeRows = false;
            this.dgvPatients.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPatients.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.dgvPatients.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPatients.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvPatients.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPatients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvPatients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPatients.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPatients.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvPatients.EnableHeadersVisualStyles = false;
            this.dgvPatients.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgvPatients.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.dgvPatients.Location = new System.Drawing.Point(0, 0);
            this.dgvPatients.Name = "dgvPatients";
            this.dgvPatients.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPatients.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
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
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
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
            "LBO",
            "BROJU KREVETA"});
            this.cmbSearchBy.Location = new System.Drawing.Point(111, 26);
            this.cmbSearchBy.Name = "cmbSearchBy";
            this.cmbSearchBy.Size = new System.Drawing.Size(122, 29);
            this.cmbSearchBy.Style = MetroFramework.MetroColorStyle.Green;
            this.cmbSearchBy.TabIndex = 2;
            this.cmbSearchBy.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.cmbSearchBy.UseSelectable = true;
            // 
            // TabPageQueue
            // 
            this.TabPageQueue.Controls.Add(this.btnAcceptPatient);
            this.TabPageQueue.Controls.Add(this.dgvQueue);
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
            // btnAcceptPatient
            // 
            this.btnAcceptPatient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAcceptPatient.Location = new System.Drawing.Point(608, 28);
            this.btnAcceptPatient.Name = "btnAcceptPatient";
            this.btnAcceptPatient.Size = new System.Drawing.Size(225, 50);
            this.btnAcceptPatient.Style = MetroFramework.MetroColorStyle.Green;
            this.btnAcceptPatient.TabIndex = 3;
            this.btnAcceptPatient.Text = "Primi pacijenta na kliniku";
            this.btnAcceptPatient.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnAcceptPatient.UseSelectable = true;
            // 
            // dgvQueue
            // 
            this.dgvQueue.AllowUserToAddRows = false;
            this.dgvQueue.AllowUserToDeleteRows = false;
            this.dgvQueue.AllowUserToResizeRows = false;
            this.dgvQueue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvQueue.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.dgvQueue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvQueue.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvQueue.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvQueue.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvQueue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvQueue.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvQueue.EnableHeadersVisualStyles = false;
            this.dgvQueue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgvQueue.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.dgvQueue.Location = new System.Drawing.Point(3, 15);
            this.dgvQueue.Name = "dgvQueue";
            this.dgvQueue.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvQueue.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvQueue.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvQueue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQueue.Size = new System.Drawing.Size(575, 379);
            this.dgvQueue.Style = MetroFramework.MetroColorStyle.Green;
            this.dgvQueue.TabIndex = 2;
            this.dgvQueue.Theme = MetroFramework.MetroThemeStyle.Dark;
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
            // TabPageInformation
            // 
            this.TabPageInformation.Controls.Add(this.lblCSName);
            this.TabPageInformation.Controls.Add(this.lblVacantBeds);
            this.TabPageInformation.Controls.Add(this.lblAdressClinic);
            this.TabPageInformation.Controls.Add(this.lblClinicName);
            this.TabPageInformation.Controls.Add(this.lblCCName);
            this.TabPageInformation.Controls.Add(this.lblChiefName);
            this.TabPageInformation.Controls.Add(this.lblVacant);
            this.TabPageInformation.Controls.Add(this.lblAdress);
            this.TabPageInformation.Controls.Add(this.lblClinic);
            this.TabPageInformation.Controls.Add(this.lblClinicCenter);
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
            // lblCSName
            // 
            this.lblCSName.AutoSize = true;
            this.lblCSName.Location = new System.Drawing.Point(134, 186);
            this.lblCSName.Name = "lblCSName";
            this.lblCSName.Size = new System.Drawing.Size(14, 19);
            this.lblCSName.Style = MetroFramework.MetroColorStyle.Green;
            this.lblCSName.TabIndex = 11;
            this.lblCSName.Text = "s";
            this.lblCSName.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lblVacantBeds
            // 
            this.lblVacantBeds.AutoSize = true;
            this.lblVacantBeds.Location = new System.Drawing.Point(188, 145);
            this.lblVacantBeds.Name = "lblVacantBeds";
            this.lblVacantBeds.Size = new System.Drawing.Size(16, 19);
            this.lblVacantBeds.Style = MetroFramework.MetroColorStyle.Green;
            this.lblVacantBeds.TabIndex = 10;
            this.lblVacantBeds.Text = "0";
            this.lblVacantBeds.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lblAdressClinic
            // 
            this.lblAdressClinic.AutoSize = true;
            this.lblAdressClinic.Location = new System.Drawing.Point(99, 107);
            this.lblAdressClinic.Name = "lblAdressClinic";
            this.lblAdressClinic.Size = new System.Drawing.Size(16, 19);
            this.lblAdressClinic.Style = MetroFramework.MetroColorStyle.Green;
            this.lblAdressClinic.TabIndex = 9;
            this.lblAdressClinic.Text = "a";
            this.lblAdressClinic.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lblClinicName
            // 
            this.lblClinicName.AutoSize = true;
            this.lblClinicName.Location = new System.Drawing.Point(93, 65);
            this.lblClinicName.Name = "lblClinicName";
            this.lblClinicName.Size = new System.Drawing.Size(18, 19);
            this.lblClinicName.Style = MetroFramework.MetroColorStyle.Green;
            this.lblClinicName.TabIndex = 8;
            this.lblClinicName.Text = "kl";
            this.lblClinicName.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lblCCName
            // 
            this.lblCCName.AutoSize = true;
            this.lblCCName.Location = new System.Drawing.Point(134, 24);
            this.lblCCName.Name = "lblCCName";
            this.lblCCName.Size = new System.Drawing.Size(21, 19);
            this.lblCCName.Style = MetroFramework.MetroColorStyle.Green;
            this.lblCCName.TabIndex = 7;
            this.lblCCName.Text = "kc";
            this.lblCCName.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lblChiefName
            // 
            this.lblChiefName.AutoSize = true;
            this.lblChiefName.Location = new System.Drawing.Point(39, 186);
            this.lblChiefName.Name = "lblChiefName";
            this.lblChiefName.Size = new System.Drawing.Size(88, 19);
            this.lblChiefName.Style = MetroFramework.MetroColorStyle.Green;
            this.lblChiefName.TabIndex = 6;
            this.lblChiefName.Text = "Glavna sestra:";
            this.lblChiefName.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lblVacant
            // 
            this.lblVacant.AutoSize = true;
            this.lblVacant.Location = new System.Drawing.Point(39, 145);
            this.lblVacant.Name = "lblVacant";
            this.lblVacant.Size = new System.Drawing.Size(143, 19);
            this.lblVacant.Style = MetroFramework.MetroColorStyle.Green;
            this.lblVacant.TabIndex = 5;
            this.lblVacant.Text = "Broj slobodnih kreveta:";
            this.lblVacant.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lblAdress
            // 
            this.lblAdress.AutoSize = true;
            this.lblAdress.Location = new System.Drawing.Point(39, 107);
            this.lblAdress.Name = "lblAdress";
            this.lblAdress.Size = new System.Drawing.Size(53, 19);
            this.lblAdress.Style = MetroFramework.MetroColorStyle.Green;
            this.lblAdress.TabIndex = 4;
            this.lblAdress.Text = "Adresa:";
            this.lblAdress.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lblClinic
            // 
            this.lblClinic.AutoSize = true;
            this.lblClinic.Location = new System.Drawing.Point(39, 65);
            this.lblClinic.Name = "lblClinic";
            this.lblClinic.Size = new System.Drawing.Size(48, 19);
            this.lblClinic.Style = MetroFramework.MetroColorStyle.Green;
            this.lblClinic.TabIndex = 3;
            this.lblClinic.Text = "Klinika:";
            this.lblClinic.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lblClinicCenter
            // 
            this.lblClinicCenter.AutoSize = true;
            this.lblClinicCenter.Location = new System.Drawing.Point(39, 24);
            this.lblClinicCenter.Name = "lblClinicCenter";
            this.lblClinicCenter.Size = new System.Drawing.Size(91, 19);
            this.lblClinicCenter.Style = MetroFramework.MetroColorStyle.Green;
            this.lblClinicCenter.TabIndex = 2;
            this.lblClinicCenter.Text = "Klinicki centar:";
            this.lblClinicCenter.Theme = MetroFramework.MetroThemeStyle.Dark;
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
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
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
            this.TabPageQueue.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueue)).EndInit();
            this.TabPageInformation.ResumeLayout(false);
            this.TabPageInformation.PerformLayout();
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
        private MetroFramework.Controls.MetroLabel lblSearchBy;
        private MetroFramework.Controls.MetroButton btnRelease;
        private MetroFramework.Controls.MetroButton btnHealthRecords;
        private MetroFramework.Controls.MetroGrid dgvQueue;
        private MetroFramework.Controls.MetroButton btnAcceptPatient;
        private MetroFramework.Controls.MetroLabel lblCSName;
        private MetroFramework.Controls.MetroLabel lblVacantBeds;
        private MetroFramework.Controls.MetroLabel lblAdressClinic;
        private MetroFramework.Controls.MetroLabel lblClinicName;
        private MetroFramework.Controls.MetroLabel lblCCName;
        private MetroFramework.Controls.MetroLabel lblChiefName;
        private MetroFramework.Controls.MetroLabel lblVacant;
        private MetroFramework.Controls.MetroLabel lblAdress;
        private MetroFramework.Controls.MetroLabel lblClinic;
        private MetroFramework.Controls.MetroLabel lblClinicCenter;
        private MetroFramework.Controls.MetroTextBox txtSearch;
    }
}