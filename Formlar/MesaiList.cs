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
    public partial class MesaiList : Form
    {
        public MesaiList()
        {
            InitializeComponent();
        }
        string X;
        string OnayDurum;
     

        private void MesaiList_Load(object sender, EventArgs e)
        {
            verilistele();
          //  verilistele1();
        }

        private void verilistele()
        {
       
            SqlConnection con = new SqlConnection();
            con.ConnectionString = UyeGris.Database;
            con.Open();

            SqlCommand cpm = new SqlCommand();
            cpm.Connection = con;
            SqlDataAdapter adp = new SqlDataAdapter();
            if (UyeGris.RolAdmin == 1)
            {
                cpm.CommandText = "SELECT dbo.dbMesaiBirim.ID, dbo.dbDepartman.Departman, dbo.dbMesaiBirim.Tarih, dbo.dbMesaiBirim.kullanici, dbo.dbMesaiBirim.onay,  (SUM(DATEPART(HOUR, dbo.dbMesaiDetay.MesaiSuresi)*60) +SUM(DATEPART(MINUTE, dbo.dbMesaiDetay.MesaiSuresi)))/ 60 AS[Toplam Saat],(SUM(DATEPART(HOUR, dbo.dbMesaiDetay.MesaiSuresi) * 60) + SUM(DATEPART(MINUTE," +
                    "                                   dbo.dbMesaiDetay.MesaiSuresi))) % 60 AS Dakika FROM dbo.dbDepartman INNER JOIN  dbo.dbMesaiBirim ON dbo.dbDepartman.ID = dbo.dbMesaiBirim.depID LEFT OUTER JOIN" +
                    "            dbo.dbMesaiDetay ON dbo.dbMesaiBirim.ID = dbo.dbMesaiDetay.MesaiID where dbo.dbMesaiBirim.onay='MÜDÜR ONAYDA' " +
                    "GROUP BY dbo.dbMesaiBirim.ID, dbo.dbDepartman.Departman, dbo.dbMesaiBirim.Tarih, dbo.dbMesaiBirim.kullanici, dbo.dbMesaiBirim.onay ORDER BY dbo.dbMesaiBirim.Tarih DESC ";
            }
            else if (UyeGris.RolAdmin != 1 && UyeGris.RolOnaySira==1)
            {
                cpm.CommandText = "SELECT dbo.dbMesaiBirim.ID, dbo.dbDepartman.Departman, dbo.dbMesaiBirim.Tarih, dbo.dbMesaiBirim.kullanici, dbo.dbMesaiBirim.onay,  (SUM(DATEPART(HOUR, dbo.dbMesaiDetay.MesaiSuresi)*60) +SUM(DATEPART(MINUTE, dbo.dbMesaiDetay.MesaiSuresi)))/ 60 AS[Toplam Saat],(SUM(DATEPART(HOUR, dbo.dbMesaiDetay.MesaiSuresi) * 60) + SUM(DATEPART(MINUTE," +
                    "                                   dbo.dbMesaiDetay.MesaiSuresi))) % 60 AS Dakika FROM dbo.dbDepartman INNER JOIN  dbo.dbMesaiBirim ON dbo.dbDepartman.ID = dbo.dbMesaiBirim.depID LEFT OUTER JOIN" +
           "            dbo.dbMesaiDetay ON dbo.dbMesaiBirim.ID = dbo.dbMesaiDetay.MesaiID where dbo.dbDepartman.ID='" + UyeGris.RolDepID + "' AND dbo.dbMesaiBirim.onay='ONAYDA' " +
           "GROUP BY dbo.dbMesaiBirim.ID, dbo.dbDepartman.Departman, dbo.dbMesaiBirim.Tarih, dbo.dbMesaiBirim.kullanici, dbo.dbMesaiBirim.onay ORDER BY dbo.dbMesaiBirim.Tarih DESC";
            }
            else if (UyeGris.RolAdmin != 1 && UyeGris.RolOnaySira == 2)
            {
                cpm.CommandText = "SELECT dbo.dbMesaiBirim.ID, dbo.dbDepartman.Departman, dbo.dbMesaiBirim.Tarih, dbo.dbMesaiBirim.kullanici, dbo.dbMesaiBirim.onay,  (SUM(DATEPART(HOUR, dbo.dbMesaiDetay.MesaiSuresi)*60) +SUM(DATEPART(MINUTE, dbo.dbMesaiDetay.MesaiSuresi)))/ 60 AS[Toplam Saat],(SUM(DATEPART(HOUR, dbo.dbMesaiDetay.MesaiSuresi) * 60) + SUM(DATEPART(MINUTE," +
                    "                                   dbo.dbMesaiDetay.MesaiSuresi))) % 60 AS Dakika FROM dbo.dbDepartman INNER JOIN  dbo.dbMesaiBirim ON dbo.dbDepartman.ID = dbo.dbMesaiBirim.depID LEFT OUTER JOIN" +
      "            dbo.dbMesaiDetay ON dbo.dbMesaiBirim.ID = dbo.dbMesaiDetay.MesaiID where dbo.dbDepartman.ID='" + UyeGris.RolDepID + "'  " +
      "GROUP BY dbo.dbMesaiBirim.ID, dbo.dbDepartman.Departman, dbo.dbMesaiBirim.Tarih, dbo.dbMesaiBirim.kullanici, dbo.dbMesaiBirim.onay ORDER BY dbo.dbMesaiBirim.Tarih DESC";
            }

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


        private void verilistele1()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = UyeGris.Database;
            con.Open();

            SqlCommand cpm = new SqlCommand();
            cpm.Connection = con;
            SqlDataAdapter adp = new SqlDataAdapter();
         if(UyeGris.RolAdmin==1)
            {
                cpm.CommandText = "SELECT dbo.dbDepartman.Departman, dbo.dbMesaiBirim.Tarih, dbo.dbPersoneller.personelAdi, dbo.dbMesaiDetay.MesaiBaslangic, dbo.dbMesaiDetay.MesaiBitis, dbo.dbMesaiDetay.MesaiSuresi, dbo.dbPersoneller.IsTanimi,  dbo.dbMesaiDetay.Tanim,dbo.dbMesaiDetay.mesaiNedeni, dbo.dbMesaiBirim.onay FROM   " +
                    "  dbo.dbMesaiDetay INNER JOIN   dbo.dbMesaiBirim ON dbo.dbMesaiDetay.MesaiID = dbo.dbMesaiBirim.ID INNER JOIN                  dbo.dbPersoneller ON dbo.dbMesaiDetay.PerID = dbo.dbPersoneller.ID INNER JOIN                  dbo.dbDepartman ON dbo.dbMesaiBirim.depID = dbo.dbDepartman.ID ";
            }
         else
            {
                cpm.CommandText = "SELECT dbo.dbDepartman.Departman, dbo.dbMesaiBirim.Tarih, dbo.dbPersoneller.personelAdi, dbo.dbMesaiDetay.MesaiBaslangic, dbo.dbMesaiDetay.MesaiBitis, dbo.dbMesaiDetay.MesaiSuresi, dbo.dbPersoneller.IsTanimi,  dbo.dbMesaiDetay.Tanim,dbo.dbMesaiDetay.mesaiNedeni, dbo.dbMesaiBirim.onay FROM   " +
                    "  dbo.dbMesaiDetay INNER JOIN   dbo.dbMesaiBirim ON dbo.dbMesaiDetay.MesaiID = dbo.dbMesaiBirim.ID INNER JOIN                  dbo.dbPersoneller ON dbo.dbMesaiDetay.PerID = dbo.dbPersoneller.ID INNER JOIN                  dbo.dbDepartman ON dbo.dbMesaiBirim.depID = dbo.dbDepartman.ID " +
                    "WHERE  dbo.dbDepartman.ID='" + UyeGris.RolDepID + "'";
            }
                  

                
            cpm.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter sqAdp = new SqlDataAdapter();
            sqAdp.SelectCommand = cpm;
            con.Close();
            sqAdp.Fill(dt);

            guna2DataGridView2.DataSource = dt;
            for (int i = 0; i < guna2DataGridView2.Columns.Count; i++)
            {
                guna2DataGridView2.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                int withCol = guna2DataGridView2.Columns[i].Width;
                guna2DataGridView2.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                guna2DataGridView2.Columns[i].Width = withCol;
                guna2DataGridView2.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
            }
            guna2DataGridView2.Columns[0].SortMode = DataGridViewColumnSortMode.Automatic;
        }

        private void guna2DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            string _onay;
            string _red;
            string _tur;
            if (UyeGris.RolAdmin == 1)
            {
                _onay = "ONAYLANDI";
                _red = "REDDEDİLDİ";
                _tur = "MudurOnay";
            }
            else
            {
                _onay = "MÜDÜR ONAYDA";
                _red = "REDDEDİLDİ";
                _tur = "BirimOnay";
            }
         
            string X = guna2DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "Onay")
            {
                if (UyeGris.RolOnaySira == 2)
                {
                    MessageBox.Show("Onaylama Yetkiniz yok ?", "Mesaj", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                }
                else {
                    if (MessageBox.Show("Onaylamak üzeresiniz ?", "Mesaj", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                    {

                        if (!string.IsNullOrEmpty(X))
                        {
                            SqlConnection sqlCon = new SqlConnection();
                            sqlCon.ConnectionString = UyeGris.Database;
                            sqlCon.Open();

                            SqlCommand sqCom = new SqlCommand();
                            sqCom.Connection = sqlCon;

                            if (UyeGris.RolOnaySira == 1)
                            {
                                sqCom.CommandText = "UPDATE dbMesaiBirim SET onay=@onay,BirimOnay=@tur  WHERE ID=" + Convert.ToInt32(X);
                            }
                            else if (UyeGris.RolAdmin == 1)
                            {
                                sqCom.CommandText = "UPDATE dbMesaiBirim SET onay=@onay,MudurOnay=@tur  WHERE ID=" + Convert.ToInt32(X);
                            }
                            

                            sqCom.Parameters.Add("@onay", SqlDbType.NVarChar);
                            sqCom.Parameters["@onay"].Value = _onay;
                            sqCom.Parameters.Add("@tur", SqlDbType.Date);
                            sqCom.Parameters["@tur"].Value = DateTime.Now;

                            sqCom.ExecuteNonQuery();
                            sqlCon.Close();

                        }
                        else
                        {
                            MessageBox.Show("Kayıt yok");
                        }
                        verilistele();

                    }
                }
            }
            else if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "Red")
            {
                if (UyeGris.RolOnaySira == 2)
                {
                    MessageBox.Show("Reddetme Yetkiniz yok ?", "Mesaj", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                }
                else
                {
                    if (MessageBox.Show("Reddetmek üzeresiniz ?", "Mesaj", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    // customersBindingSource.RemoveCurrent();
                    {
                        if (!string.IsNullOrEmpty(X))
                        {
                            SqlConnection sqlCon = new SqlConnection();
                            sqlCon.ConnectionString = UyeGris.Database;
                            sqlCon.Open();

                            SqlCommand sqCom = new SqlCommand();
                            sqCom.Connection = sqlCon;

                            sqCom.CommandText = "UPDATE dbMesaiBirim SET onay=@onay  WHERE ID=" + X;

                            sqCom.Parameters.Add("@onay", SqlDbType.NVarChar);
                            sqCom.Parameters["@onay"].Value = _red;

                            sqCom.ExecuteNonQuery();
                            sqlCon.Close();

                        }

                        verilistele();

                        MessageBox.Show("Birim Mesaisi Reddedildi.");
                    }
                }
                }
        }

     

        private void guna2DataGridView1_CellEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            X = guna2DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            if (guna2DataGridView1.Rows.Count > 0)
            {
                SqlConnection sqlCon = new SqlConnection();
                sqlCon.ConnectionString = UyeGris.Database;
                sqlCon.Open();

                SqlCommand sqCom = new SqlCommand();
                sqCom.Connection = sqlCon;

                SqlDataAdapter da = new SqlDataAdapter();
                if (UyeGris.RolAdmin == 1)
                {
                    sqCom.CommandText = "SELECT dbo.dbDepartman.Departman, dbo.dbMesaiBirim.Tarih, dbo.dbPersoneller.personelAdi, dbo.dbMesaiDetay.MesaiBaslangic, dbo.dbMesaiDetay.MesaiBitis, dbo.dbMesaiDetay.MesaiSuresi, dbo.dbPersoneller.IsTanimi,  dbo.dbMesaiDetay.Tanim,dbo.dbMesaiDetay.mesaiNedeni, dbo.dbMesaiBirim.onay ,dbo.dbMesaiDetay.haftaTatili AS [Mesai Günü] FROM   " +
            "  dbo.dbMesaiDetay INNER JOIN   dbo.dbMesaiBirim ON dbo.dbMesaiDetay.MesaiID = dbo.dbMesaiBirim.ID INNER JOIN                  dbo.dbPersoneller ON dbo.dbMesaiDetay.PerID = dbo.dbPersoneller.ID INNER JOIN                  dbo.dbDepartman ON dbo.dbMesaiBirim.depID = dbo.dbDepartman.ID WHERE dbo.dbMesaiBirim.ID=" + X;
                }
                else
                {
                    sqCom.CommandText = "SELECT dbo.dbDepartman.Departman, dbo.dbMesaiBirim.Tarih, dbo.dbPersoneller.personelAdi, dbo.dbMesaiDetay.MesaiBaslangic, dbo.dbMesaiDetay.MesaiBitis, dbo.dbMesaiDetay.MesaiSuresi, dbo.dbPersoneller.IsTanimi,  dbo.dbMesaiDetay.Tanim,dbo.dbMesaiDetay.mesaiNedeni, dbo.dbMesaiBirim.onay,dbo.dbMesaiDetay.haftaTatili AS [Mesai Günü] FROM   " +
            "  dbo.dbMesaiDetay INNER JOIN   dbo.dbMesaiBirim ON dbo.dbMesaiDetay.MesaiID = dbo.dbMesaiBirim.ID INNER JOIN                  dbo.dbPersoneller ON dbo.dbMesaiDetay.PerID = dbo.dbPersoneller.ID INNER JOIN                  dbo.dbDepartman ON dbo.dbMesaiBirim.depID = dbo.dbDepartman.ID WHERE dbo.dbDepartman.ID='" + UyeGris.RolDepID + "' AND dbo.dbMesaiBirim.ID=" + X;
                }
            
                sqCom.ExecuteNonQuery();
                DataTable dtProd = new DataTable();
                SqlDataAdapter sqDa = new SqlDataAdapter();
                sqDa.SelectCommand = sqCom;
                sqlCon.Close();
                sqDa.Fill(dtProd);
                guna2DataGridView2.DataSource = dtProd;

            }
        }
    }
}
