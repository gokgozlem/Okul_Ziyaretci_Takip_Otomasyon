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
    public partial class kayitgüncelle : Form
    {
        public kayitgüncelle()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\366.accdb");
        OleDbCommand komut = new OleDbCommand();
        OleDbDataAdapter adtr = new OleDbDataAdapter();
        DataSet ds = new DataSet();
        private void button2_Click(object sender, EventArgs e)
        {
            if (txtTckimlik.Text != "")
            {
                komut.Connection = baglan;
                komut.CommandText = "UPDATE ZiyaretciListesi SET tckimlik=" + txtTckimlik.Text + ",Adi='" + txtAdi.Text + "',Soyadi='" + txtSoyadi.Text + "',ZiyaretTarihi='" + dateTimePicker1.Text + "',GirisSaati='" + txtGirisSaati.Text + "',CikisSaati='" + txtCikisSaati.Text + "',ZiyaretEttigiKisi='" + txtziyaretEttigiKisi.Text + "',ZiyaretSebebi='" + txtZiyaretSebebi.Text + "WHERE tckimlik=" + txtTckimlik.Text;
                baglan.Open();
                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Kayıt Başarılı Bir Şekilde Güncellendi.", "Güncelleme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
        }
    }
}
