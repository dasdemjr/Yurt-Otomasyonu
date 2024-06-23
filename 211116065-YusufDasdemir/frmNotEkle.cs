using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _211116065_YusufDasdemir
{
    public partial class frmNotEkle : Form
    {
        public frmNotEkle()
        {
            InitializeComponent();
        }

        private void btnNotEkle_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Title = "Kayıt yeri Seçin";
                saveFileDialog1.Filter = "Metin dosyası | *.txt";
                saveFileDialog1.InitialDirectory = "D:\\2. Sınıf Bahar Dönemi\\211116065-YusufDasdemir";
                saveFileDialog1.ShowDialog();
                StreamWriter kaydet = new StreamWriter(saveFileDialog1.FileName);
                kaydet.WriteLine(richTextBox1.Text + "\n");
                kaydet.Close();
                MessageBox.Show("kayıt yapıldı");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
