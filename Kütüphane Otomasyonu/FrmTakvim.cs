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
    public partial class FrmTakvim : Form
    {
        public FrmTakvim()
        {
            InitializeComponent();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Ana sayfa
            FrmAnasayfa yeni = new FrmAnasayfa();
            yeni.Show();
            this.Hide();
        }
        //sql bağlantısı
        Class1 baglan = new Class1();
        private void button1_Click(object sender, EventArgs e)
        {
            //Notu kaydetme
            SqlCommand cmd = new SqlCommand("insert into Notlar (baslik,Notum) values(@p1,@p2)", baglan.baglan());
            cmd.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd.Parameters.AddWithValue("@p2", richTextBox1.Text);
            cmd.ExecuteNonQuery();
            baglan.baglan().Close();
            MessageBox.Show("Not kaydedildi.");
            textBox1.Clear();
            richTextBox1.Clear();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Not formunu açma
            FrmNotlar yeni = new FrmNotlar();
            yeni.Show();
        }
    }
}
