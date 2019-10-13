using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DATA
{
    public class Araba
    {
        public int ID { get; set; }
        public string SasiNo { get; set; }
        public string Model { get; set; }
        public string Marka { get; set; }
        public DateTime CikisTarihi { get; set; }

        public bool KiradaMi { get; set; }
        public int Mesafe { get; set; }
        public int YillikMesafe { get; set; }

        public virtual Kiralama Kiralama { get; set; }  //Bire-Bir

        public virtual List<Resim> Resimler { get; set; }  //Bire - çok

        public override string ToString()
        {
            return Marka + " " + Model;
        }
    }
}
