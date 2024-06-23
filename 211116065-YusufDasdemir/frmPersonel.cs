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
    public partial class frmPersonel : Form
    {
        private SqlBaglantim bgl = new SqlBaglantim();

        public frmPersonel()
        {
            InitializeComponent();
        }

        void Temizle()
        {
            txtID.Text = "";
            txtAdSoyad.Text = "";
            txtDepartman.Text = "";
        }

        private void frmPersonel_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'yurtKayitDataSet6.Personel' table. You can move, or remove it, as needed.
            this.personelTableAdapter.Fill(this.yurtKayitDataSet6.Personel);

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Personel (PersonelAdSoyad,PersonelDepartman)" +
                                              " values(@p1,@p2)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAdSoyad.Text);
            komut.Parameters.AddWithValue("@p2", txtDepartman.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt eklendi");
            this.personelTableAdapter.Fill(this.yurtKayitDataSet6.Personel);
            Temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("delete from Personel where Personelid=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", int.Parse(txtID.Text));
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Kayıt silindi");
                this.personelTableAdapter.Fill(this.yurtKayitDataSet6.Personel);
                Temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komutgun = new SqlCommand("update Personel set PersonelAdSoyad=@p1,PersonelDepartman=@p2" +
                                                     " where Personelid=@p0", bgl.baglanti());
                komutgun.Parameters.AddWithValue("@p0", byte.Parse(txtID.Text));
                komutgun.Parameters.AddWithValue("@p1", txtAdSoyad.Text);
                komutgun.Parameters.AddWithValue("@p2", txtDepartman.Text);
                komutgun.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("kayıt güncellendi");
                this.personelTableAdapter.Fill(this.yurtKayitDataSet6.Personel);
                Temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtAdSoyad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtDepartman.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
        }
    }
}
