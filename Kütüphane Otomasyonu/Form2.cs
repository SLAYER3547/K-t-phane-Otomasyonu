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
    public partial class FrmKisiEkle : Form
    {
        public FrmKisiEkle()
        {
            InitializeComponent();
        }
        //Sql bağlantımız
        Class1 baglan = new Class1();
        private void Form2_Load(object sender, EventArgs e)
        {
            //Data gride verileri getirdik
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select adsoyad as İsim,TC as TC,tel as Telefon,kayıttarih as KayıtTarihi,email as EMail,adres as Adres,no as ÜyeNo From Uye", baglan.baglan());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Üye ekleme
            SqlCommand cmd = new SqlCommand("insert into Uye(adsoyad,TC,tel,kayıttarih,email,adres) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglan.baglan());
            cmd.Parameters.AddWithValue("@p1", txtad.Text);
            cmd.Parameters.AddWithValue("@p2", msktc.Text);
            cmd.Parameters.AddWithValue("@p3", msktel.Text);
            cmd.Parameters.AddWithValue("@p4", msktarih.Text);
            cmd.Parameters.AddWithValue("@p5", txtemail.Text);
            cmd.Parameters.AddWithValue("@p6", richTextBox1.Text);
            cmd.ExecuteNonQuery();
            baglan.baglan().Close();
            MessageBox.Show("Üye başarıyla eklendi");
            txtad.Clear();
            msktarih.Text = "";
            msktc.Text = "";
            msktel.Text = "";
            txtemail.Clear();
            richTextBox1.Clear();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select adsoyad as İsim,TC as TC,tel as Telefon,kayıttarih as KayıtTarihi,email as EMail,adres as Adres,no as ÜyeNo From Uye", baglan.baglan());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Üye Güncelleme
            SqlCommand cmd = new SqlCommand("Update Uye Set adsoyad=@p1,TC=@p2,tel=@p3,kayıttarih=@p4,email=@p5,adres=@p6 where no=@p7", baglan.baglan());
            cmd.Parameters.AddWithValue("@p1", txtad.Text);
            cmd.Parameters.AddWithValue("@p2", msktc.Text);
            cmd.Parameters.AddWithValue("@p3", msktel.Text);
            cmd.Parameters.AddWithValue("@p4", msktarih.Text);
            cmd.Parameters.AddWithValue("@p5", txtemail.Text);
            cmd.Parameters.AddWithValue("@p6", richTextBox1.Text);
            cmd.Parameters.AddWithValue("@p7", txtno.Text);
            cmd.ExecuteNonQuery();
            baglan.baglan().Close();
            MessageBox.Show("Üye başarıyla güncellendi");
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select adsoyad as İsim,TC as TC,tel as Telefon,kayıttarih as KayıtTarihi,email as EMail,adres as Adres,no as ÜyeNo From Uye", baglan.baglan());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //data griddeki verileri araçlara taşıma
            int deger = dataGridView1.SelectedCells[0].RowIndex;
            txtad.Text = dataGridView1.Rows[deger].Cells[0].Value.ToString();
            msktc.Text = dataGridView1.Rows[deger].Cells[1].Value.ToString();
            msktel.Text = dataGridView1.Rows[deger].Cells[2].Value.ToString();
            msktarih.Text=dataGridView1.Rows[deger].Cells[3].Value.ToString();
            txtemail.Text = dataGridView1.Rows[deger].Cells[4].Value.ToString();
            richTextBox1.Text = dataGridView1.Rows[deger].Cells[5].Value.ToString();
            txtno.Text = dataGridView1.Rows[deger].Cells[6].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Ana sayfaya dönme
            FrmAnasayfa yeni = new FrmAnasayfa();
            yeni.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Silme İşlemi

            SqlCommand cmd = new SqlCommand("Delete From Uye where no=@p1",baglan.baglan());
            cmd.Parameters.AddWithValue("@p1", txtno.Text);
            cmd.ExecuteNonQuery();
            baglan.baglan().Close();
            MessageBox.Show("Üye başarıyla silindi");
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select adsoyad as İsim,TC as TC,tel as Telefon,kayıttarih as KayıtTarihi,email as EMail,adres as Adres,no as ÜyeNo From Uye", baglan.baglan());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Üye aratma
            SqlCommand cmd = new SqlCommand("Select *From Uye where adsoyad like '%" + textBox1.Text + "%'", baglan.baglan());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglan.baglan().Close();

        }
    }
}
