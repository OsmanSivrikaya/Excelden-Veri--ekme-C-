using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void çIKIŞToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void sqlTransferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sqltransfer form2 = new sqltransfer();
            form2.ShowDialog();
        }

        private void personelDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonelEdit personel = new PersonelEdit();
            personel.ShowDialog();
        }
    }
}
