using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Kütüphane_Otomasyonu
{
    class Class1
    {
        //Sql için bağlantı sınıfı oluşturduk
        public SqlConnection baglan()
        {
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-FDGOUMJ;Initial Catalog=Kutuphane Otomasyonu;Integrated Security=True");
            baglanti.Open();
            return baglanti;
        }
    }
}
