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
    public partial class frmGiderListesi : Form
    {
        public frmGiderListesi()
        {
            InitializeComponent();
        }

        private void frmGiderListesi_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'yurtKayitDataSet4.Giderler' table. You can move, or remove it, as needed.
            this.giderlerTableAdapter.Fill(this.yurtKayitDataSet4.Giderler);

        }

        private int secilen;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmGiderGuncelle giderGuncelle = new frmGiderGuncelle();
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            giderGuncelle.id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            giderGuncelle.elektrik = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            giderGuncelle.su = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            giderGuncelle.dogalgaz = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            giderGuncelle.internet = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            giderGuncelle.gida = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            giderGuncelle.personel = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            giderGuncelle.diger = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            giderGuncelle.Show();
        }
    }
}
