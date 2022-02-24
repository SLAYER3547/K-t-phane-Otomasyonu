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
    public partial class FrmOdunckitaplar : Form
    {
        public FrmOdunckitaplar()
        {
            InitializeComponent();
        }
        // sql bağlantısı
        Class1 baglan = new Class1();
        private void FrmOdunckitaplar_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select kitapadi as KitapAdı,yazar as Yazar,demirbas as DemirbaşNo,vermetarihi as ÖdünçTarihi,almatarihi as İadeTarihi,uyead as Üye From Kitapekle where durum=1", baglan.baglan());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
    }
}
