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
    public partial class MesaiBaslat : Form
    {
        public MesaiBaslat()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_kontrol == "BEKLEMEDE")
            {
                MesaiCrud fr = new MesaiCrud();
                for (int i = 0; i < guna2DataGridView1.SelectedRows.Count; i++)
                {
                   // fr.label5.Text = guna2DataGridView1.SelectedRows[i].Cells["ID"].Value.ToString();
                }
                fr.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("İletilmiş Kayıtlarda Güncelleme yapamassınız.");
            }
        }
        public static string _kontrol;
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (btnKaydet.Text == "Mesai Başlat")
            {
                SqlConnection sqlCon = new SqlConnection();
                sqlCon.ConnectionString = UyeGris.Database;
                sqlCon.Open();
                SqlCommand sqCom = new SqlCommand();
                sqCom.Connection = sqlCon;
                sqCom.CommandText = "INSERT INTO dbMesaiBirim(depID,kullanici,onay,Tarih) VALUES(@depID,@kullanici,@onay,@Tarih)";

                sqCom.Parameters.Add("@depID", SqlDbType.Int);
                sqCom.Parameters["@depID"].Value = UyeGris.kullanici_Dep;

                sqCom.Parameters.Add("@kullanici", SqlDbType.NVarChar);
                sqCom.Parameters["@kullanici"].Value = UyeGris.kullanici_bilgi;

                if (checkBox1.Checked)
                {

                    sqCom.Parameters.Add("@onay", SqlDbType.NVarChar);
                    sqCom.Parameters["@onay"].Value = "BİRİM SORUMLUSUNDA ONAYDA";

                }
                else
                {
                    sqCom.Parameters.Add("@onay", SqlDbType.NVarChar);
                    sqCom.Parameters["@onay"].Value = "BEKLEMEDE";
                }


                sqCom.Parameters.Add("@Tarih", SqlDbType.Date);
                sqCom.Parameters["@Tarih"].Value = dtDateOfBirth.Value;


                sqCom.ExecuteNonQuery();
                sqlCon.Close();

                verilistele();
                checkBox1.Checked = false;
                MessageBox.Show("Kayıt Eklendi");
            }
            else if (btnKaydet.Text == "GÜNCELLE")
            {
                if (_kontrol == "BEKLEMEDE")
                {

                    if (!string.IsNullOrEmpty(label3.Text))
                    {
                        SqlConnection sqlCon = new SqlConnection();
                        sqlCon.ConnectionString = UyeGris.Database;
                        sqlCon.Open();

                        SqlCommand sqCom = new SqlCommand();
                        sqCom.Connection = sqlCon;

                        sqCom.CommandText = "UPDATE dbMesaiBirim SET onay=@onay  WHERE ID=" + label3.Text;


                        if (checkBox1.Checked)
                        {
                            if (UyeGris.kullanici_Onayci == 2)
                            {
                                sqCom.Parameters.Add("@onay", SqlDbType.NVarChar);
                                sqCom.Parameters["@onay"].Value = "MÜDÜR ONAYDA";
                            }
                            else
                            {
                                sqCom.Parameters.Add("@onay", SqlDbType.NVarChar);
                                sqCom.Parameters["@onay"].Value = "BİRİM SORUMLUSUNDA ONAYDA";
                            }


                        }
                        else
                        {
                            sqCom.Parameters.Add("@onay", SqlDbType.NVarChar);
                            sqCom.Parameters["@onay"].Value = "BEKLEMEDE";
                        }


                        sqCom.ExecuteNonQuery();
                        sqlCon.Close();

                        MessageBox.Show("Kayıt Güncellendi");
                    }

                    verilistele();
                    label3.Text = "";
                    checkBox1.Checked = false;
                    btnKaydet.Text = "Mesai Başlat";
                }
                else
                {
                    MessageBox.Show("İletilmiş Kayıtlarda Güncelleme yapamassınız.");
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Text = "";
            checkBox1.Checked = false;
            btnKaydet.Text = "Mesai Başlat";
        }

        private void MesaiBaslat_Load(object sender, EventArgs e)
        {
            verilistele();
        }

        private void verilistele()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = UyeGris.Database;
            con.Open();

            SqlCommand cpm = new SqlCommand();
            cpm.Connection = con;
            SqlDataAdapter adp = new SqlDataAdapter();

            cpm.CommandText = "SELECT *FROM MesaiDurum";
            cpm.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter sqAdp = new SqlDataAdapter();
            sqAdp.SelectCommand = cpm;
            con.Close();
            sqAdp.Fill(dt);

            guna2DataGridView1.DataSource = dt;
            for (int i = 0; i < guna2DataGridView1.Columns.Count; i++)
            {
                guna2DataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                int withCol = guna2DataGridView1.Columns[i].Width;
                guna2DataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                guna2DataGridView1.Columns[i].Width = withCol;
                guna2DataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
            }
            guna2DataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.Automatic;
        }

        private void guna2DataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            label3.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            if (guna2DataGridView1.Rows.Count > 0)
            {
                SqlConnection sqlCon = new SqlConnection();
                sqlCon.ConnectionString = UyeGris.Database;
                sqlCon.Open();

                SqlCommand sqCom = new SqlCommand();
                sqCom.Connection = sqlCon;

                SqlDataAdapter da = new SqlDataAdapter();
                sqCom.CommandText = "SELECT *FROM MesaiDurum WHERE  ID=" + label3.Text;
                sqCom.ExecuteNonQuery();
                DataTable dtProd = new DataTable();
                SqlDataAdapter sqDa = new SqlDataAdapter();
                sqDa.SelectCommand = sqCom;
                sqlCon.Close();
                sqDa.Fill(dtProd);
                _kontrol = dtProd.Rows[0]["onay"].ToString();
                if (_kontrol == "BEKLEMEDE")
                {
                    checkBox1.Checked = false;
                }
                else { checkBox1.Checked = true; }
                btnKaydet.Enabled = true;
                btnKaydet.Text = "GÜNCELLE";

            }
        }
    }
}
