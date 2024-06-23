using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _211116065_YusufDasdemir
{
    public partial class frmYoneticiDuzenle : Form
    {
        SqlBaglantim bgl = new SqlBaglantim();

        public frmYoneticiDuzenle()
        {
            InitializeComponent();
        }

        private void frmYoneticiDuzenle_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'yurtKayitDataSet5.Admin' table. You can move, or remove it, as needed.
            this.adminTableAdapter.Fill(this.yurtKayitDataSet5.Admin);

        }

        void Temizle()
        {
            txtYoneticiID.Text = "";
            txtKullaniciAdi.Text = "";
            txtSifre.Text = "";
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Admin (YoneticiAd,YoneticiSifre) " +
                                              "values(@p1,@p2)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtKullaniciAdi.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("yönetici eklendi");
            this.adminTableAdapter.Fill(this.yurtKayitDataSet5.Admin);
            Temizle();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            string ad, sifre, id;
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            sifre = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtYoneticiID.Text = id;
            txtKullaniciAdi.Text = ad;
            txtSifre.Text = sifre;

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from Admin where Yoneticiid=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtYoneticiID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Silme işlemi gerçekleştirildi");
            this.adminTableAdapter.Fill(this.yurtKayitDataSet5.Admin);
            Temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("update Admin set YoneticiAd=@p1,YoneticiSifre=@p2 " +
                                                  "where Yoneticiid=@p0", bgl.baglanti());
                komut.Parameters.AddWithValue("@p0", int.Parse(txtYoneticiID.Text));
                komut.Parameters.AddWithValue("@p1", txtKullaniciAdi.Text);
                komut.Parameters.AddWithValue("@p2", txtSifre.Text);

                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Güncelleme işlemi tamamlandı");
                this.adminTableAdapter.Fill(this.yurtKayitDataSet5.Admin);
                Temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
