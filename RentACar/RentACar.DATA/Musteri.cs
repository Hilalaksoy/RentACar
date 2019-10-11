using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DATA
{
    public class Musteri
    {
        public int UyeID { get; set; }
        public string TcKimlikNo { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string Memleket { get; set; }

        public byte[] NufusResim { get; set; }

        public string AdSoyad { get { return Ad + " " + Soyad; } }  

        public virtual Uye Uye { get; set; } //Bire-bir

        public virtual List<Kiralama> Kiralamalar { get; set; }  //Bire- çok

    }
}
