using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Globalization;
namespace WindowsFormsApp9
{
    public partial class sqltransfer : Form
    {
        public sqltransfer()
        {
            InitializeComponent();
        }
        SqlConnection connect;
        SqlCommand command;

        string baglanti = "Data Source=.;Initial Catalog=Northwind;Trusted_Connection=True";
        

        DataTable tablo; // vt dden gelecek olan tabloyu tutmak için...
        SqlDataAdapter da; // adapter için
        DataSet ds; // dataset için
        
        private void sqltransfer_Load(object sender, EventArgs e)
        {
            
            button4.Text = ("DOSYA AKTAR");
            button5.Text = ("EXCEL AKTAR");
            button1.Text = ("ÇIKIŞ");
            GridFill();
            

        }
        private void GridFill()
        {
            connect = new SqlConnection(baglanti);

            da = new SqlDataAdapter("SELECT * FROM Employees", connect);

            ds = new DataSet();

            connect.Open();

            da.Fill(ds, "Employees");

            dataGridView1.DataSource = ds.Tables["Employees"];
            
            connect.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            GridFill();
        }
        

        

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Excel Dosyası |*.xlsx|Excel Dosyası|*.xls";
            file.Title = "Excel Dosyası Seçiniz";
            // dosya filtresi için bu kodu kullanıyoruz. Şuan sadece xlsx dosyalarını görecektir.
            if (file.ShowDialog()==DialogResult.OK)
            {
                OleDbConnection baglan;
                baglan = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=" + file.FileName + ";Extended Properties=\"Excel 12.0 xml;HDR=Yes;\"");
                baglan.Open();
                OleDbDataAdapter adap = new OleDbDataAdapter("SELECT * FROM [Sayfa1$]", baglan);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                dataGridView1.DataSource = dt;
                baglan.Close();
            }
            ;
            textBox4.Text = file.FileName.ToString();
        }
        NorthwindEntities db = new NorthwindEntities();
        private void button5_Click(object sender, EventArgs e)
        {
            //Cursor.Current = Cursors.WaitCursor;
            int satir = dataGridView1.Rows.Count;
            if (satir>0)
            {
                for (int i = 0; i < satir; i++)
                {
                    
                    Employees employees = new Employees();
                    
                    employees.LastName = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    employees.FirstName = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    db.Employees.Add(employees);

                    db.SaveChanges();
                    
                }


            }
            GridFill();
            //Cursor.Current = Cursors.Default;

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
