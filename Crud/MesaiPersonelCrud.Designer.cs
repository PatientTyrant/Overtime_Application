namespace WindowsFormsApp1.Crud
{
    partial class MesaiPersonelCrud
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MesaiPersonelCrud));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabRegister = new System.Windows.Forms.TabPage();
            this.cbmMesaiNedeni = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbmTatil = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMudehaleSuresi = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSalary = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtBitisSaati = new System.Windows.Forms.DateTimePicker();
            this.dtBaslamaSaati = new System.Windows.Forms.DateTimePicker();
            this.lblMaritalStatusRequired = new System.Windows.Forms.Label();
            this.lblSalary = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.cmbMaritalStatus = new System.Windows.Forms.ComboBox();
            this.lblMaritalStatus = new System.Windows.Forms.Label();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2DataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Sil = new System.Windows.Forms.DataGridViewImageColumn();
            this.guna2Panel1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabRegister.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.tabControl2);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(2);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(600, 199);
            this.guna2Panel1.TabIndex = 0;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabRegister);
            this.tabControl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl2.Location = new System.Drawing.Point(16, 2);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.RightToLeftLayout = true;
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(567, 191);
            this.tabControl2.TabIndex = 7;
            // 
            // tabRegister
            // 
            this.tabRegister.Controls.Add(this.cbmMesaiNedeni);
            this.tabRegister.Controls.Add(this.label7);
            this.tabRegister.Controls.Add(this.cbmTatil);
            this.tabRegister.Controls.Add(this.label6);
            this.tabRegister.Controls.Add(this.label4);
            this.tabRegister.Controls.Add(this.label5);
            this.tabRegister.Controls.Add(this.label3);
            this.tabRegister.Controls.Add(this.lblMudehaleSuresi);
            this.tabRegister.Controls.Add(this.label2);
            this.tabRegister.Controls.Add(this.txtSalary);
            this.tabRegister.Controls.Add(this.label1);
            this.tabRegister.Controls.Add(this.dtBitisSaati);
            this.tabRegister.Controls.Add(this.dtBaslamaSaati);
            this.tabRegister.Controls.Add(this.lblMaritalStatusRequired);
            this.tabRegister.Controls.Add(this.lblSalary);
            this.tabRegister.Controls.Add(this.btnRegister);
            this.tabRegister.Controls.Add(this.cmbMaritalStatus);
            this.tabRegister.Controls.Add(this.lblMaritalStatus);
            this.tabRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabRegister.Location = new System.Drawing.Point(4, 25);
            this.tabRegister.Name = "tabRegister";
            this.tabRegister.Padding = new System.Windows.Forms.Padding(3);
            this.tabRegister.Size = new System.Drawing.Size(559, 162);
            this.tabRegister.TabIndex = 0;
            this.tabRegister.Text = "Mesai Personel Ekle";
            this.tabRegister.UseVisualStyleBackColor = true;
            // 
            // cbmMesaiNedeni
            // 
            this.cbmMesaiNedeni.FormattingEnabled = true;
            this.cbmMesaiNedeni.Items.AddRange(new object[] {
            "İŞ BİTİRME",
            "PERSONEL YERİNE",
            "İZİNLİ",
            "SEVKİYAT",
            "MAKİNA ARIZASI",
            "ELEKTRİK ARIZASI"});
            this.cbmMesaiNedeni.Location = new System.Drawing.Point(380, 98);
            this.cbmMesaiNedeni.Margin = new System.Windows.Forms.Padding(2);
            this.cbmMesaiNedeni.Name = "cbmMesaiNedeni";
            this.cbmMesaiNedeni.Size = new System.Drawing.Size(165, 23);
            this.cbmMesaiNedeni.TabIndex = 37;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(279, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 15);
            this.label7.TabIndex = 36;
            this.label7.Text = "Mesai Nedeni:";
            // 
            // cbmTatil
            // 
            this.cbmTatil.FormattingEnabled = true;
            this.cbmTatil.Items.AddRange(new object[] {
            "HAFTA TATİLİ",
            "BAYRAM TATİLİ",
            "DOĞUM İZNİ"});
            this.cbmTatil.Location = new System.Drawing.Point(380, 67);
            this.cbmTatil.Margin = new System.Windows.Forms.Padding(2);
            this.cbmTatil.Name = "cbmTatil";
            this.cbmTatil.Size = new System.Drawing.Size(92, 23);
            this.cbmTatil.TabIndex = 35;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(298, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 15);
            this.label6.TabIndex = 33;
            this.label6.Text = "Hafta Tatili";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(250, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 15);
            this.label4.TabIndex = 32;
            this.label4.Text = "MesaiID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(340, 131);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 17);
            this.label5.TabIndex = 31;
            this.label5.Text = "...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 15);
            this.label3.TabIndex = 30;
            this.label3.Text = "Mesai Süresi";
            // 
            // lblMudehaleSuresi
            // 
            this.lblMudehaleSuresi.AutoSize = true;
            this.lblMudehaleSuresi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMudehaleSuresi.Location = new System.Drawing.Point(108, 123);
            this.lblMudehaleSuresi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMudehaleSuresi.Name = "lblMudehaleSuresi";
            this.lblMudehaleSuresi.Size = new System.Drawing.Size(20, 17);
            this.lblMudehaleSuresi.TabIndex = 29;
            this.lblMudehaleSuresi.Text = "...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(311, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 28;
            this.label2.Text = "Tanım";
            // 
            // txtSalary
            // 
            this.txtSalary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSalary.Location = new System.Drawing.Point(384, 11);
            this.txtSalary.MaxLength = 99999;
            this.txtSalary.Multiline = true;
            this.txtSalary.Name = "txtSalary";
            this.txtSalary.Size = new System.Drawing.Size(161, 45);
            this.txtSalary.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 15);
            this.label1.TabIndex = 26;
            this.label1.Text = "Bitiş";
            // 
            // dtBitisSaati
            // 
            this.dtBitisSaati.CustomFormat = "HH:mm";
            this.dtBitisSaati.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtBitisSaati.Location = new System.Drawing.Point(111, 85);
            this.dtBitisSaati.Margin = new System.Windows.Forms.Padding(2);
            this.dtBitisSaati.Name = "dtBitisSaati";
            this.dtBitisSaati.ShowUpDown = true;
            this.dtBitisSaati.Size = new System.Drawing.Size(54, 21);
            this.dtBitisSaati.TabIndex = 25;
            this.dtBitisSaati.ValueChanged += new System.EventHandler(this.dtBitisSaati_ValueChanged);
            // 
            // dtBaslamaSaati
            // 
            this.dtBaslamaSaati.CustomFormat = "HH:mm";
            this.dtBaslamaSaati.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtBaslamaSaati.Location = new System.Drawing.Point(111, 50);
            this.dtBaslamaSaati.Margin = new System.Windows.Forms.Padding(2);
            this.dtBaslamaSaati.Name = "dtBaslamaSaati";
            this.dtBaslamaSaati.ShowUpDown = true;
            this.dtBaslamaSaati.Size = new System.Drawing.Size(54, 21);
            this.dtBaslamaSaati.TabIndex = 24;
            this.dtBaslamaSaati.ValueChanged += new System.EventHandler(this.dtBaslamaSaati_ValueChanged);
            // 
            // lblMaritalStatusRequired
            // 
            this.lblMaritalStatusRequired.AutoSize = true;
            this.lblMaritalStatusRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaritalStatusRequired.ForeColor = System.Drawing.Color.Red;
            this.lblMaritalStatusRequired.Location = new System.Drawing.Point(86, 13);
            this.lblMaritalStatusRequired.Name = "lblMaritalStatusRequired";
            this.lblMaritalStatusRequired.Size = new System.Drawing.Size(21, 25);
            this.lblMaritalStatusRequired.TabIndex = 21;
            this.lblMaritalStatusRequired.Text = "*";
            // 
            // lblSalary
            // 
            this.lblSalary.AutoSize = true;
            this.lblSalary.Location = new System.Drawing.Point(16, 54);
            this.lblSalary.Name = "lblSalary";
            this.lblSalary.Size = new System.Drawing.Size(61, 15);
            this.lblSalary.TabIndex = 15;
            this.lblSalary.Text = "Başlangıç";
            // 
            // btnRegister
            // 
            this.btnRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.Location = new System.Drawing.Point(422, 124);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(122, 28);
            this.btnRegister.TabIndex = 9;
            this.btnRegister.Text = "KAYDET";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // cmbMaritalStatus
            // 
            this.cmbMaritalStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaritalStatus.FormattingEnabled = true;
            this.cmbMaritalStatus.Location = new System.Drawing.Point(111, 11);
            this.cmbMaritalStatus.Name = "cmbMaritalStatus";
            this.cmbMaritalStatus.Size = new System.Drawing.Size(152, 23);
            this.cmbMaritalStatus.TabIndex = 6;
            // 
            // lblMaritalStatus
            // 
            this.lblMaritalStatus.AutoSize = true;
            this.lblMaritalStatus.Location = new System.Drawing.Point(16, 13);
            this.lblMaritalStatus.Name = "lblMaritalStatus";
            this.lblMaritalStatus.Size = new System.Drawing.Size(56, 15);
            this.lblMaritalStatus.TabIndex = 6;
            this.lblMaritalStatus.Text = "Personel";
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Controls.Add(this.guna2DataGridView1);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 199);
            this.guna2Panel2.Margin = new System.Windows.Forms.Padding(2);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(600, 167);
            this.guna2Panel2.TabIndex = 1;
            // 
            // guna2DataGridView1
            // 
            this.guna2DataGridView1.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.guna2DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.guna2DataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.guna2DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.guna2DataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.guna2DataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.guna2DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.guna2DataGridView1.ColumnHeadersHeight = 27;
            this.guna2DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sil});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.guna2DataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.guna2DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2DataGridView1.EnableHeadersVisualStyles = false;
            this.guna2DataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.Location = new System.Drawing.Point(0, 0);
            this.guna2DataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.guna2DataGridView1.Name = "guna2DataGridView1";
            this.guna2DataGridView1.RowHeadersVisible = false;
            this.guna2DataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.guna2DataGridView1.RowTemplate.Height = 24;
            this.guna2DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.guna2DataGridView1.Size = new System.Drawing.Size(600, 167);
            this.guna2DataGridView1.TabIndex = 4;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Height = 27;
            this.guna2DataGridView1.ThemeStyle.ReadOnly = false;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.guna2DataGridView1.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Height = 24;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.guna2DataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Guna2DataGridView);
            // 
            // Sil
            // 
            this.Sil.HeaderText = "Sil";
            this.Sil.Image = ((System.Drawing.Image)(resources.GetObject("Sil.Image")));
            this.Sil.Name = "Sil";
            this.Sil.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // MesaiPersonelCrud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.guna2Panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MesaiPersonelCrud";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MesaiPersonelCrud";
            this.Load += new System.EventHandler(this.MesaiPersonelCrud_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabRegister.ResumeLayout(false);
            this.tabRegister.PerformLayout();
            this.guna2Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabRegister;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblMudehaleSuresi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSalary;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtBitisSaati;
        private System.Windows.Forms.DateTimePicker dtBaslamaSaati;
        private System.Windows.Forms.Label lblMaritalStatusRequired;
        private System.Windows.Forms.Label lblSalary;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.ComboBox cmbMaritalStatus;
        private System.Windows.Forms.Label lblMaritalStatus;
        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbmTatil;
        private System.Windows.Forms.ComboBox cbmMesaiNedeni;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewImageColumn Sil;
    }
}