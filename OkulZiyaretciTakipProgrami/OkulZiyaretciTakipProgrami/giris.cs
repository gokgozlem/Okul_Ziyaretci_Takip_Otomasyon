using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OkulZiyaretciTakipProgrami
{
    public partial class giris : Form
    {
        public giris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string kullanici, sifre;
            kullanici = txtkullaniciadi.Text;
            sifre = txtkullanicisifre.Text;
            if (kullanici == "imkb" && sifre == "123")
            {
                bilgiler frm2 = new bilgiler();
                frm2.Show();
            }

            else
                MessageBox.Show("Kullanıcı Adı ya da Şifre Hatalı..!!");
            txtkullaniciadi.Clear();
            txtkullanicisifre.Clear();
        }
    }
}
