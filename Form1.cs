using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Formlar;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            //panelMenu.Controls.Add(leftBorderBtn);
            //Form
           // this.Text = string.Empty;
           // this.ControlBox = false;
           // this.DoubleBuffered = true;
            //this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        private Panel leftBorderBtn;
        private Form currentChildForm;
  
        private void OpenChildForm(Form childForm)
        {
            //open only form
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            //lblTitleChildForm.Text = childForm.Text;
        }
        private void guna2Button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void guna2ShadowForm1_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);


            ArrayList x = new ArrayList { 0, 1, 2, 3, 4, 5, 6, 7 };
            ArrayList y = new ArrayList { 5, 1, 5, 3, 1, 4, 9, 5 };

            ArrayList x1 = new ArrayList { 0, 1, 2, 3, 4, 5, 6, 7 };
            ArrayList y1 = new ArrayList { 2, 6, 3, 4, 3, 6, 4, 6 };

            ArrayList x2 = new ArrayList { 0, 1, 2, 3, 4, 5, 6, 7 };
            ArrayList y2 = new ArrayList { 4, 3, 2, 5, 8, 5, 6, 2 };

        }

        private void guna2Button9_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblKullanici.Text = UyeGris.kullanici_ADSOYAD;
            lblUnvan.Text = UyeGris.kullanici_unvan;

            guna2ShadowForm1.SetShadowForm(this);

            ArrayList  x = new ArrayList{0, 1, 2, 3, 4, 5, 6, 7 };
            ArrayList  y = new ArrayList{5, 5, 5, 5, 5, 5, 5, 5 };

            ArrayList  x1 = new ArrayList{0, 1, 2, 3, 4, 5, 6, 7 };
            ArrayList  y1 = new ArrayList{5, 5, 5, 5, 5, 5, 5, 5 };

            ArrayList  x2 = new ArrayList{0, 1, 2, 3, 4, 5, 6, 7 };
            ArrayList  y2 = new ArrayList { 5, 5, 5, 5, 5, 5, 5, 5 };

        


        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if(UyeGris.RolOnaySira<=2)
            {OpenChildForm(new MesaiList()); }
            else { MessageBox.Show("BU SAYFA İÇİN YETKİLİ DEĞİLSİNİZ"); }
            
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Departman());
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (UyeGris.RolAdmin == 1 || UyeGris.RolPersonel==1)
            {
                OpenChildForm(new Personeller());
            }
            else { MessageBox.Show("Giriş İzniniz bulunmamaktadır"); }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new MesaiCrud());
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            if (UyeGris.RolAdmin==1)
            {
                OpenChildForm(new KullaniciList());
            }
            else { MessageBox.Show("Giriş İzniniz bulunmamaktadır"); }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Raporlar());
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            OpenChildForm(new PersonelImport());

        }
    }
}
