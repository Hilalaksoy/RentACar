using RentACar.DATA;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DAL
{
    public class UyeMapping : EntityTypeConfiguration<Uye>
    {
        public UyeMapping()
        {
            ToTable("Uyeler");
            HasKey(x => x.UyeID);
            Property(x => x.Email).HasMaxLength(50).IsRequired();
            Property(x => x.Sifre).HasMaxLength(15).IsRequired();


            HasRequired(x => x.Musteri).WithRequiredPrincipal(x => x.Uye); //Bire- bir
        }
    }
}
