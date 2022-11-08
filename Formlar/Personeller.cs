using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Excel;
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
using WindowsFormsApp1.Crud;


namespace WindowsFormsApp1.Formlar
{
    public partial class Personeller : Form
    {
        public Personeller()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();
        private void Personeller_Load(object sender, EventArgs e)
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

            cpm.CommandText = "SELECT dbo.dbPersoneller.ID, dbo.dbDepartman.Departman AS Birim, dbo.dbPersoneller.personelAdi AS [Personel Adı], dbo.dbPersoneller.SicilNo AS [Sicil No], dbo.dbPersoneller.Unvan, dbo.dbPersoneller.IsTanimi AS [İş Tanımı]," +
                "                 dbo.dbPersoneller.Gtarih AS[Giriş Tarihi], dbo.dbPersoneller.Kullanici, dbo.dbPersoneller.Tarih AS[Ekleme Tarihi]" +
                "FROM dbo.dbDepartman INNER JOIN   dbo.dbPersoneller ON dbo.dbDepartman.ID = dbo.dbPersoneller.departID";
            cpm.ExecuteNonQuery();


            SqlDataAdapter sqAdp = new SqlDataAdapter();

            sqAdp.SelectCommand = cpm;
            con.Close();
            sqAdp.Fill(ds, "Table");

            guna2DataGridView1.DataSource = ds.Tables[0];
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

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            PersonelCrud per=new PersonelCrud();
            per.ShowDialog(this);
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string X = guna2DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "Edit")
                {
                    if (MessageBox.Show("Düzenleme Yapılacak  ?", "Mesaj", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    // customersBindingSource.RemoveCurrent();
                    {
                        SqlConnection sqlCon = new SqlConnection();
                        sqlCon.ConnectionString = UyeGris.Database;
                        sqlCon.Open();
                        SqlCommand sqCom = new SqlCommand();
                        sqCom.Connection = sqlCon;
                        sqCom.CommandText = "UPDATE dbPersoneller SET SicilNo=@SicilNo,personelAdi=@personelAdi,IsTanimi=@IsTanimi,Unvan=@Unvan where ID=" + X;

                        sqCom.Parameters.Add("@SicilNo", SqlDbType.Int);
                        sqCom.Parameters["@SicilNo"].Value = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());

                        sqCom.Parameters.Add("@personelAdi", SqlDbType.NVarChar);
                        sqCom.Parameters["@personelAdi"].Value = guna2DataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

                        sqCom.Parameters.Add("@IsTanimi", SqlDbType.NVarChar);
                        sqCom.Parameters["@IsTanimi"].Value = guna2DataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();

                        sqCom.Parameters.Add("@Unvan", SqlDbType.NVarChar);
                        sqCom.Parameters["@Unvan"].Value = guna2DataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();

                        sqCom.ExecuteNonQuery();
                        sqlCon.Close();
                    }

                }
                if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "Sil")
                {
                    if (MessageBox.Show("Kayıt silinecektir ! ?", "Mesaj", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    // customersBindingSource.RemoveCurrent();
                    {
                        SqlConnection sqlCon = new SqlConnection();
                        sqlCon.ConnectionString = UyeGris.Database;
                        sqlCon.Open();

                        SqlCommand sqCom1 = new SqlCommand();
                        sqCom1.Connection = sqlCon;

                        sqCom1.CommandText = "Delete From dbPersoneller where ID=" + X;
                        sqCom1.ExecuteNonQuery();
                        sqlCon.Close();

                        MessageBox.Show("tamam");
                    }

                }
            }
            catch { }
            /**
                         SqlConnection sqlCon = new SqlConnection();
            sqlCon.ConnectionString = @"server=192.168.18.13;Initial Catalog=dbdemo;
User ID=sa;Password=12345678;";
               sqlCon.Open();

                SqlCommand sqCom1 = new SqlCommand();
                sqCom1.Connection = sqlCon;

                sqCom1.CommandText = "Delete From filter";
                sqCom1.ExecuteNonQuery();
                sqlCon.Close(); 
            sqlCon.Open();

            SqlCommand sqCom = new SqlCommand();
            sqCom.Connection = sqlCon;
            sqCom.CommandText = "UPDATE filter SET dateFilterBas=@dateFilterBas,dateFilterBit=@dateFilterBit WHERE parti=1";

            sqCom.Parameters.Add("@dateFilterBas", SqlDbType.DateTime);
            sqCom.Parameters["@dateFilterBas"].Value = dateTimePicker1.Value;

            sqCom.Parameters.Add("@dateFilterBit", SqlDbType.DateTime);
            sqCom.Parameters["@dateFilterBit"].Value = dateTimePicker2.Value;

            sqCom.ExecuteNonQuery();
            sqlCon.Close(); **/
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            DataView dv;
            dv = new DataView(ds.Tables[0], "[Personel Adı] = '" + guna2TextBox1.Text + "'", "[Personel Adı] Desc", DataViewRowState.CurrentRows);
            guna2DataGridView1.DataSource = dv;
         
        }

    
        }
    }

