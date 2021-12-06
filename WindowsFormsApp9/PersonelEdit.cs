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
    public partial class PersonelEdit : Form
    {// public olarak kullanabileceğim değişgenler
        SqlConnection vo_Conn;
        SqlCommand Command;

        string vs_ConnStr = "Data Source=.;Initial Catalog=Northwind;Trusted_Connection=True";
        string vs_SQLText;

        DataTable tablo; // vt dden gelecek olan tabloyu tutmak için...
        SqlDataAdapter vo_DA; // adapter için
        DataSet vo_DS; // dataset için

        int vi_EmloyeeID;
        int vi_RowIndex;

        public PersonelEdit()
        {
            InitializeComponent();
        }

     

       

        private void GridFill()
        {
            vo_Conn = new SqlConnection(vs_ConnStr);

            vo_DA = new SqlDataAdapter("SELECT * FROM Employees", vo_Conn);

            vo_DS = new DataSet();

            vo_Conn.Open();

            vo_DA.Fill(vo_DS, "Employees");

            dataGridView1.DataSource = vo_DS.Tables["Employees"];

            vo_Conn.Close();

        }

       
        

        private void PersonelEdit_Load(object sender, EventArgs e)
        {
            button1.Text = "EKLE";
            button2.Text = "DÜZENLE";
            button3.Text = "SİL";
            button4.Text = "ÇIKIŞ";
            GridFill();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            tbID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            tbName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            tbLName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
         Command = new SqlCommand();
         vo_Conn.Open();

         Command.Connection = vo_Conn;
         Command.CommandText = "UPDATE Employees SET LastName='" +tbLName.Text + "',FirstName='" + tbName.Text +"' WHERE EmployeeID=" +
         Convert.ToInt32(tbID.Text);

         Command.ExecuteNonQuery();
         vo_Conn.Close();
         tbID.Clear();
         tbName.Clear();
         tbLName.Clear();

                GridFill();
        }
       

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Command = new SqlCommand();
            vo_Conn.Open();

            Command.Connection = vo_Conn;
            Command.CommandText = "delete from Employees  WHERE EmployeeID=" +
            Convert.ToInt32(tbID.Text);

            Command.ExecuteNonQuery();
            vo_Conn.Close();
            tbID.Clear();
            tbName.Clear();
            tbLName.Clear();

            GridFill();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Command = new SqlCommand();
            vo_Conn.Open();

            Command.Connection = vo_Conn;

            string vs_Komut;

            //vs_Komut = "INSERT INTO Employees (FirstName,LastName) VALUES (";
            //vs_Komut = vs_Komut + "'" + tbName.Text + "',";
            //vs_Komut = vs_Komut + "'" + tbLName.Text + "')";

            Command.CommandText = "insert into Employees(FirstName,LastName) values ('" + tbName.Text + "','" + tbLName.Text + "')";
            Command.ExecuteNonQuery();
            vo_Conn.Close();

            tbID.Clear();
            tbName.Clear();
            tbLName.Clear();

            GridFill();
        }
    }
}
