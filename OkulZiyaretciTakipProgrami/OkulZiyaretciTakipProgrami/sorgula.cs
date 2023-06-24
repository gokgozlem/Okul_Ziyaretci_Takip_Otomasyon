using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace OkulZiyaretciTakipProgrami
{
    public partial class sorgula : Form
    {
        public sorgula()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\\ZiyaretciListesi.accdb");
        OleDbCommand komut = new OleDbCommand();
        OleDbDataAdapter adtr = new OleDbDataAdapter();
        DataSet ds = new DataSet();
        private void btnAra_Click(object sender, EventArgs e)
        {
            komut.Connection = baglan;
            komut.CommandText = "SELECT* FROM ZiyaretciListesi WHERE tckimlik=" + textBox1.Text+",Adi='"+textBox2.Text+"'Soyadi='"+textBox3.Text+"',ZiyaretEttigiKisi='"+textBox4.Text;
            baglan.Open();
            OleDbDataReader dr = komut.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                    textBox1.Text = dr[0].ToString();
                textBox2.Text = dr[1].ToString();
                textBox3.Text = dr[2].ToString();
                textBox4.Text = dr[6].ToString();
            }

            else
            {
                MessageBox.Show("Kayıt Yok", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            baglan.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            baglan.Open();
            ds.Clear();
            OleDbDataAdapter adtr = new OleDbDataAdapter("SELECT* FROM ZiyaretciListesi ORDER BY tckimlik,Adi,Soyadi,ZiyaretEttigiKisi", baglan);
            adtr.Fill(ds, "ZiyaretciListesi");
            dataGridView1.DataMember = "ZiyaretciListesi";
            dataGridView1.DataSource = ds;
        }


    }
}
    

