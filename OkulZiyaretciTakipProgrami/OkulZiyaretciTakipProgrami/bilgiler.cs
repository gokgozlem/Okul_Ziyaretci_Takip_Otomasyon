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
    public partial class bilgiler : Form
    {
        public bilgiler()
        {
            InitializeComponent();
        }

        private void bilgiler_Load(object sender, EventArgs e)
        {

        }

        private void kAYITEKLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kayitekle kayitekle = new kayitekle();
            kayitekle.Show();
        }

        private void kAYITSİLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kayitsil kayitsil = new kayitsil();
            kayitsil.Show();
        }

        private void kAYITGÜNCELLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kayitgüncelle kayitgüncelle = new kayitgüncelle();
            kayitgüncelle.Show();
        }

        private void çIKIŞToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void sORGULAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sorgula sorgula = new sorgula();
            sorgula.Show();
        }
    }
}
