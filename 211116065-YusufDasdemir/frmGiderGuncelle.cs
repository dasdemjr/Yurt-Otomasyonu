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
    public partial class frmGiderGuncelle : Form
    {
        SqlBaglantim bgl = new SqlBaglantim();

        public string elektrik, su, dogalgaz, internet, gida, personel, diger, id;

        private void frmGiderGuncelle_Load(object sender, EventArgs e)
        {
            txtId.Text = id;
            txtElektirk.Text = elektrik;
            txtDogalgaz.Text = dogalgaz;
            txtSu.Text = su;
            txtInternet.Text = internet;
            txtPersonel.Text = personel;
            txtDiger.Text = diger;
            txtGida.Text = gida;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("update giderler set Elektrik=@p1,Su=@p2,Dogalgaz=@p3,internet=@p4,Gida=@p5,Personel=@p6,Diger=@p7 where Odemeid=@p0", bgl.baglanti());
                komut.Parameters.AddWithValue("@p0", txtId.Text);
                komut.Parameters.AddWithValue("@p1", txtElektirk.Text);
                komut.Parameters.AddWithValue("@p2", txtSu.Text);
                komut.Parameters.AddWithValue("@p3", txtDogalgaz.Text);
                komut.Parameters.AddWithValue("@p4", txtInternet.Text);
                komut.Parameters.AddWithValue("@p5", txtGida.Text);
                komut.Parameters.AddWithValue("@p6", txtPersonel.Text);
                komut.Parameters.AddWithValue("@p7", txtDiger.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("gider güncelleme işlemi yapıldı");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public frmGiderGuncelle()
        {
            InitializeComponent();
        }
    }
}
