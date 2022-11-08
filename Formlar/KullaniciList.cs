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
    public partial class KullaniciList : Form
    {
        public KullaniciList()
        {
            InitializeComponent();
        }

        private void KullaniciList_Load(object sender, EventArgs e)
        {
            verilistele();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "Ekle")
            {
                RolCrud per = new RolCrud();
                per.ShowDialog(this);
            }

        }
        private void verilistele()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = UyeGris.Database;
            con.Open();

            SqlCommand cpm = new SqlCommand();
            cpm.Connection = con;
            SqlDataAdapter adp = new SqlDataAdapter();

            cpm.CommandText = "SELECT dbo.Kullanicilar.ID, dbo.Kullanicilar.KullaniciAdi, dbo.Kullanicilar.Ad, dbo.Kullanicilar.Sifre, dbo.Kullanicilar.Unvan, dbo.dbRoller.onaySira " +
                "FROM dbo.dbRoller RIGHT OUTER JOIN    dbo.Kullanicilar ON dbo.dbRoller.KullaniciID = dbo.Kullanicilar.ID";

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
            Kullanicilar per = new Kullanicilar();
            per.ShowDialog(this);
        }
    }
}
