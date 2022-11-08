using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Crud;

namespace WindowsFormsApp1.Formlar
{
    public partial class MesaiCrud : Form
    {
        public MesaiCrud()
        {
            InitializeComponent();
        }

        private void MesaiCrud_Load(object sender, EventArgs e)
        {
            verilistele();
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
                sqCom.Parameters["@depID"].Value = UyeGris.RolDepID;

                sqCom.Parameters.Add("@kullanici", SqlDbType.NVarChar);
                sqCom.Parameters["@kullanici"].Value = UyeGris.kullanici_bilgi;

                if (chkCalis.Checked)
                {

                    sqCom.Parameters.Add("@onay", SqlDbType.NVarChar);
                    sqCom.Parameters["@onay"].Value = "ONAYDA";

                }
                else
                {
                    sqCom.Parameters.Add("@onay", SqlDbType.NVarChar);
                    sqCom.Parameters["@onay"].Value = "BEKLEMEDE";
                }


                sqCom.Parameters.Add("@Tarih", SqlDbType.Date);
                sqCom.Parameters["@Tarih"].Value = dataPicture.Value;


                sqCom.ExecuteNonQuery();
                sqlCon.Close();

                verilistele();
                chkCalis.Checked = false;
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


                        if (chkCalis.Checked)
                        {
                            if (UyeGris.RolOnaySira == 1)
                            {
                                sqCom.Parameters.Add("@onay", SqlDbType.NVarChar);
                                sqCom.Parameters["@onay"].Value = "MÜDÜR ONAYDA";
                            }
                            else
                            {
                                sqCom.Parameters.Add("@onay", SqlDbType.NVarChar);
                                sqCom.Parameters["@onay"].Value = "ONAYDA";
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
                    chkCalis.Checked = false;
                    btnKaydet.Text = "Mesai Başlat";
                }
                else
                {
                    MessageBox.Show("İletilmiş Kayıtlarda Güncelleme yapamassınız.");
                }
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

            cpm.CommandText = "SELECT *FROM MesaiDurum Where onay='BEKLEMEDE' AND kullanici='"+UyeGris.kullanici_bilgi+"'";
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

        private void btnYeni_Click(object sender, EventArgs e)
        {
            label3.Text = "";
            chkCalis.Checked = false;
            btnKaydet.Text = "Mesai Başlat";





            /** MailMessage msg = new MailMessage();
            msg.To.Add(new MailAddress("mdpowerbi@maritasdenim.com", "Sob49905"));
            msg.From = new MailAddress("ckaba@maritasdenim.com", "You");
            msg.Subject = "This is a Test Mail";
            msg.Body = "This is a test message using Exchange OnLine";
            msg.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("mdpowerbi@maritasdenim.com", "Sob49905");
            client.Port = 587; // You can use Port 25 if 587 is blocked (mine is!)
            client.Host = "smtp.office365.com";
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Send(msg);
             MessageBox.Show("Message Sent Succesfully"); **/
         

        } 

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string X = guna2DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            string y = guna2DataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "PersonelEkle")
            {
                MesaiPersonelCrud fr = new MesaiPersonelCrud();
                for (int i = 0; i < guna2DataGridView1.SelectedRows.Count; i++)
                {
                    fr.label5.Text = guna2DataGridView1.SelectedRows[i].Cells["ID"].Value.ToString();
                }
                fr.ShowDialog(this);

            }
            if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "Sil"  )
            {
                if (y == "BEKLEMEDE")
                {
                    if (MessageBox.Show("Kayıt silinecektir ! ?", "Mesaj", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    // customersBindingSource.RemoveCurrent();
                    {
                        SqlConnection sqlCon = new SqlConnection();
                        sqlCon.ConnectionString = UyeGris.Database;
                        sqlCon.Open();

                        SqlCommand sqCom1 = new SqlCommand();
                        sqCom1.Connection = sqlCon;

                        sqCom1.CommandText = "Delete From dbMesaiBirim where ID=" + X;
                        sqCom1.ExecuteNonQuery();
                        sqlCon.Close();

                        MessageBox.Show("tamam");
                    }
                }
                else
                {
                    MessageBox.Show("Kaydı Silme Hakkınız Yok");
                }
            }

        }

        private void guna2DataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            label3.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            if (guna2DataGridView1.Rows.Count > 0)
            {
                try { 
                
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
                        chkCalis.Checked = false;
                    }
                    else { chkCalis.Checked = true; }
                    btnKaydet.Enabled = true;
                    btnKaydet.Text = "GÜNCELLE";
             }
                catch { }

            }
        }


        public static void ExchangeUzerinden(string mailBaslik, string mailIcerik, string aliciPosta)
        {
            EmailAddress alacakAdres = new EmailAddress(aliciPosta);
            string strsubject = mailBaslik;
            string strbody = mailIcerik;
            ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2013_SP1);
            service.Credentials = new WebCredentials("mdpowerbi@maritasdenim.com", "Sob49905");
            //bunu kullanmaktaki amaç service.URL bilgisini otomatik almak fakat beklettiği için aşağıdaki şekilde manuel olarak tanımladık.
            //service.AutodiscoverUrl("tamer@bosforbilisim.com.tr", RedirectionUrlValidationCallback);
            service.Url = new Uri("https://outlook.office365.com/EWS/Exchange.asmx");
            EmailMessage message = new EmailMessage(service);
            message.Subject = strsubject;
            message.Body = strbody;
            message.ToRecipients.Add(alacakAdres);
            message.Save();
            message.SendAndSaveCopy();
        }
        private static bool RedirectionUrlValidationCallback(string redirectionUrl)
        {
            bool result = false;
            Uri redirectionUri = new Uri(redirectionUrl);
            if (redirectionUri.Scheme == "https")
            {
                result = true;
            }
            return result;
        }
    }
}
