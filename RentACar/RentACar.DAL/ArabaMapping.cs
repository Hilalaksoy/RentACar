using RentACar.DATA;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DAL
{
    public class ArabaMapping : EntityTypeConfiguration<Araba>
    {
        public ArabaMapping()
        {
            ToTable("Arabalar");
            HasKey(x => x.ID);
            Property(x => x.SasiNo).HasMaxLength(17).HasColumnType("char").IsRequired();
            Property(x => x.Marka).HasMaxLength(20).IsRequired();
            Property(x => x.Model).HasMaxLength(20).IsRequired();
            Property(x => x.CikisTarihi).HasColumnType("datetime2").IsRequired();
            //Property(x => x.Resim)
            Property(x => x.KiradaMi).HasColumnType("bit").IsRequired();

            HasRequired(x => x.Kiralama).WithRequiredPrincipal(x => x.Araba);

        }
    }
}
