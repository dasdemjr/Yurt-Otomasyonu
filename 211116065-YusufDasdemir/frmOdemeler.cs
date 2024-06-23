using DevExpress.Data.Linq.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _211116065_YusufDasdemir
{
    public partial class frmOdemeler : Form
    {
        private SqlBaglantim bgl = new SqlBaglantim();
        public frmOdemeler()
        {
            InitializeComponent();
        }

        private void frmOdemeler_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'yurtKayitDataSet2.Borclar' table. You can move, or remove it, as needed.
            this.borclarTableAdapter.Fill(this.yurtKayitDataSet2.Borclar);
            for (int i = 0; i < 7; i++)
            {
                cmbYil.Items.Add((DateTime.Now.Year - 3 + i).ToString());
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen;
            string id, ad, soyad, kalan;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            soyad = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            kalan = dataGridView1.Rows[secilen].Cells[3].Value.ToString();

            txtAdi.Text = ad;
            txtSoyadi.Text = soyad;
            txtID.Text = id;
            txtKalan.Text = kalan;
        }

        private void btnOdemeAl_Click(object sender, EventArgs e)
        {
            int odenen, kalan, yeniborc;
            odenen = short.Parse(txtOdenen.Text);
            kalan = short.Parse(txtKalan.Text);
            yeniborc = kalan - odenen;
            txtKalan.Text = yeniborc.ToString();

            SqlCommand komut = new SqlCommand("update Borclar set OgrKalanBorc=@p1 where Ogrid=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p2", txtID.Text);
            komut.Parameters.AddWithValue("@p1", txtKalan.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("borç ödendi");
            this.borclarTableAdapter.Fill(this.yurtKayitDataSet2.Borclar);

            SqlCommand komut2 = new SqlCommand("insert into Kasa(OdemeAy,OdemeMiktar) values(@k1,@k2)", bgl.baglanti());
            komut2.Parameters.AddWithValue("@k1", cmbAy.Text + " " + cmbYil.Text);
            komut2.Parameters.AddWithValue("@k2", txtOdenen.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
        }

    }

}
