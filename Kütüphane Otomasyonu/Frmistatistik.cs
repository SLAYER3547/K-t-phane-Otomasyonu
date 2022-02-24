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
using System.Data.SqlClient;

namespace Kütüphane_Otomasyonu
{
    public partial class Frmistatistik : Form
    {
        public Frmistatistik()
        {
            InitializeComponent();
        }
        //sql bağlantısı
        Class1 baglan = new Class1();
        private void Frmistatistik_Load(object sender, EventArgs e)
        {
            //toplam kayıtlı kitap sayısı
            SqlCommand cmd = new SqlCommand("Select Count (*) From Kitapekle ", baglan.baglan());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                label5.Text = dr[0].ToString();
            }
            //toplam kayıtlı üye sayısı
            SqlCommand cmd2 = new SqlCommand("Select Count (*) From Uye", baglan.baglan());
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                label6.Text = dr2[0].ToString();
            }
            //toplam ödünç alınan kitap sayısı
            SqlCommand cmd3 = new SqlCommand("Select Count (*) From Kitapekle where durum=1", baglan.baglan());
            SqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                label7.Text = dr3[0].ToString();
            }
            //Kütüphanede aktif olarak bulunan kitap sayısı
            SqlCommand cmd4 = new SqlCommand("Select Count (*) From Kitapekle where durum=0", baglan.baglan());
            SqlDataReader dr4 = cmd4.ExecuteReader();
            while (dr4.Read())
            {
                label8.Text = dr4[0].ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //ana sayfa
            FrmAnasayfa yeni = new FrmAnasayfa();
            yeni.Show();
            this.Hide();
        }
    }
}
