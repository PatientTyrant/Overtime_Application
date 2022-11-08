using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formlar
{
    public partial class Raporlar : Form
    {
        public Raporlar()
        {
            InitializeComponent();
        }

        private void Raporlar_Load(object sender, EventArgs e)
        {
            verilistele();
            verilisteleBekleyen();
            verilisteleSade();
            verilisteleOnayBekle();
            verilistelemuduronay(); 
        }
        private void verilistele()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = UyeGris.Database;
            con.Open();

            SqlCommand cpm = new SqlCommand();
            cpm.Connection = con;
            SqlDataAdapter adp = new SqlDataAdapter();
            if (UyeGris.RolAdmin == 1 || UyeGris.RolPersonel == 1)
            {
                cpm.CommandText = "SELECT dbo.dbMesaiBirim.ID, dbo.dbDepartman.Departman, dbo.dbMesaiBirim.Tarih, dbo.dbMesaiBirim.kullanici, dbo.dbMesaiBirim.onay, SUM(DATEPART(HOUR, dbo.dbMesaiDetay.MesaiSuresi)) AS [Toplam Saat], SUM(DATEPART(MINUTE," +
                "                 dbo.dbMesaiDetay.MesaiSuresi)) AS Dakika, dbo.dbPersoneller.SicilNo, dbo.dbPersoneller.personelAdi,dbo.dbMesaiDetay.haftaTatili,dbo.dbMesaiDetay.mesaiNedeni FROM     dbo.dbPersoneller INNER JOIN " +
                "                  dbo.dbMesaiDetay ON dbo.dbPersoneller.ID = dbo.dbMesaiDetay.PerID RIGHT OUTER JOIN  dbo.dbDepartman INNER JOIN dbo.dbMesaiBirim ON dbo.dbDepartman.ID = dbo.dbMesaiBirim.depID ON dbo.dbMesaiDetay.MesaiID = dbo.dbMesaiBirim.ID" +
                "  WHERE(dbo.dbMesaiBirim.onay = 'ONAYLANDI') GROUP BY dbo.dbMesaiBirim.ID, dbo.dbDepartman.Departman, dbo.dbMesaiBirim.Tarih, dbo.dbMesaiBirim.kullanici, dbo.dbMesaiBirim.onay, dbo.dbPersoneller.SicilNo, dbo.dbPersoneller.personelAdi,dbo.dbMesaiDetay.haftaTatili,dbo.dbMesaiDetay.mesaiNedeni ";
            }
            else
            {
                cpm.CommandText = "SELECT dbo.dbMesaiBirim.ID, dbo.dbDepartman.Departman, dbo.dbMesaiBirim.Tarih, dbo.dbMesaiBirim.kullanici, dbo.dbMesaiBirim.onay, SUM(DATEPART(HOUR, dbo.dbMesaiDetay.MesaiSuresi)) AS [Toplam Saat], SUM(DATEPART(MINUTE," +
          "                 dbo.dbMesaiDetay.MesaiSuresi)) AS Dakika, dbo.dbPersoneller.SicilNo, dbo.dbPersoneller.personelAdi,dbo.dbMesaiDetay.haftaTatili,dbo.dbMesaiDetay.mesaiNedeni FROM     dbo.dbPersoneller INNER JOIN " +
          "                  dbo.dbMesaiDetay ON dbo.dbPersoneller.ID = dbo.dbMesaiDetay.PerID RIGHT OUTER JOIN  dbo.dbDepartman INNER JOIN dbo.dbMesaiBirim ON dbo.dbDepartman.ID = dbo.dbMesaiBirim.depID ON dbo.dbMesaiDetay.MesaiID = dbo.dbMesaiBirim.ID" +
          "  WHERE(dbo.dbMesaiBirim.onay = 'ONAYLANDI') and dbo.dbDepartman.ID='"+UyeGris.RolDepID+ "' GROUP BY dbo.dbMesaiBirim.ID, dbo.dbDepartman.Departman, dbo.dbMesaiBirim.Tarih, dbo.dbMesaiBirim.kullanici, dbo.dbMesaiBirim.onay, dbo.dbPersoneller.SicilNo, dbo.dbPersoneller.personelAdi,dbo.dbMesaiDetay.haftaTatili,dbo.dbMesaiDetay.mesaiNedeni";
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

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Personel Bazlı.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;
                ToCsV(guna2DataGridView1, sfd.FileName);
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Excel Dosyası Oluşturuldu");
            }
        }
        private void ToCsV(DataGridView dGV, string filename)
        {
            string stOutput = "";
            string sHeaders = "";
            for (int j = 0; j < dGV.Columns.Count; j++)
                sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";
            stOutput += sHeaders + "\r\n";
            for (int i = 0; i < dGV.RowCount; i++)
            {
                string stLine = "";
                for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
                    stLine = stLine.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value) + "\t";
                stOutput += stLine + "\r\n";
            }
            Encoding utf16 = Encoding.GetEncoding(1254);
            byte[] output = utf16.GetBytes(stOutput);
            FileStream fs = new FileStream(filename, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(output, 0, output.Length);
            bw.Flush();
            bw.Close();
            fs.Close();

        }

        private void verilisteleBekleyen()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = UyeGris.Database;
            con.Open();

            SqlCommand cpm = new SqlCommand();
            cpm.Connection = con;
            SqlDataAdapter adp = new SqlDataAdapter();
            if (UyeGris.RolAdmin == 1 || UyeGris.RolPersonel == 1)
            {
                cpm.CommandText = "SELECT dbo.dbMesaiBirim.ID, dbo.dbDepartman.Departman, dbo.dbMesaiBirim.Tarih, dbo.dbMesaiBirim.kullanici, dbo.dbMesaiBirim.onay, SUM(DATEPART(HOUR, dbo.dbMesaiDetay.MesaiSuresi)) AS [Toplam Saat], SUM(DATEPART(MINUTE," +
                "                 dbo.dbMesaiDetay.MesaiSuresi)) AS Dakika, dbo.dbPersoneller.SicilNo, dbo.dbPersoneller.personelAdi,dbo.dbMesaiDetay.haftaTatili AS [Mesai Günü],dbo.dbMesaiDetay.mesaiNedeni FROM     dbo.dbPersoneller INNER JOIN " +
                "                  dbo.dbMesaiDetay ON dbo.dbPersoneller.ID = dbo.dbMesaiDetay.PerID RIGHT OUTER JOIN  dbo.dbDepartman INNER JOIN dbo.dbMesaiBirim ON dbo.dbDepartman.ID = dbo.dbMesaiBirim.depID ON dbo.dbMesaiDetay.MesaiID = dbo.dbMesaiBirim.ID" +
                "  WHERE(dbo.dbMesaiBirim.onay != 'ONAYLANDI') GROUP BY dbo.dbMesaiBirim.ID, dbo.dbDepartman.Departman, dbo.dbMesaiBirim.Tarih, dbo.dbMesaiBirim.kullanici, dbo.dbMesaiBirim.onay, dbo.dbPersoneller.SicilNo, dbo.dbPersoneller.personelAdi,dbo.dbMesaiDetay.haftaTatili,dbo.dbMesaiDetay.mesaiNedeni ";
            }
            else
            {
                cpm.CommandText = "SELECT dbo.dbMesaiBirim.ID, dbo.dbDepartman.Departman, dbo.dbMesaiBirim.Tarih, dbo.dbMesaiBirim.kullanici, dbo.dbMesaiBirim.onay, SUM(DATEPART(HOUR, dbo.dbMesaiDetay.MesaiSuresi)) AS [Toplam Saat], SUM(DATEPART(MINUTE," +
          "                 dbo.dbMesaiDetay.MesaiSuresi)) AS Dakika, dbo.dbPersoneller.SicilNo, dbo.dbPersoneller.personelAdi,dbo.dbMesaiDetay.haftaTatili AS [Mesai Günü],dbo.dbMesaiDetay.mesaiNedeni FROM     dbo.dbPersoneller INNER JOIN " +
          "                  dbo.dbMesaiDetay ON dbo.dbPersoneller.ID = dbo.dbMesaiDetay.PerID RIGHT OUTER JOIN  dbo.dbDepartman INNER JOIN dbo.dbMesaiBirim ON dbo.dbDepartman.ID = dbo.dbMesaiBirim.depID ON dbo.dbMesaiDetay.MesaiID = dbo.dbMesaiBirim.ID" +
          "  WHERE(dbo.dbMesaiBirim.onay != 'ONAYLANDI') and dbo.dbDepartman.ID='" + UyeGris.RolDepID + "' GROUP BY dbo.dbMesaiBirim.ID, dbo.dbDepartman.Departman, dbo.dbMesaiBirim.Tarih, dbo.dbMesaiBirim.kullanici, dbo.dbMesaiBirim.onay, dbo.dbPersoneller.SicilNo, dbo.dbPersoneller.personelAdi,dbo.dbMesaiDetay.haftaTatili,dbo.dbMesaiDetay.mesaiNedeni";
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
                guna2DataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
            }
            guna2DataGridView2.Columns[0].SortMode = DataGridViewColumnSortMode.Automatic;
        }
        private void verilisteleSade()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = UyeGris.Database;
            con.Open();

            SqlCommand cpm = new SqlCommand();
            cpm.Connection = con;
            SqlDataAdapter adp = new SqlDataAdapter();
            if (UyeGris.RolAdmin == 1 || UyeGris.RolPersonel == 1)
            {
                cpm.CommandText = "SELECT Departman, personelAdi, Yıl, Ay, SUM([Toplam Saat]) + SUM(Dakika) / 60 AS Saat, SUM(Dakika) % 60 AS Dakika, SicilNo " +
                    "FROM dbo.MesaiPersonelDetay WHERE(onay = 'ONAYLANDI') GROUP BY Departman, personelAdi, Yıl, Ay,  SicilNo ORDER BY Saat DESC";
            }
            else
            {
                cpm.CommandText = "SELECT Departman, personelAdi, Yıl, Ay, SUM([Toplam Saat]) + SUM(Dakika) / 60 AS Saat, SUM(Dakika) % 60 AS Dakika, SicilNo " +
                    "FROM dbo.MesaiPersonelDetay WHERE(onay = 'ONAYLANDI') and ID='" + UyeGris.RolDepID + "' GROUP BY Departman, personelAdi, Yıl, Ay,  SicilNo ORDER BY Saat DESC";
            }
            cpm.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter sqAdp = new SqlDataAdapter();
            sqAdp.SelectCommand = cpm;
            con.Close();
            sqAdp.Fill(dt);

            guna2DataGridView3.DataSource = dt;
            for (int i = 0; i < guna2DataGridView3.Columns.Count; i++)
            {
                guna2DataGridView3.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                int withCol = guna2DataGridView3.Columns[i].Width;
                guna2DataGridView3.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                guna2DataGridView3.Columns[i].Width = withCol;
                guna2DataGridView3.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
            }
            guna2DataGridView3.Columns[0].SortMode = DataGridViewColumnSortMode.Automatic;
        }
        private void verilistelemuduronay()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = UyeGris.Database;
            con.Open();

            SqlCommand cpm = new SqlCommand();
            cpm.Connection = con;
            SqlDataAdapter adp = new SqlDataAdapter();
            if (UyeGris.RolAdmin == 1 || UyeGris.RolPersonel == 1)
            {
                cpm.CommandText = "SELECT Departman, personelAdi, Yıl, Ay, SUM([Toplam Saat]) + SUM(Dakika) / 60 AS Saat, SUM(Dakika) % 60 AS Dakika, SicilNo " +
                    "FROM dbo.MesaiPersonelDetay WHERE(onay = 'MÜDÜR ONAYDA') GROUP BY Departman, personelAdi, Yıl, Ay,  SicilNo ORDER BY Saat DESC";
            }
            else
            {
                cpm.CommandText = "SELECT Departman, personelAdi, Yıl, Ay, SUM([Toplam Saat]) + SUM(Dakika) / 60 AS Saat, SUM(Dakika) % 60 AS Dakika, SicilNo " +
                    "FROM dbo.MesaiPersonelDetay WHERE(onay = 'MÜDÜR ONAYDA') and ID='" + UyeGris.RolDepID + "' GROUP BY Departman, personelAdi, Yıl, Ay,  SicilNo ORDER BY Saat DESC";
            }
            cpm.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter sqAdp = new SqlDataAdapter();
            sqAdp.SelectCommand = cpm;
            con.Close();
            sqAdp.Fill(dt);

            guna2DataGridView1_2.DataSource = dt;
            for (int i = 0; i < guna2DataGridView1_2.Columns.Count; i++)
            {
                guna2DataGridView1_2.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                int withCol = guna2DataGridView1_2.Columns[i].Width;
                guna2DataGridView1_2.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                guna2DataGridView1_2.Columns[i].Width = withCol;
                guna2DataGridView1_2.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
            }
            guna2DataGridView1_2.Columns[0].SortMode = DataGridViewColumnSortMode.Automatic;
        }
        private void verilisteleOnayBekle()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = UyeGris.Database;
            con.Open();

            SqlCommand cpm = new SqlCommand();
            cpm.Connection = con;
            SqlDataAdapter adp = new SqlDataAdapter();
            if (UyeGris.RolAdmin == 1 || UyeGris.RolPersonel == 1)
            {
                cpm.CommandText = "SELECT Departman, personelAdi, Yıl, Ay, SUM([Toplam Saat]) + SUM(Dakika) / 60 AS Saat, SUM(Dakika) % 60 AS Dakika, SicilNo " +
                    "FROM dbo.MesaiPersonelDetay WHERE(onay = 'ONAYDA') GROUP BY Departman, personelAdi, Yıl, Ay,  SicilNo ORDER BY Saat DESC";
            }
            else
            {
                cpm.CommandText = "SELECT Departman, personelAdi, Yıl, Ay, SUM([Toplam Saat]) + SUM(Dakika) / 60 AS Saat, SUM(Dakika) % 60 AS Dakika, SicilNo " +
                    "FROM dbo.MesaiPersonelDetay WHERE(onay = 'ONAYDA' ) and ID='" + UyeGris.RolDepID + "' GROUP BY Departman, personelAdi, Yıl, Ay,  SicilNo ORDER BY Saat DESC";
            }
            cpm.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter sqAdp = new SqlDataAdapter();
            sqAdp.SelectCommand = cpm;
            con.Close();
            sqAdp.Fill(dt);

            dataGridView1_1.DataSource = dt;
            for (int i = 0; i < dataGridView1_1.Columns.Count; i++)
            {
                dataGridView1_1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                int withCol = dataGridView1_1.Columns[i].Width;
                dataGridView1_1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridView1_1.Columns[i].Width = withCol;
                dataGridView1_1.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
            }
            dataGridView1_1.Columns[0].SortMode = DataGridViewColumnSortMode.Automatic;
        }

        private void guna2ImageButton3_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Personel Aylık Mesai.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;
                ToCsV(dataGridView1_1, sfd.FileName);
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Excel Dosyası Oluşturuldu");
            }
        }

        private void guna2ImageButton4_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Personel Aylık Mesai.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;
                ToCsV(dataGridView1_1, sfd.FileName);
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Excel Dosyası Oluşturuldu");
            }
        }

        private void guna2ImageButton5_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Personel Aylık Mesai.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;
                ToCsV(guna2DataGridView1_2, sfd.FileName);
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Excel Dosyası Oluşturuldu");
            }
        }

        private void guna2DataGridView3_Sorted(object sender, EventArgs e)
        {
            rowsColor();
        }

        private void rowsColor()
        {
            for (int i = 0; i < guna2DataGridView3.Rows.Count; i++)
            {
                int val3 = Convert.ToInt32(guna2DataGridView3.Rows[i].Cells[4].Value);
                if (val3 >=23)
                {
                    guna2DataGridView3.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
                /**if (val3 == "URETIMDE")
                {
                    guna2DataGridView3.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                }
                if (val3 == "URETIM TAMAMLANDI")
                {
                    guna2DataGridView3.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                }
                if (val3 == "KISMEN TAMAMLANDI")
                {
                    guna2DataGridView3.Rows[i].DefaultCellStyle.BackColor = Color.DarkBlue;
                    guna2DataGridView3.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                }
                if (val3 == "STOK SEVK")
                {
                    guna2DataGridView3.Rows[i].DefaultCellStyle.BackColor = Color.AliceBlue;
                }
                if (val3 == "SEVK EDİLDİ")
                {
                    guna2DataGridView3.Rows[i].DefaultCellStyle.BackColor = Color.LightSteelBlue;
                }
                if (val3 == "KISMEN SEVK")
                {
                    guna2DataGridView3.Rows[i].DefaultCellStyle.BackColor = Color.Azure;
                }**/


            }
        }

        private void Raporlar_Shown(object sender, EventArgs e)
        {
            rowsColor();
        }
    }
}
