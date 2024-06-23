using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _211116065_YusufDasdemir
{
    public partial class frmOgrRapor : Form
    {
        public frmOgrRapor()
        {
            InitializeComponent();
        }

        private void frmOgrRapor_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'YurtKayitDataSet7.Ogrenci' table. You can move, or remove it, as needed.
            this.OgrenciTableAdapter.Fill(this.YurtKayitDataSet7.Ogrenci);

            this.reportViewer1.RefreshReport();
        }
    }
}
