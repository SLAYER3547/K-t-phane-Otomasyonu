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
    public partial class FrmKayıt : Form
    {
        public FrmKayıt()
        {
            InitializeComponent();
        }
        // Sql kullanmak için oluşturduğumuz sınıftan bir nesne oluşturduk
        Class1 baglan = new Class1();
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            //Kullanıcıyı sisteme kayıt etmek
            SqlCommand cmd = new SqlCommand("insert into Giris(TC,sifre) values (@p1,@p2)", baglan.baglan());
            cmd.Parameters.AddWithValue("@p1", bunifuMetroTextbox1.Text);
            cmd.Parameters.AddWithValue("@p2", bunifuMetroTextbox2.Text);
            cmd.ExecuteNonQuery();
            baglan.baglan().Close();
            MessageBox.Show("Başarıyla kayıt oldunuz.");
            bunifuMetroTextbox1.Text = "";
            bunifuMetroTextbox2.Text = "";
            this.Hide();
        }
    }
}
