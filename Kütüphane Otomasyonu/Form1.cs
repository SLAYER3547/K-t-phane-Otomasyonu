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
    public partial class FRMGIRIS : Form
    {
        public FRMGIRIS()
        {
            InitializeComponent();
        }

        private void bunifuMetroTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }
        Random rastgele = new Random();
        private void FRMGIRIS_Load(object sender, EventArgs e)
        {

            // Captcha Oluşturma
            string[] sembol  =  { "A", "B", "C", "D", "E", "F", "G", "H", "J", "K" };
            string[] sembol2 =  { "L", "M", "N", "O", "P", "R", "S", "T", "U", "V" };
            string[] sembol3 = { "#", "+", "*", "&", "/", "£","@","^","!","?" };
            int s1, s2, s3, s4, s5;

            s1 = rastgele.Next(1, sembol.Length);
            s2 = rastgele.Next(1, sembol2.Length);
            s3 = rastgele.Next(1, sembol3.Length);
            s4 = rastgele.Next(1, 10);
            s5 = rastgele.Next(10, 20);

            label1.Text = sembol[s1] + sembol2[s2] + sembol3[s3].ToString() + s4.ToString() + s5.ToString();
            
        }
        // Sql kullanmak için oluşturduğumuz sınıftan bir nesne oluşturduk
        Class1 baglan = new Class1();
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            //Veri tabanlı kullanıcı girişi yaptık(Bilgilerini doğru girdiği takdirde)
            SqlCommand cmd = new SqlCommand("Select *From Giris Where TC=@p1 and sifre=@p2", baglan.baglan());
            cmd.Parameters.AddWithValue("@p1", bunifuMetroTextbox1.Text);
            cmd.Parameters.AddWithValue("@p2", bunifuMetroTextbox2.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read() & bunifuMetroTextbox3.Text == label1.Text)
            {
                FrmAnasayfa yeni = new FrmAnasayfa();
                yeni.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Lütfen bilgilerinizi kontrol ediniz.");
            }
            baglan.baglan().Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Kayıt olmak isteyen kullanıcıyı kayıt formuna yönlendirdik
            FrmKayıt yeni = new FrmKayıt();
            yeni.Show();
        }
    }
}
