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
    public partial class frmBolumler : Form
    {
        private SqlBaglantim bgl = new SqlBaglantim();
        public frmBolumler()
        {
            InitializeComponent();
        }

        private void frmBolumler_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'yurtKayitDataSet.Bolumler' table. You can move, or remove it, as needed.
            this.bolumlerTableAdapter.Fill(this.yurtKayitDataSet.Bolumler);

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("insert into Bolumler (BolumAd) values (@p1)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txtBolumAd.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Bölüm Eklendi");
                txtBolumAd.Text = "";
                txtBolumId.Text = "";
                this.bolumlerTableAdapter.Fill(this.yurtKayitDataSet.Bolumler);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("delete from Bolumler where Bolumid = @p1", bgl.baglanti());
                int bolumid = int.Parse(txtBolumId.Text);
                komut.Parameters.AddWithValue("@p1", bolumid);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Bölüm silindi");
                txtBolumAd.Text = "";
                txtBolumId.Text = "";
                this.bolumlerTableAdapter.Fill(this.yurtKayitDataSet.Bolumler);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtBolumId.Text = dataGridView1.CurrentRow.Cells["bolumidDataGridViewTextBoxColumn"].Value.ToString();
            txtBolumAd.Text = dataGridView1.CurrentRow.Cells["bolumAdDataGridViewTextBoxColumn"].Value.ToString();

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("update Bolumler set BolumAd = @p1 where Bolumid = @p2", bgl.baglanti());
                int bolumid = int.Parse(txtBolumId.Text);
                komut.Parameters.AddWithValue("@p1", txtBolumAd.Text);
                komut.Parameters.AddWithValue("@p2", bolumid);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Bölüm güncellendi");
                txtBolumAd.Text = "";
                txtBolumId.Text = "";
                this.bolumlerTableAdapter.Fill(this.yurtKayitDataSet.Bolumler);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
