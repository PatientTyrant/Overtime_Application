namespace WindowsFormsApp1.Formlar
{
    partial class PersonelImport
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.cboSheet = new System.Windows.Forms.ComboBox();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.dbMesaiDataSet = new WindowsFormsApp1.dbMesaiDataSet();
            this.dbPersonellerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbPersonellerTableAdapter = new WindowsFormsApp1.dbMesaiDataSetTableAdapters.dbPersonellerTableAdapter();
            this.ıDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sicilNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.personelAdiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pasifDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ısTanimiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unvanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gtarihDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kullaniciDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tarihDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbMesaiDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbPersonellerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ıDDataGridViewTextBoxColumn,
            this.departIDDataGridViewTextBoxColumn,
            this.sicilNoDataGridViewTextBoxColumn,
            this.personelAdiDataGridViewTextBoxColumn,
            this.pasifDataGridViewCheckBoxColumn,
            this.ısTanimiDataGridViewTextBoxColumn,
            this.unvanDataGridViewTextBoxColumn,
            this.gtarihDataGridViewTextBoxColumn,
            this.kullaniciDataGridViewTextBoxColumn,
            this.tarihDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.dbPersonellerBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(1, 1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(797, 233);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "File Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 279);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sheet";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(718, 244);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(50, 23);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // cboSheet
            // 
            this.cboSheet.FormattingEnabled = true;
            this.cboSheet.Location = new System.Drawing.Point(75, 276);
            this.cboSheet.Name = "cboSheet";
            this.cboSheet.Size = new System.Drawing.Size(78, 21);
            this.cboSheet.TabIndex = 4;
            this.cboSheet.SelectedIndexChanged += new System.EventHandler(this.cboSheet_SelectedIndexChanged);
            // 
            // txtFilename
            // 
            this.txtFilename.Location = new System.Drawing.Point(75, 244);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.ReadOnly = true;
            this.txtFilename.Size = new System.Drawing.Size(627, 20);
            this.txtFilename.TabIndex = 5;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(172, 276);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 6;
            this.btnImport.Text = "&Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // dbMesaiDataSet
            // 
            this.dbMesaiDataSet.DataSetName = "dbMesaiDataSet";
            this.dbMesaiDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dbPersonellerBindingSource
            // 
            this.dbPersonellerBindingSource.DataMember = "dbPersoneller";
            this.dbPersonellerBindingSource.DataSource = this.dbMesaiDataSet;
            // 
            // dbPersonellerTableAdapter
            // 
            this.dbPersonellerTableAdapter.ClearBeforeFill = true;
            // 
            // ıDDataGridViewTextBoxColumn
            // 
            this.ıDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.ıDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.ıDDataGridViewTextBoxColumn.Name = "ıDDataGridViewTextBoxColumn";
            this.ıDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // departIDDataGridViewTextBoxColumn
            // 
            this.departIDDataGridViewTextBoxColumn.DataPropertyName = "departID";
            this.departIDDataGridViewTextBoxColumn.HeaderText = "departID";
            this.departIDDataGridViewTextBoxColumn.Name = "departIDDataGridViewTextBoxColumn";
            this.departIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sicilNoDataGridViewTextBoxColumn
            // 
            this.sicilNoDataGridViewTextBoxColumn.DataPropertyName = "SicilNo";
            this.sicilNoDataGridViewTextBoxColumn.HeaderText = "SicilNo";
            this.sicilNoDataGridViewTextBoxColumn.Name = "sicilNoDataGridViewTextBoxColumn";
            this.sicilNoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // personelAdiDataGridViewTextBoxColumn
            // 
            this.personelAdiDataGridViewTextBoxColumn.DataPropertyName = "personelAdi";
            this.personelAdiDataGridViewTextBoxColumn.HeaderText = "personelAdi";
            this.personelAdiDataGridViewTextBoxColumn.Name = "personelAdiDataGridViewTextBoxColumn";
            this.personelAdiDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pasifDataGridViewCheckBoxColumn
            // 
            this.pasifDataGridViewCheckBoxColumn.DataPropertyName = "Pasif";
            this.pasifDataGridViewCheckBoxColumn.HeaderText = "Pasif";
            this.pasifDataGridViewCheckBoxColumn.Name = "pasifDataGridViewCheckBoxColumn";
            this.pasifDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // ısTanimiDataGridViewTextBoxColumn
            // 
            this.ısTanimiDataGridViewTextBoxColumn.DataPropertyName = "IsTanimi";
            this.ısTanimiDataGridViewTextBoxColumn.HeaderText = "IsTanimi";
            this.ısTanimiDataGridViewTextBoxColumn.Name = "ısTanimiDataGridViewTextBoxColumn";
            this.ısTanimiDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // unvanDataGridViewTextBoxColumn
            // 
            this.unvanDataGridViewTextBoxColumn.DataPropertyName = "Unvan";
            this.unvanDataGridViewTextBoxColumn.HeaderText = "Unvan";
            this.unvanDataGridViewTextBoxColumn.Name = "unvanDataGridViewTextBoxColumn";
            this.unvanDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // gtarihDataGridViewTextBoxColumn
            // 
            this.gtarihDataGridViewTextBoxColumn.DataPropertyName = "Gtarih";
            this.gtarihDataGridViewTextBoxColumn.HeaderText = "Gtarih";
            this.gtarihDataGridViewTextBoxColumn.Name = "gtarihDataGridViewTextBoxColumn";
            this.gtarihDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // kullaniciDataGridViewTextBoxColumn
            // 
            this.kullaniciDataGridViewTextBoxColumn.DataPropertyName = "Kullanici";
            this.kullaniciDataGridViewTextBoxColumn.HeaderText = "Kullanici";
            this.kullaniciDataGridViewTextBoxColumn.Name = "kullaniciDataGridViewTextBoxColumn";
            this.kullaniciDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tarihDataGridViewTextBoxColumn
            // 
            this.tarihDataGridViewTextBoxColumn.DataPropertyName = "Tarih";
            this.tarihDataGridViewTextBoxColumn.HeaderText = "Tarih";
            this.tarihDataGridViewTextBoxColumn.Name = "tarihDataGridViewTextBoxColumn";
            this.tarihDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // PersonelImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 337);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.txtFilename);
            this.Controls.Add(this.cboSheet);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "PersonelImport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            //this.Load += new System.EventHandler(this.PersonelImport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbMesaiDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbPersonellerBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.ComboBox cboSheet;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Button btnImport;
        private dbMesaiDataSet dbMesaiDataSet;
        private System.Windows.Forms.BindingSource dbPersonellerBindingSource;
        private dbMesaiDataSetTableAdapters.dbPersonellerTableAdapter dbPersonellerTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn ıDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn departIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sicilNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn personelAdiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn pasifDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ısTanimiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unvanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gtarihDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kullaniciDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tarihDataGridViewTextBoxColumn;
    }
}