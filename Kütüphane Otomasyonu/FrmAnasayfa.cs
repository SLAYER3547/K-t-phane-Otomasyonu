using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kütüphane_Otomasyonu
{
    public partial class FrmAnasayfa : Form
    {
        public FrmAnasayfa()
        {
            InitializeComponent();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            //Üye ekleme formunu açmak
            FrmKisiEkle yeni = new FrmKisiEkle();
            yeni.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            //Ödünç alma sayfası
            FrmOduncAl yeni = new FrmOduncAl();
            yeni.Show();
            this.Hide();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            //Kitap ekleme formunu açmak
            FrmKitapEkle yeni = new FrmKitapEkle();
            yeni.Show();
            this.Hide();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            //Ödünç verme sayfasına gitmek
            FrmOduncver yeni = new FrmOduncver();
            yeni.Show();
            this.Hide();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            //istatistik sayfası açma
            Frmistatistik yeni = new Frmistatistik();
            yeni.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            //takvim sayfası
            FrmTakvim yeni = new FrmTakvim();
            yeni.Show();
        }
    }
}
