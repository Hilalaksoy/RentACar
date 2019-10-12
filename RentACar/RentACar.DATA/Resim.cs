using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DATA
{
    public class Resim
    {
        public int ResimID { get; set; }
        public byte[] Fotograf { get; set; }

        public int ID { get; set; }
        public virtual Araba Araba { get; set; }
    }
}
