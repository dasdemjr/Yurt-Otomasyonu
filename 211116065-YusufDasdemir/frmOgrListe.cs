using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _211116065_YusufDasdemir
{
    public partial class frmOgrListe : Form
    {
        SqlBaglantim bgl = new SqlBaglantim();
        public frmOgrListe()
        {
            InitializeComponent();
        }

        public void Listele()
        {
            this.ogrenciTableAdapter.Fill(this.yurtKayitDataSet3.Ogrenci);
        }
        private void frmOgrListe_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'yurtKayitDataSet3.Ogrenci' table. You can move, or remove it, as needed.
            this.ogrenciTableAdapter.Fill(this.yurtKayitDataSet3.Ogrenci);

        }
        int secilen;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            frmOgrDuzenle ogrDuzenle = new frmOgrDuzenle();
            ogrDuzenle.id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            ogrDuzenle.ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            ogrDuzenle.soyad = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            ogrDuzenle.Tc = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            ogrDuzenle.telefon = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            ogrDuzenle.dogum = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            ogrDuzenle.bolum = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            ogrDuzenle.mail = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            ogrDuzenle.odano = dataGridView1.Rows[secilen].Cells[8].Value.ToString();
            ogrDuzenle.veliad = dataGridView1.Rows[secilen].Cells[9].Value.ToString();
            ogrDuzenle.velitel = dataGridView1.Rows[secilen].Cells[10].Value.ToString();
            ogrDuzenle.adres = dataGridView1.Rows[secilen].Cells[11].Value.ToString();
            ogrDuzenle.Show();

        }
    }
}
