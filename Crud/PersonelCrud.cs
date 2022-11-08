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
    public partial class PersonelCrud : Form
    {
        public PersonelCrud()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (btnKaydet.Text == "KAYDET" && txtSicil.Text!=null && txtPersonel.Text!=null)
            {


                SqlConnection sqlCon = new SqlConnection();
                sqlCon.ConnectionString = UyeGris.Database;
                sqlCon.Open();
                SqlCommand sqCom = new SqlCommand();
                sqCom.Connection = sqlCon;
                sqCom.CommandText = "INSERT INTO dbPersoneller(departID,SicilNo,personelAdi,Pasif,IsTanimi,Unvan,Gtarih,Kullanici,Tarih)" +
                    " VALUES(@departID,@SicilNo,@personelAdi,@Pasif,@IsTanimi,@Unvan,@Gtarih,@Kullanici,@Tarih)";


                sqCom.Parameters.Add("@departID", SqlDbType.Int);
                sqCom.Parameters["@departID"].Value = Convert.ToInt32(cboDep.SelectedValue);

                sqCom.Parameters.Add("@SicilNo", SqlDbType.Int);
                sqCom.Parameters["@SicilNo"].Value = Convert.ToInt32(txtSicil.Text);

                sqCom.Parameters.Add("@personelAdi", SqlDbType.NVarChar);
                sqCom.Parameters["@personelAdi"].Value = txtPersonel.Text;

                sqCom.Parameters.Add("@Pasif", SqlDbType.Bit);
                sqCom.Parameters["@Pasif"].Value = chkCalis.Checked;

                sqCom.Parameters.Add("@IsTanimi", SqlDbType.Text);
                sqCom.Parameters["@IsTanimi"].Value = txtIstakip.Text;

                sqCom.Parameters.Add("@Unvan", SqlDbType.NVarChar);
                sqCom.Parameters["@Unvan"].Value = txtUnvan.Text;

                sqCom.Parameters.Add("@Gtarih", SqlDbType.Date);
                sqCom.Parameters["@Gtarih"].Value = dataPicture.Value;

                sqCom.Parameters.Add("@Kullanici", SqlDbType.NVarChar);
                sqCom.Parameters["@Kullanici"].Value = UyeGris.kullanici_bilgi;

                sqCom.Parameters.Add("@Tarih", SqlDbType.Date);
                sqCom.Parameters["@Tarih"].Value = DateTime.Now;
                



                sqCom.ExecuteNonQuery();
                sqlCon.Close();

                //txtSalary.Text = "";
               // cmbMaritalStatus.SelectedIndex = -1;
                MessageBox.Show("Kayıt Eklendi");
                Personeller fr = (Personeller)Application.OpenForms["Personeller"];

                fr.Show(); this.Hide();
            }
            else
            {
                MessageBox.Show("Zorunlu alanları doldurunuz");
            }


      



        }
        private void verilisteleDep()
        {
            SqlConnection conn = new SqlConnection(UyeGris.Database);
            conn.Open();
            SqlCommand sc = new SqlCommand("Select *From dbDepartman ", conn);
            SqlDataReader reader;

            reader = sc.ExecuteReader();
            DataTable dtf = new DataTable();
            dtf.Columns.Add("ID", typeof(string));
            dtf.Columns.Add("Departman", typeof(string));
            dtf.Load(reader);

            cboDep.ValueMember = "ID";
            cboDep.DisplayMember = "Departman";
            cboDep.DataSource = dtf;
            cboDep.SelectedIndex = -1;
            conn.Close();
        }

        private void PersonelCrud_Load(object sender, EventArgs e)
        {
            verilisteleDep();
        }
    }
}
