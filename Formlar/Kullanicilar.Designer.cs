namespace WindowsFormsApp1.Formlar
{
    partial class Kullanicilar
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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnKaydet = new Guna.UI2.WinForms.Guna2Button();
            this.lblAdSoyad = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtKullaniciAdi = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtAdSoyad = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtSifre = new Guna.UI2.WinForms.Guna2TextBox();
            this.cbmUnvan = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.cbmUnvan);
            this.guna2Panel1.Controls.Add(this.txtSifre);
            this.guna2Panel1.Controls.Add(this.txtAdSoyad);
            this.guna2Panel1.Controls.Add(this.txtKullaniciAdi);
            this.guna2Panel1.Controls.Add(this.btnKaydet);
            this.guna2Panel1.Controls.Add(this.lblAdSoyad);
            this.guna2Panel1.Controls.Add(this.guna2HtmlLabel4);
            this.guna2Panel1.Controls.Add(this.guna2HtmlLabel3);
            this.guna2Panel1.Controls.Add(this.guna2HtmlLabel1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(596, 356);
            this.guna2Panel1.TabIndex = 22;
            // 
            // btnKaydet
            // 
            this.btnKaydet.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnKaydet.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnKaydet.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnKaydet.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnKaydet.Font = new System.Drawing.Font("Franklin Gothic Heavy", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKaydet.ForeColor = System.Drawing.Color.White;
            this.btnKaydet.Location = new System.Drawing.Point(328, 261);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(185, 45);
            this.btnKaydet.TabIndex = 32;
            this.btnKaydet.Text = "KAYDET";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // lblAdSoyad
            // 
            this.lblAdSoyad.BackColor = System.Drawing.Color.Transparent;
            this.lblAdSoyad.Font = new System.Drawing.Font("Modern No. 20", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdSoyad.Location = new System.Drawing.Point(24, 97);
            this.lblAdSoyad.Name = "lblAdSoyad";
            this.lblAdSoyad.Size = new System.Drawing.Size(83, 23);
            this.lblAdSoyad.TabIndex = 24;
            this.lblAdSoyad.Text = "Ad Soyad:";
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Font = new System.Drawing.Font("Modern No. 20", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(24, 148);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(43, 23);
            this.guna2HtmlLabel4.TabIndex = 23;
            this.guna2HtmlLabel4.Text = "Sifre";
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Modern No. 20", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(24, 199);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(57, 23);
            this.guna2HtmlLabel3.TabIndex = 22;
            this.guna2HtmlLabel3.Text = "Unvan";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Modern No. 20", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(24, 49);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(123, 23);
            this.guna2HtmlLabel1.TabIndex = 20;
            this.guna2HtmlLabel1.Text = "Kullanici Adı:";
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtKullaniciAdi.DefaultText = "";
            this.txtKullaniciAdi.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtKullaniciAdi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtKullaniciAdi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtKullaniciAdi.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtKullaniciAdi.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtKullaniciAdi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtKullaniciAdi.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtKullaniciAdi.Location = new System.Drawing.Point(253, 40);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.PasswordChar = '\0';
            this.txtKullaniciAdi.PlaceholderText = "";
            this.txtKullaniciAdi.SelectedText = "";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(183, 36);
            this.txtKullaniciAdi.TabIndex = 36;
            // 
            // txtAdSoyad
            // 
            this.txtAdSoyad.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAdSoyad.DefaultText = "";
            this.txtAdSoyad.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtAdSoyad.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtAdSoyad.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAdSoyad.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAdSoyad.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAdSoyad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAdSoyad.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAdSoyad.Location = new System.Drawing.Point(253, 93);
            this.txtAdSoyad.Name = "txtAdSoyad";
            this.txtAdSoyad.PasswordChar = '\0';
            this.txtAdSoyad.PlaceholderText = "";
            this.txtAdSoyad.SelectedText = "";
            this.txtAdSoyad.Size = new System.Drawing.Size(254, 36);
            this.txtAdSoyad.TabIndex = 37;
            // 
            // txtSifre
            // 
            this.txtSifre.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSifre.DefaultText = "";
            this.txtSifre.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSifre.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSifre.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSifre.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSifre.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSifre.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSifre.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSifre.Location = new System.Drawing.Point(253, 146);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.PasswordChar = '\0';
            this.txtSifre.PlaceholderText = "";
            this.txtSifre.SelectedText = "";
            this.txtSifre.Size = new System.Drawing.Size(170, 36);
            this.txtSifre.TabIndex = 38;
            // 
            // cbmUnvan
            // 
            this.cbmUnvan.BackColor = System.Drawing.Color.Transparent;
            this.cbmUnvan.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbmUnvan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbmUnvan.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbmUnvan.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbmUnvan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbmUnvan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbmUnvan.ItemHeight = 30;
            this.cbmUnvan.Items.AddRange(new object[] {
            "FABRİKA MÜDÜRÜ",
            "BİRİM MÜDÜRÜ ",
            "ŞEF",
            "MÜHENDİS",
            "TEKNİKER",
            "VARDİYA AMİRİ"});
            this.cbmUnvan.Location = new System.Drawing.Point(253, 199);
            this.cbmUnvan.Name = "cbmUnvan";
            this.cbmUnvan.Size = new System.Drawing.Size(221, 36);
            this.cbmUnvan.TabIndex = 39;
            // 
            // Kullanicilar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 356);
            this.Controls.Add(this.guna2Panel1);
            this.Name = "Kullanicilar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kullanicilar";
            this.Load += new System.EventHandler(this.Kullanicilar_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2ComboBox cbmUnvan;
        private Guna.UI2.WinForms.Guna2TextBox txtSifre;
        private Guna.UI2.WinForms.Guna2TextBox txtAdSoyad;
        private Guna.UI2.WinForms.Guna2TextBox txtKullaniciAdi;
        private Guna.UI2.WinForms.Guna2Button btnKaydet;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblAdSoyad;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
    }
}