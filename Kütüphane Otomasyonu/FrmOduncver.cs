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

namespace Kütüphane_Otomasyonu
{
    public partial class FrmOduncver : Form
    {
        public FrmOduncver()
        {
            InitializeComponent();
        }
        //Sql bağlantısı
        Class1 baglan = new Class1();
        private void FrmOduncver_Load(object sender, EventArgs e)
        {
            //Comboboxa kayıtlı kitapları çekme
            SqlCommand cmd = new SqlCommand("Select kitapadi From Kitapekle where durum=0 ", baglan.baglan());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            
            //comboboxa kayıtlı üyeleri çekme
            SqlCommand cmd2 = new SqlCommand("Select adsoyad From Uye", baglan.baglan());
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                comboBox2.Items.Add(dr2[0]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            // Ödünç verme
            SqlCommand cmd = new SqlCommand("Update Kitapekle Set durum=1,kitapadi=@p1,uyead=@p2,vermetarihi=@p3,almatarihi=@p4 where demirbas=@p5", baglan.baglan());
            cmd.Parameters.AddWithValue("@p1", comboBox1.Text);
            cmd.Parameters.AddWithValue("@p2", comboBox2.Text);
            cmd.Parameters.AddWithValue("@p3", maskedTextBox1.Text);
            cmd.Parameters.AddWithValue("@p4", maskedTextBox2.Text);
            cmd.Parameters.AddWithValue("@p5", textBox1.Text);
            cmd.ExecuteNonQuery();
            baglan.baglan().Close();
            MessageBox.Show("Kitap ödünç verildi");
            comboBox1.Text = "";
            comboBox2.Text = "";
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
            textBox1.Clear();
            //Comboboxa kayıtlı kitapları çekme Aynı kitap başkasına ödünç verilmesin diye
            comboBox1.Items.Clear();
            SqlCommand cmd2 = new SqlCommand("Select kitapadi From Kitapekle where durum=0 ", baglan.baglan());
            SqlDataReader dr = cmd2.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Kitabın demirbaş nosunu getirme
            SqlCommand cmd3 = new SqlCommand("Select *From Kitapekle where kitapadi=@p1", baglan.baglan());
            cmd3.Parameters.AddWithValue("@p1", comboBox1.Text);
            SqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                textBox1.Text = dr3[5].ToString();
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Ana sayfaya dön
            FrmAnasayfa yeni = new FrmAnasayfa();
            yeni.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //ödünç kitaplar formu
            FrmOdunckitaplar yeni = new FrmOdunckitaplar();
            yeni.Show();
        }
    }
}
