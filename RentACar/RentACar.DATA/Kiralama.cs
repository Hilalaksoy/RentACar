using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DATA
{
    public class Kiralama
    {
        public int ID { get; set; }
        public int GunSayisi { get; set; }
        public decimal Fiyat { get; set; }  //İndirimli Fiyat
        public float Indirim { get; set; }
        public DateTime KiralamaTarihi { get; set; }

        public int MusteriID { get; set; }  //FK 
        public virtual Araba Araba { get; set; } // Bire -bir
        public virtual Musteri Musteri { get; set; } //Bire - çok
    }
}
