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
    public partial class frmAdminGiris : Form
    {

        SqlBaglantim bgl = new SqlBaglantim();

        public frmAdminGiris()
        {
            InitializeComponent();
        }

        private void frmAdminGiris_Load(object sender, EventArgs e)
        {
            txtSifre.UseSystemPasswordChar = true;
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select *from admin where YoneticiAd=@p1 and YoneticiSifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtKullaniciAdi.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader reader = komut.ExecuteReader();
            if (reader.Read())
            {
                frmAnaForm anaForm = new frmAnaForm();
                anaForm.ShowDialog();
                this.Hide();
            }
            else
            {
                MessageBox.Show("hatalı kullanıcı adı veya şifre");
                txtKullaniciAdi.Text = txtSifre.Text = string.Empty;
                txtKullaniciAdi.Focus();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtSifre.UseSystemPasswordChar = false;
            }
            else
            {
                txtSifre.UseSystemPasswordChar = true;
            }
        }
    }
}
