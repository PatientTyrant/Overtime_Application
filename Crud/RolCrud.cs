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
    public partial class RolCrud : Form
    {
        public RolCrud()
        {
            InitializeComponent();
        }

        private void RolCrud_Load(object sender, EventArgs e)
        {
            verilisteleDep();
            verilisteleKul();
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
        private void verilisteleKul()
        {
            SqlConnection conn = new SqlConnection(UyeGris.Database);
            conn.Open();
            SqlCommand sc = new SqlCommand("Select *From Kullanicilar ", conn);
            SqlDataReader reader;

            reader = sc.ExecuteReader();
            DataTable dtf = new DataTable();
            dtf.Columns.Add("ID", typeof(string));
            dtf.Columns.Add("KullaniciAdi", typeof(string));
            dtf.Load(reader);

            cmbKul.ValueMember = "ID";
            cmbKul.DisplayMember = "KullaniciAdi";
            cmbKul.DataSource = dtf;
            cmbKul.SelectedIndex = -1;
            conn.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (btnKaydet.Text == "KAYDET")
            {

                SqlConnection sqlCon = new SqlConnection();
                sqlCon.ConnectionString = UyeGris.Database;
                sqlCon.Open();
                SqlCommand sqCom = new SqlCommand();
                sqCom.Connection = sqlCon;
                sqCom.CommandText = "INSERT INTO dbRoller(KullaniciID,DepID,onaySira,admin,personel)  VALUES(@KullaniciID,@DepID,@onaySira,@admin,@personel)";


                sqCom.Parameters.Add("@KullaniciID", SqlDbType.Int);
                sqCom.Parameters["@KullaniciID"].Value = cmbKul.SelectedValue;

                sqCom.Parameters.Add("@DepID", SqlDbType.Int);
                sqCom.Parameters["@DepID"].Value = cboDep.SelectedValue;

                sqCom.Parameters.Add("@onaySira", SqlDbType.Int);
                sqCom.Parameters["@onaySira"].Value = nmeric.Value;

                if (chkAdmin.Checked) 
                {
                    sqCom.Parameters.Add("@admin", SqlDbType.Int);
                    sqCom.Parameters["@admin"].Value = 1;
                }
                else
                {
                    sqCom.Parameters.Add("@admin", SqlDbType.Int);
                    sqCom.Parameters["@admin"].Value = 0;
                }
                sqCom.Parameters.Add("@personel", SqlDbType.Int);
                sqCom.Parameters["@personel"].Value = 0;



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
