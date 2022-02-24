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
    public partial class FrmKitapEkle : Form
    {
        public FrmKitapEkle()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        //sql bağlantısını çağırmak için bir nesne oluşturduk
        Class1 baglan = new Class1();
        private void button1_Click(object sender, EventArgs e)
        {
            //Kitap ekleme
            SqlCommand cmd = new SqlCommand("insert into Kitapekle(kitapadi,yazar,yayinevi,tarih,tur,sayfa,durum) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7)", baglan.baglan());
            cmd.Parameters.AddWithValue("@p1", txtad.Text);
            cmd.Parameters.AddWithValue("@p2", txtyazar.Text);
            cmd.Parameters.AddWithValue("@p3", txtyayın.Text);
            cmd.Parameters.AddWithValue("@p4", maskedTextBox1.Text);
            cmd.Parameters.AddWithValue("@p5", cmbtur.Text);
            cmd.Parameters.AddWithValue("@p6", txtsayfa.Text);
            cmd.Parameters.AddWithValue("@p7", checkBox1.Checked);
            cmd.ExecuteNonQuery();
            baglan.baglan().Close();
            MessageBox.Show("Kitap başarıyla eklendi");
            txtad.Clear();
            txtyazar.Clear();
            txtyayın.Clear();
            maskedTextBox1.Text = "";
            cmbtur.Text = "";
            txtsayfa.Clear();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select kitapadi as KitapAdı,yazar as Yazar,yayinevi as Yayınevi,tarih as BasımTarihi,tur as Türü,demirbas as DemirbaşNo,sayfa as SayfaSayısı From Kitapekle", baglan.baglan());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void FrmKitapEkle_Load(object sender, EventArgs e)
        {
            //Datagride verileri getirme
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select kitapadi as KitapAdı,yazar as Yazar,yayinevi as Yayınevi,tarih as BasımTarihi,tur as Türü,demirbas as DemirbaşNo,sayfa as SayfaSayısı  From Kitapekle", baglan.baglan());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Kitap silme
            SqlCommand cmd = new SqlCommand("Delete From Kitapekle where demirbas=@p1", baglan.baglan());
            cmd.Parameters.AddWithValue("@p1", txtno.Text);
            cmd.ExecuteNonQuery();
            baglan.baglan().Close();
            MessageBox.Show("Kitap başarıyla silindi");
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select kitapadi as KitapAdı,yazar as Yazar,yayinevi as Yayınevi,tarih as BasımTarihi,tur as Türü,demirbas as DemirbaşNo,sayfa as SayfaSayısı  From Kitapekle", baglan.baglan());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //datagride çift tıklayınca verileri araçlara taşıma
            int deger = dataGridView1.SelectedCells[0].RowIndex;
            txtad.Text = dataGridView1.Rows[deger].Cells[0].Value.ToString();
            txtyazar.Text = dataGridView1.Rows[deger].Cells[1].Value.ToString();
            txtyayın.Text = dataGridView1.Rows[deger].Cells[2].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[deger].Cells[3].Value.ToString();
            cmbtur.Text = dataGridView1.Rows[deger].Cells[4].Value.ToString();
            txtno.Text = dataGridView1.Rows[deger].Cells[5].Value.ToString();
            txtsayfa.Text = dataGridView1.Rows[deger].Cells[6].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Ana sayfaya dönme

            FrmAnasayfa yeni = new FrmAnasayfa();
            yeni.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Kitap güncelleme

            SqlCommand cmd = new SqlCommand("Update Kitapekle Set kitapadi=@p1,yazar=@p2,yayinevi=@p3,tarih=@p4,tur=@p5,sayfa=@p6 where demirbas=@p7", baglan.baglan());
            cmd.Parameters.AddWithValue("@p1", txtad.Text);
            cmd.Parameters.AddWithValue("@p2", txtyazar.Text);
            cmd.Parameters.AddWithValue("@p3", txtyayın.Text);
            cmd.Parameters.AddWithValue("@p4", maskedTextBox1.Text);
            cmd.Parameters.AddWithValue("@p5", cmbtur.Text);
            cmd.Parameters.AddWithValue("@p6", txtsayfa.Text);
            cmd.Parameters.AddWithValue("@p7", txtno.Text);
            cmd.ExecuteNonQuery();
            baglan.baglan().Close();
            MessageBox.Show("Kitap başarıyla güncellendi");
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select kitapadi as KitapAdı,yazar as Yazar,yayinevi as Yayınevi,tarih as BasımTarihi,tur as Türü,demirbas as DemirbaşNo,sayfa as SayfaSayısı  From Kitapekle", baglan.baglan());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Arama yapmak
            SqlCommand cmd = new SqlCommand("Select *From Kitapekle where kitapadi like '%" + textBox1.Text + "%'", baglan.baglan());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglan.baglan().Close();
        }
    }
}
