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

namespace WindowsFormsApp1
{
    public partial class UyeGris : Form
    {
        public UyeGris()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection();
        public static string Database = @"server=192.168.18.13;Initial Catalog=dbMesai;
User ID=sa;Password=12345678;";
        public static int gonderilecekyetki;
        public static string gonderilecekveri;
        public static string kullanici_bilgi;
        public static int kullanici_Dep;
        public static int kullanici_Onayci;
        public static string kullanici_ADSOYAD;
        public static string kullanici_unvan;

        public static int RolDepID;
        public static int RolOnaySira;
        public static int RolKulID;
        public static int RolAdmin;
        public static int RolPersonel;

        private static bool DBConnectionStatus()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(Database))
                {
                    sqlConn.Open();
                    return (sqlConn.State == ConnectionState.Open);
                }
            }
            catch (SqlException)
            {

                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }
        private void UyeGris_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Username != String.Empty)
            {
                txtKullaniciAdi.Text = Properties.Settings.Default.Username;
                txtSifre.Text = Properties.Settings.Default.Password;
            }
            try
            {
                if (DBConnectionStatus())
                {
                    con.ConnectionString = Database;
                    //txtSifre.Focus();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
                
            
            
            if (con.State == ConnectionState.Open)
                {
                    con.Close();
                    con.Open();
                }
                else
                {
                    con.Open();
                }
            if (CheckBoxRememberMe.Checked==true)
            {
                Properties.Settings.Default.Username = txtKullaniciAdi.Text;
                Properties.Settings.Default.Password = txtSifre.Text;
                Properties.Settings.Default.Save();

            }
            if (CheckBoxRememberMe.Checked==false)
            {
                Properties.Settings.Default.Username = txtKullaniciAdi.Text;
                Properties.Settings.Default.Password = txtSifre.Text;
                Properties.Settings.Default.Save();
            }

            


            SqlParameter prm1 = new SqlParameter("@P1", txtKullaniciAdi.Text);
                SqlParameter prm2 = new SqlParameter("@P2", txtSifre.Text);
                string sql = "";
                sql = "Select *from Kullanicilar where KullaniciAdi=@P1 AND Sifre=@P2";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.Add(prm1);
                cmd.Parameters.Add(prm2);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

         
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    gonderilecekveri = "DENIM MESAİ KULLANICI =" + txtKullaniciAdi.Text;
                    kullanici_bilgi = txtKullaniciAdi.Text;


                    SqlConnection sqlCon1 = new SqlConnection();
                    sqlCon1.ConnectionString = UyeGris.Database;
                    sqlCon1.Open();
                    SqlCommand sqCom1 = new SqlCommand();
                    sqCom1.Connection = sqlCon1;
                    sqCom1.CommandText = "SELECT * FROM dbRoller where KullaniciID="+ Convert.ToInt32(dt.Rows[0]["ID"]);

                    SqlDataReader dr = sqCom1.ExecuteReader();
                    while (dr.Read())
                    {
                        RolDepID = Convert.ToInt32(dr["DepID"]);
                        RolKulID = Convert.ToInt32(dr["KullaniciID"]);
                        RolOnaySira = Convert.ToInt32(dr["onaySira"]);
                        RolAdmin = Convert.ToInt32(dr["admin"]);
                        RolPersonel = Convert.ToInt32(dr["personel"]);

                    }
                    dr.Close();
                    sqlCon1.Close();


                    Form1 fr = new Form1(); fr.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kullanıcı Adı Yada Şifre Yanlış");
                }

         
        }

        private void UyeGris_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
                
                    //checkBox işaretli ise
                    if (checkBox1.Checked)
                    {
                        //karakteri göster.
                        txtSifre.PasswordChar = '\0';
                    }
                    //değilse karakterlerin yerine * koy.
                    else
                    {
                        txtSifre.PasswordChar = '*';
                    }
                }
            
    }
}
