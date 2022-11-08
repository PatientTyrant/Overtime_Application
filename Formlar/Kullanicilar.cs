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

namespace WindowsFormsApp1.Formlar
{
    public partial class Kullanicilar : Form
    {
        public Kullanicilar()
        {
            InitializeComponent();
        }

        private void Kullanicilar_Load(object sender, EventArgs e)
        {

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (btnKaydet.Text == "KAYDET" && txtAdSoyad.Text != null && txtKullaniciAdi.Text != null && txtSifre.Text != null)
            {


                SqlConnection sqlCon = new SqlConnection();
                sqlCon.ConnectionString = UyeGris.Database;
                sqlCon.Open();
                SqlCommand sqCom = new SqlCommand();
                sqCom.Connection = sqlCon;
                sqCom.CommandText = "INSERT INTO Kullanicilar(KullaniciAdi,Ad,Sifre,Unvan,OnayKodu,Yetkili,DepID)  VALUES(@KullaniciAdi,@Ad,@Sifre,@Unvan,@OnayKodu,@Yetkili,@DepID)";


                sqCom.Parameters.Add("@KullaniciAdi", SqlDbType.NVarChar);
                sqCom.Parameters["@KullaniciAdi"].Value = txtKullaniciAdi.Text;

                sqCom.Parameters.Add("@Ad", SqlDbType.NVarChar);
                sqCom.Parameters["@Ad"].Value = txtAdSoyad.Text;

                sqCom.Parameters.Add("@Sifre", SqlDbType.NVarChar);
                sqCom.Parameters["@Sifre"].Value = txtSifre.Text;

                sqCom.Parameters.Add("@Unvan", SqlDbType.NVarChar);
                sqCom.Parameters["@Unvan"].Value = cbmUnvan.Text;

                sqCom.Parameters.Add("@OnayKodu", SqlDbType.Int);
                sqCom.Parameters["@OnayKodu"].Value = 0;

                sqCom.Parameters.Add("@Yetkili", SqlDbType.Int);
                sqCom.Parameters["@Yetkili"].Value = 0;

                sqCom.Parameters.Add("@DepID", SqlDbType.Int);
                sqCom.Parameters["@DepID"].Value = 0;

                sqCom.ExecuteNonQuery();
                sqlCon.Close();

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
