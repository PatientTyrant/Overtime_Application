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

namespace WindowsFormsApp1.Crud
{
    public partial class MesaiPersonelCrud : Form
    {
        public MesaiPersonelCrud()
        {
            InitializeComponent();
        }

  

        private void MesaiPersonelCrud_Load(object sender, EventArgs e)
        {
            verilistelePer();
            verilistele();
        }

        private void verilistelePer()
        {
            SqlConnection conn = new SqlConnection(UyeGris.Database);
            conn.Open();
            SqlCommand sc = new SqlCommand("Select *From dbPersoneller Where departID='" + UyeGris.RolDepID + "' ", conn);
            SqlDataReader reader;

            reader = sc.ExecuteReader();
            DataTable dtf = new DataTable();
            dtf.Columns.Add("ID", typeof(string));
            dtf.Columns.Add("personelAdi", typeof(string));
            dtf.Load(reader);

            cmbMaritalStatus.ValueMember = "ID";
            cmbMaritalStatus.DisplayMember = "personelAdi";
            cmbMaritalStatus.DataSource = dtf;
            cmbMaritalStatus.SelectedIndex = -1;
            conn.Close();
        }
        private void dtBaslamaSaati_ValueChanged(object sender, EventArgs e)
        {
            string sure = Convert.ToString(Convert.ToDateTime(dtBitisSaati.Text) - Convert.ToDateTime(dtBaslamaSaati.Text));
            lblMudehaleSuresi.Text = sure.Substring(0, 5);
        }

        private void dtBitisSaati_ValueChanged(object sender, EventArgs e)
        {
            string sure = Convert.ToString(Convert.ToDateTime(dtBitisSaati.Text) - Convert.ToDateTime(dtBaslamaSaati.Text));
            lblMudehaleSuresi.Text = sure.Substring(0, 5);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            TimeSpan girisCikisFarki = DateTime.Parse(dtBitisSaati.Value.ToString()).Subtract(DateTime.Parse(dtBaslamaSaati.Value.ToString()));
            string calismaSuresi = girisCikisFarki.ToString();

            if (btnRegister.Text == "KAYDET")
            {


                SqlConnection sqlCon = new SqlConnection();
                sqlCon.ConnectionString = UyeGris.Database;
                sqlCon.Open();
                SqlCommand sqCom = new SqlCommand();
                sqCom.Connection = sqlCon;
                sqCom.CommandText = "INSERT INTO dbMesaiDetay(MesaiID,PerID,MesaiBaslangic,MesaiBitis,MesaiSuresi,Tanim,kullanici,Tarih,haftaTatili,mesaiNedeni) VALUES(@MesaiID,@PerID,@MesaiBaslangic,@MesaiBitis,@MesaiSuresi,@Tanim,@kullanici,@Tarih,@haftaTatili,@mesaiNedeni)";


                sqCom.Parameters.Add("@MesaiID", SqlDbType.Int);
                sqCom.Parameters["@MesaiID"].Value = Convert.ToInt32(label5.Text);

                sqCom.Parameters.Add("@PerID", SqlDbType.Int);
                sqCom.Parameters["@PerID"].Value = Convert.ToInt32(cmbMaritalStatus.SelectedValue);

                sqCom.Parameters.Add("@MesaiSuresi", SqlDbType.Time);
                sqCom.Parameters["@MesaiSuresi"].Value = calismaSuresi;

                string time = dtBaslamaSaati.Value.ToString();
                var result = Convert.ToDateTime(time);

                string test = result.ToString("HH:mm ", System.Globalization.CultureInfo.InvariantCulture);

                sqCom.Parameters.Add("@MesaiBaslangic", SqlDbType.Time);
                sqCom.Parameters["@MesaiBaslangic"].Value = test.ToString();

                string time1 = dtBitisSaati.Value.ToString();
                var result1 = Convert.ToDateTime(time1);

                string test1 = result1.ToString("HH:mm", System.Globalization.CultureInfo.InvariantCulture);

                sqCom.Parameters.Add("@MesaiBitis", SqlDbType.Time);
                sqCom.Parameters["@MesaiBitis"].Value = test1.ToString();

                sqCom.Parameters.Add("@kullanici", SqlDbType.NVarChar);
                sqCom.Parameters["@kullanici"].Value = UyeGris.kullanici_bilgi;

                sqCom.Parameters.Add("@Tanim", SqlDbType.NVarChar);
                sqCom.Parameters["@Tanim"].Value = txtSalary.Text;

                sqCom.Parameters.Add("@Tarih", SqlDbType.Date);
                sqCom.Parameters["@Tarih"].Value = DateTime.Now;

                sqCom.Parameters.Add("@haftaTatili", SqlDbType.NVarChar);
                sqCom.Parameters["@haftaTatili"].Value = cbmTatil.Text;
                
                sqCom.Parameters.Add("@mesaiNedeni", SqlDbType.NVarChar);
                sqCom.Parameters["@mesaiNedeni"].Value = cbmMesaiNedeni.Text;


                sqCom.ExecuteNonQuery();
                sqlCon.Close();

                verilistele();
                txtSalary.Text = "";
                cmbMaritalStatus.SelectedIndex = -1;
                MessageBox.Show("Kayıt Eklendi");
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

            cpm.CommandText = "SELECT dbo.dbMesaiDetay.ID, dbo.dbDepartman.Departman, dbo.dbPersoneller.personelAdi, dbo.dbMesaiDetay.MesaiBaslangic, dbo.dbMesaiDetay.MesaiBitis, dbo.dbMesaiDetay.MesaiSuresi, dbo.dbMesaiDetay.Tanim, dbo.dbMesaiDetay.kullanici, dbo.dbMesaiDetay.Tarih FROM     dbo.dbPersoneller LEFT OUTER JOIN                  dbo.dbDepartman LEFT OUTER JOIN                  dbo.dbMesaiBirim LEFT OUTER JOIN                  dbo.dbMesaiDetay ON dbo.dbMesaiBirim.ID = dbo.dbMesaiDetay.MesaiID ON dbo.dbDepartman.ID = dbo.dbMesaiBirim.depID ON dbo.dbPersoneller.ID = dbo.dbMesaiDetay.PerID WHERE dbo.dbMesaiDetay.MesaiID=" + Convert.ToInt32(label5.Text);
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

        private void Guna2DataGridView(object sender, DataGridViewCellEventArgs e)
        {
            { string X = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

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

                        sqCom1.CommandText = "Delete From dbMesaiDetay where ID=" + X;
                        sqCom1.ExecuteNonQuery();
                        sqlCon.Close();

                        MessageBox.Show("Silme İşlemi Tamamlandı");

                        verilistele();

                    }
                }
            }
        }
    }
}
