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
    public partial class frmGelirIstatistik : Form
    {
        private SqlBaglantim bgl = new SqlBaglantim();
        public frmGelirIstatistik()
        {
            InitializeComponent();
        }

        private void frmGelirIstatistik_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select sum(OdemeMiktar) from Kasa", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                lblPara.Text = oku[0].ToString() + " ₺";
            }
            bgl.baglanti().Close();

            SqlCommand komut2 = new SqlCommand("Select distinct(OdemeAy) from Kasa", bgl.baglanti());
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                cmbAy.Items.Add(oku2[0].ToString());
            }
            bgl.baglanti().Close();

            SqlCommand komut3 = new SqlCommand("select k.OdemeAy,sum(k.OdemeMiktar)from Kasa k group by k.OdemeAy"
                , bgl.baglanti());
            SqlDataReader oku3 = komut3.ExecuteReader();
            while (oku3.Read())
            {
                this.chart1.Series["Aylık"].Points.AddXY(oku3["OdemeAy"], oku3[1].ToString());
            }
            bgl.baglanti().Close();

        }

        private void cmbAy_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select sum(OdemeMiktar) from Kasa where " +
                                              "OdemeAy=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbAy.Text);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                lblAyKazanc.Text = oku[0].ToString() +" ₺";
            }
            bgl.baglanti().Close();
        }
    }
}
