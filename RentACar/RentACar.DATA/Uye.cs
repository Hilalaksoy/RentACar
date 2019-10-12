using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DATA
{
    public class Uye
    {
        public int UyeID { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }
        public bool AdminMi { get; set; }

        public virtual Musteri Musteri { get; set; } //Bire- Bir
    }
}
