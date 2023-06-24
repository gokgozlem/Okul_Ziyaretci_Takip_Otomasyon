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
    public partial class kayitsil : Form
    {
        public kayitsil()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\366.accdb");
        OleDbCommand komut = new OleDbCommand();
        OleDbDataAdapter adtr = new OleDbDataAdapter();
        DataSet ds = new DataSet();
        private void button2_Click(object sender, EventArgs e)
        {
             DialogResult numara;
            if (txtTckimlik.Text == "")
            {
                MessageBox.Show("tc kimlik no girin", "hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            numara = MessageBox.Show("silmek istediğinizden emin misiniz?", "silme onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (numara == DialogResult.Yes)
            {
                komut.Connection = baglan;
                komut.CommandText = "DELETE* FROM 366 WHERE ZiyaretciListesi=" + txtTckimlik.Text + ",adi='" + txtAdi.Text + "',soyadi='" + txtSoyadi.Text;
                baglan.Open();
                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("kayıt silindi", "kayıt silme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTckimlik.Text = "";
                txtAdi.Text = "";
                txtSoyadi.Text = "";
            }
            else
            {
                MessageBox.Show("kayıt silme işlemi iptal edildi", "kayıt silme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTckimlik.Text = "";
                txtAdi.Text = "";
                txtSoyadi.Text = "";
            }
        }
    }
}
