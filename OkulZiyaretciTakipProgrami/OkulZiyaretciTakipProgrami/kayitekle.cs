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
    public partial class kayitekle : Form
    {
        public kayitekle()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\366.accdb");
        OleDbCommand komut = new OleDbCommand();
        OleDbDataAdapter adtr = new OleDbDataAdapter();
        DataSet ds = new DataSet();
        private void Form3_Load(object sender, EventArgs e)
        {
            groupBox1.Focus();
            txtTckimlik.Focus();
            
        }



        void KayitEkle()
        {
            baglan.Open();
            OleDbCommand komut = new OleDbCommand("INSERT INTO ZiyaretciListesi(tckimlik,Adi,Soyadi,ZiyaretTarihi,GirisSaati,CikisSaati,ZiyaretEttigiKisi,ZiyaretSebebi) VALUES (" + txtTckimlik.Text + ",'" + txtAdi.Text + "','" + txtSoyadi.Text + "','" + dtpZiyaretTarihi.Text + "','" + txtGirisSaati.Text + "','" + txtCikisSaati.Text + "','" + txtziyaretEttigiKisi.Text + "','" + txtZiyaretSebebi.Text + "')", baglan);
            komut.ExecuteNonQuery();
            MessageBox.Show("Kayıt Başarı İle Eklendi.", "Kayıt Ekleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            baglan.Close();
        }
        void Temizle()
        {
            txtTckimlik.Text = "";
            txtAdi.Text = "";
            txtSoyadi.Text = "";
            dtpZiyaretTarihi.Text = "";
            txtGirisSaati.Text = "";
            txtCikisSaati.Text = "";
            txtziyaretEttigiKisi.Text = "";
            txtZiyaretSebebi.Text = "";
        }
        void Listele()
        {
            baglan.Open();
            ds.Clear();
            OleDbDataAdapter adtr = new OleDbDataAdapter("SELECT*FROM ZiyaretciListesi ORDER BY ZiyaretTarihi", baglan);
            adtr.Fill(ds, "ZiyaretciListesi");
            dataGridView1.DataSource = ds;
            adtr.Dispose();
            baglan.Close();
            dataGridView1.AllowUserToAddRows = false;
            if (dataGridView1.RowCount != 0)
            {
                lblkayitSayisi.Text = "Kayıt Sayısı :" + dataGridView1.RowCount.ToString();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (txtTckimlik.Text != "")
            {
                KayitEkle();
            }
            else
            {
                MessageBox.Show("TC Kimlik Olmadan Kayıt Yapamazsınız..!", "Kayıt Ekleme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTckimlik.Focus();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Listele();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtTckimlik.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtAdi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtSoyadi.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            dtpZiyaretTarihi.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtGirisSaati.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtCikisSaati.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtziyaretEttigiKisi.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtZiyaretSebebi.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }
    }
}
