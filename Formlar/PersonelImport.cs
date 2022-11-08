using ExcelDataReader;
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
using WindowsFormsApp1.dbMesaiDataSetTableAdapters;
using Z.BulkOperations.Internal.InformationSchema;
using Z.Dapper.Plus;

namespace WindowsFormsApp1.Formlar
{
    public partial class PersonelImport : Form
    {
        public PersonelImport()
        {
            InitializeComponent();
        }

        private void cboSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = tableCollection[cboSheet.SelectedItem.ToString()];

            //dataGridView1.DataSource = dt;
            if (dt != null)
            {
                List<PersonelImportt> personeller = new List<PersonelImportt>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PersonelImportt personelImportt = new PersonelImportt();
                    personelImportt.departID = Convert.ToInt32(dt.Rows[i]["departID"].ToString());
                    personelImportt.SicilNo = Convert.ToInt32(dt.Rows[i]["SicilNo"].ToString());
                    personelImportt.personelAdi = dt.Rows[i]["personelAdi"].ToString();
                    personelImportt.pasif = Convert.ToBoolean(dt.Rows[i]["pasif"].ToString());
                    personelImportt.IsTanimi = dt.Rows[i]["IsTanimi"].ToString();
                    personelImportt.Unvan = dt.Rows[i]["Unvan"].ToString();
                    personelImportt.Gtarih = Convert.ToDateTime(dt.Rows[i]["Gtarih"].ToString());
                    personelImportt.Kullanici = dt.Rows[i]["Kullanici"].ToString();
                    personelImportt.Tarih = Convert.ToDateTime(dt.Rows[i]["Tarih"].ToString());


                    personeller.Add(personelImportt);

                }
                dbPersonellerBindingSource.DataSource = personeller;
            }
        }

        DataTableCollection tableCollection;

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel 97-2003 Workbook |* .xls|Excel Workbook|* .xlsx" })
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtFilename.Text = openFileDialog.FileName;
                    using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {

                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                                {
                                    UseHeaderRow = true
                                }

                            });

                            tableCollection = result.Tables;
                            cboSheet.Items.Clear();
                            foreach (DataTable table in tableCollection)
                                cboSheet.Items.Add(table); //add sheet to combobox 
                        }

                    }
                }


        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = tableCollection[cboSheet.SelectedItem.ToString()];

           


          
                if(dataGridView1!=null)

            {  
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    SqlConnection sqlCon = new SqlConnection();
                    sqlCon.ConnectionString = UyeGris.Database;
                    sqlCon.Open();
                    SqlCommand sqCom = new SqlCommand();
                    sqCom.Connection = sqlCon;
                    sqCom.CommandText = "INSERT INTO dbPersoneller(departID,SicilNo,personelAdi,Pasif,IsTanimi,Unvan,Gtarih,Kullanici,Tarih )" +
    " VALUES(@departID,@SicilNo, @personelAdi,@Pasif,@IsTanimi,@Unvan,@Gtarih,@Kullanici,@Tarih )";
                    sqCom.Parameters.Add("@departID", SqlDbType.Int);
                    sqCom.Parameters["@departID"].Value = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value.ToString());

                    sqCom.Parameters.Add("@SicilNo", SqlDbType.Int);
                    sqCom.Parameters["@SicilNo"].Value = Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value.ToString());

                    sqCom.Parameters.Add("@personelAdi", SqlDbType.NVarChar);
                    sqCom.Parameters["@personelAdi"].Value = dataGridView1.Rows[i].Cells[3].Value.ToString();

                    sqCom.Parameters.Add("@Pasif", SqlDbType.Bit);
                    sqCom.Parameters["@Pasif"].Value = Convert.ToBoolean(dataGridView1.Rows[i].Cells[4].Value.ToString());

                    sqCom.Parameters.Add("@IsTanimi", SqlDbType.Text);
                    sqCom.Parameters["@IsTanimi"].Value = dataGridView1.Rows[i].Cells[5].Value.ToString();

                    sqCom.Parameters.Add("@Unvan", SqlDbType.NVarChar);
                    sqCom.Parameters["@Unvan"].Value = dataGridView1.Rows[i].Cells[6].Value.ToString();

                    sqCom.Parameters.Add("@Gtarih", SqlDbType.Date);
                    sqCom.Parameters["@Gtarih"].Value = Convert.ToDateTime(dataGridView1.Rows[i].Cells[7].Value.ToString());

                    sqCom.Parameters.Add("@Kullanici", SqlDbType.NVarChar);
                    sqCom.Parameters["@Kullanici"].Value = dataGridView1.Rows[i].Cells[8].Value.ToString();

                    sqCom.Parameters.Add("@Tarih", SqlDbType.Date);
                    sqCom.Parameters["@Tarih"].Value = Convert.ToDateTime(dataGridView1.Rows[i].Cells[9].Value.ToString());

                    sqCom.ExecuteNonQuery();

                    sqlCon.Close();
                }
               
                //   dbPersonellerBindingSource.DataSource = personeller;
            }
            //txtSalary.Text = "";
            // cmbMaritalStatus.SelectedIndex = -1;
            MessageBox.Show("Kayıt Eklendi");





            //    try
            //    {
            //        string ConnectionString = "Server=192.168.18.13;Database=dbMesai;User Id=sa;Password=12345678;";
            //        DapperPlusManager.Entity<PersonelImportt>().Table("Personeller");
            //        List<PersonelImportt> personeller = dbPersonellerBindingSource.DataSource as List<PersonelImportt>;
            //        if (personeller != null)
            //        {
            //            using(IDbConnection db = new SqlConnection(ConnectionString))
            //            {
            //                db.BulkInsert(personeller); 
            //            }
            //        }
            //        MessageBox.Show("Finish !!!");
            //    }
            //    catch (Exception ex)
            //    {

            //        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    } 
            //}

            //public void PersonelImport_Load(object sender, EventArgs e)
            //{
            //    this.dbPersonellerTableAdapter.Fill(this.dbMesaiDataSet.dbPersoneller);

            //}
        }
    }
}
