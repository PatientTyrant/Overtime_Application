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
    public partial class Departman : Form
    {
        public Departman()
        {
            InitializeComponent();
        }

        private void Departman_Load(object sender, EventArgs e)
        {
            verilistele();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            
        }
        private void verilistele()
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = UyeGris.Database;
            con.Open();

            SqlCommand cpm = new SqlCommand();
            cpm.Connection = con;
            SqlDataAdapter adp = new SqlDataAdapter();

            cpm.CommandText = "SELECT  * from dbDepartman";
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
    }
}
