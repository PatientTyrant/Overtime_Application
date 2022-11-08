using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Formlar;

namespace WindowsFormsApp1.Crud
{
    public partial class KullaniciCrud : Form
    {
        public KullaniciCrud()
        {
            InitializeComponent();
        }

        private void KullaniciCrud_Load(object sender, EventArgs e)
        {

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (btnKaydet.Text == "KAYDET" && txtKadi.Text != null && txtad.Text != null && txtSifre.Text != null && txtSoyad.Text != null)
            {


                SqlConnection sqlCon = new SqlConnection();
                sqlCon.ConnectionString = UyeGris.Database;
                sqlCon.Open();
                SqlCommand sqCom = new SqlCommand();
                sqCom.Connection = sqlCon;
                sqCom.CommandText = "INSERT INTO dbKullanicilar(KullaniciAdi,Ad,SoyAd,Sifre,Unvan)" +
                    " VALUES(@KullaniciAdi,@Ad,@SoyAd,@Sifre,@Unvan)";


                sqCom.Parameters.Add("@KullaniciAdi", SqlDbType.NVarChar);
                sqCom.Parameters["@KullaniciAdi"].Value = txtKadi.Text;

                sqCom.Parameters.Add("@Ad", SqlDbType.NVarChar);
                sqCom.Parameters["@Ad"].Value = txtad.Text;

                sqCom.Parameters.Add("@SoyAd", SqlDbType.NVarChar);
                sqCom.Parameters["@SoyAd"].Value = txtSoyad.Text;

                sqCom.Parameters.Add("@Sifre", SqlDbType.NVarChar);
                sqCom.Parameters["@Sifre"].Value = txtSifre.Text;

                sqCom.Parameters.Add("@Unvan", SqlDbType.NVarChar);
                sqCom.Parameters["@Unvan"].Value = cboUnvan.Text;



                sqCom.ExecuteNonQuery();
                sqlCon.Close();

                //txtSalary.Text = "";
                // cmbMaritalStatus.SelectedIndex = -1;
                MessageBox.Show("Kayıt Eklendi");
                KullaniciList fr = (KullaniciList)Application.OpenForms["KullaniciList"];

                fr.Show(); this.Hide();
            }
            else
            {
                MessageBox.Show("Zorunlu alanları doldurunuz");
            }
        }
    }
}
