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
    public partial class frmOgrKayit : Form
    {
        private SqlBaglantim bgl = new SqlBaglantim();

        public frmOgrKayit()
        {
            InitializeComponent();
        }
        private void BolumDoldur()
        {
            SqlCommand komut = new SqlCommand("select BolumAd from Bolumler", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                cmbBolum.Items.Add(oku[0].ToString());
            }
            bgl.baglanti().Close();
        }
        private void OdaCmbDoldur()
        {
            SqlCommand komut = new SqlCommand("select OdaNo from Odalar where not OdaKapasite = OdaAktif ", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                cmbOdaNo.Items.Add(oku[0].ToString());
            }
            bgl.baglanti().Close();
        }

        void Temizle()
        {
            txtAdres.Text = "";
            txtDogumTarihi.Text = "";
            txtMail.Text = "";
            txtOgrTel.Text = "";
            txtVeliAdSoyad.Text = "";
            txtVeliTel.Text = "";
            txtOgrAd.Text = "";
            txtOgrSoyad.Text = "";
            txtTC.Text = "";
            cmbBolum.Text = "";
            cmbOdaNo.Text = "";
        }

        private void frmOgrKayit_Load(object sender, EventArgs e)
        {
            BolumDoldur();
            OdaCmbDoldur();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                string sorgu = "insert into Ogrenci (OgrAd,OgrSoyad,OgrTC,OgrTelefon,OgrDogum,OgrBolum,OgrMail,OgrOdaNo,OgrVeliAdSoyad,OgrVeliTelefon,OgrVeliAdres) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)";
                SqlCommand komut = new SqlCommand(sorgu, bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txtOgrAd.Text);
                komut.Parameters.AddWithValue("@p2", txtOgrSoyad.Text);
                komut.Parameters.AddWithValue("@p3", txtTC.Text);
                komut.Parameters.AddWithValue("@p4", txtOgrTel.Text);
                komut.Parameters.AddWithValue("@p5", txtDogumTarihi.Text);
                komut.Parameters.AddWithValue("@p6", cmbBolum.Text);
                komut.Parameters.AddWithValue("@p7", txtMail.Text);
                komut.Parameters.AddWithValue("@p8", cmbOdaNo.Text);
                komut.Parameters.AddWithValue("@p9", txtVeliAdSoyad.Text);
                komut.Parameters.AddWithValue("@p10", txtVeliTel.Text);
                komut.Parameters.AddWithValue("@p11", txtAdres.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Kayıt başarıyla tamamlanmıştır", "KAYIT", MessageBoxButtons.OK, MessageBoxIcon.Information);


                SqlCommand komut2 = new SqlCommand("select Ogrid from Ogrenci", bgl.baglanti());
                SqlDataReader oku = komut2.ExecuteReader();
                while (oku.Read())
                {
                    label12.Text = oku[0].ToString();
                }
                bgl.baglanti().Close();


                SqlCommand komutkaydet2 = new SqlCommand("insert into Borclar (Ogrid,OgrAd,OgrSoyad) values (@b1,@b2,@b3)", bgl.baglanti());
                komutkaydet2.Parameters.AddWithValue("@b1", label12.Text);
                komutkaydet2.Parameters.AddWithValue("@b2", txtOgrAd.Text);
                komutkaydet2.Parameters.AddWithValue("@b3", txtOgrSoyad.Text);
                komutkaydet2.ExecuteNonQuery();
                bgl.baglanti().Close();


                SqlCommand komutOda = new SqlCommand("update odalar set odaaktif+=1 where odano=@oda", bgl.baglanti());
                komutOda.Parameters.AddWithValue("@oda", cmbOdaNo.Text);
                komutOda.ExecuteNonQuery();
                bgl.baglanti().Close();


                Temizle();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
