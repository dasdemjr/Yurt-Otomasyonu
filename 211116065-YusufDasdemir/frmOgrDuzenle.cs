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
    public partial class frmOgrDuzenle : Form
    {
        public string id, ad, soyad, Tc, telefon, dogum, bolum, mail, odano, veliad, velitel, adres;

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("delete from ogrenci where ogrid=@ogrid", bgl.baglanti());
            komutsil.Parameters.AddWithValue("@ogrid", int.Parse(txtID.Text));
            komutsil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("kayıt silindi");

            //odanın aktif öğrenci sayısını azaltma
            SqlCommand komutoda = new SqlCommand("update Odalar set odaaktif-=1 " +
                                                 "where odano=@odano ", bgl.baglanti());
            komutoda.Parameters.AddWithValue("@odano", cmbOdaNo.Text);
            komutoda.ExecuteNonQuery();
            bgl.baglanti().Close();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("update Ogrenci set " +
                                                      "OgrAd=@p2,OgrSoyad=@p3,OgrTc=@p4,OgrTelefon=@p5,OgrDogum=@p6,OgrBolum=@p7," +
                                                      "OgrMail=@p8,OgrOdaNo=@p9,OgrVeliAdSoyad=@p10,OgrVeliTelefon=@p11,OgrVeliAdres=@p12" +
                                                      " where Ogrid=@p1", bgl.baglanti());

                komut.Parameters.AddWithValue("@p1", txtID.Text);
                komut.Parameters.AddWithValue("@p2", txtOgrAd.Text);
                komut.Parameters.AddWithValue("@p3", txtOgrSoyad.Text);
                komut.Parameters.AddWithValue("@p4", txtTC.Text);
                komut.Parameters.AddWithValue("@p5", txtOgrTel.Text);
                komut.Parameters.AddWithValue("@p6", txtDogumTarihi.Text);
                komut.Parameters.AddWithValue("@p7", cmbBolum.Text);
                komut.Parameters.AddWithValue("@p8", txtMail.Text);
                komut.Parameters.AddWithValue("@p9", cmbOdaNo.Text);
                komut.Parameters.AddWithValue("@p10", txtVeliAdSoyad.Text);
                komut.Parameters.AddWithValue("@p11", txtVeliTel.Text);
                komut.Parameters.AddWithValue("@p12", txtAdres.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("kayıt güncellendi");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        SqlBaglantim bgl = new SqlBaglantim();
        private void frmOgrDuzenle_Load(object sender, EventArgs e)
        {
            txtID.Text = id;
            txtOgrAd.Text = ad;
            txtOgrSoyad.Text = soyad;
            txtTC.Text = Tc;
            txtOgrTel.Text = telefon;
            txtDogumTarihi.Text = dogum;
            cmbBolum.Text = bolum;
            txtMail.Text = mail;
            cmbOdaNo.Text = odano;
            txtVeliAdSoyad.Text = veliad;
            txtVeliTel.Text = velitel;
            txtAdres.Text = adres;
            SqlCommand komut = new SqlCommand("select BolumAd from Bolumler order by BolumAd", bgl.baglanti());
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                cmbBolum.Items.Add(read[0]);
            }

            bgl.baglanti().Close();
            SqlCommand komut2 = new SqlCommand("select OdaNo from Odalar where OdaKapasite!=OdaAktif", bgl.baglanti());
            read = komut2.ExecuteReader();
            while (read.Read())
            {
                cmbOdaNo.Items.Add(read[0]);
            }
            bgl.baglanti().Close();
        }

        public frmOgrDuzenle()
        {
            InitializeComponent();
        }
    }
}
