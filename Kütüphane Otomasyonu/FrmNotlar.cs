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
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }
        //sql bağlantısı
        Class1 baglan = new Class1();
       
        private void FrmNotlar_Load(object sender, EventArgs e)
        {

          


            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select baslik as Başlık,Notum as Notlar From Notlar", baglan.baglan());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Notları silmek için label textini seçilen değere atadık 
            SqlCommand cmd2 = new SqlCommand("Select Notum From Notlar", baglan.baglan());
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                label1.Text = dr2[0].ToString();
            }
            //Notları silme
            SqlCommand cmd = new SqlCommand("Delete From Notlar where Notum=@p1", baglan.baglan());
            cmd.Parameters.AddWithValue("@p1", label1.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Not başarıyla silindi");
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select baslik as Başlık,Notum as Notlar From Notlar", baglan.baglan());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
