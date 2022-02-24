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
    public partial class FrmOduncAl : Form
    {
        public FrmOduncAl()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Ödünç alınan kitaplar sayfası
            FrmOdunckitaplar yeni = new FrmOdunckitaplar();
            yeni.Show();
        }
        //sql bağlantısı
        Class1 baglan = new Class1();
        private void FrmOduncAl_Load(object sender, EventArgs e)
        {
            //Comboboxa kayıtlı kitapları çekme
            SqlCommand cmd = new SqlCommand("Select kitapadi From Kitapekle where durum=1", baglan.baglan());
            SqlDataReader dr = cmd.ExecuteReader();
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
            //Kitabı alan üyeyi getirme
            SqlCommand cmd4 = new SqlCommand("Select *From Kitapekle where kitapadi=@p1", baglan.baglan());
            cmd4.Parameters.AddWithValue("@p1", comboBox1.Text);
            SqlDataReader dr4 = cmd4.ExecuteReader();
            while (dr4.Read())
            {
                textBox2.Text = dr4[10].ToString();
            }
            //Kitabın ödünç tarihini getirme
            SqlCommand cmd5 = new SqlCommand("Select *From Kitapekle where kitapadi=@p1", baglan.baglan());
            cmd5.Parameters.AddWithValue("@p1", comboBox1.Text);
            SqlDataReader dr5 = cmd5.ExecuteReader();
            while (dr5.Read())
            {
                maskedTextBox1.Text = dr5[8].ToString();
            }

            //Kitabın iade tarihini getirme
            SqlCommand cmd6 = new SqlCommand("Select *From Kitapekle where kitapadi=@p1", baglan.baglan());
            cmd6.Parameters.AddWithValue("@p1", comboBox1.Text);
            SqlDataReader dr6 = cmd6.ExecuteReader();
            while (dr6.Read())
            {
                maskedTextBox2.Text = dr6[9].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // İade alma
            SqlCommand cmd = new SqlCommand("Update Kitapekle Set durum=0,kitapadi=@p1,uyead=NULL,vermetarihi=NULL,almatarihi=NULL where demirbas=@p2", baglan.baglan());
            cmd.Parameters.AddWithValue("@p1", comboBox1.Text);
            cmd.Parameters.AddWithValue("@p2", textBox1.Text);
            cmd.ExecuteNonQuery();
            baglan.baglan().Close();
            MessageBox.Show("Kitap iade alındı");
            comboBox1.Text = "";
            textBox2.Clear();
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
            textBox1.Clear();
            //Comboboxa kayıtlı kitapları çekme Aynı kitap tekrar iade edilmesin diye
            comboBox1.Items.Clear();
            SqlCommand cmd2 = new SqlCommand("Select kitapadi From Kitapekle where durum=1 ", baglan.baglan());
            SqlDataReader dr = cmd2.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ana sayfa
            FrmAnasayfa yeni = new FrmAnasayfa();
            yeni.Show();
            this.Hide();
        }
    }
}
