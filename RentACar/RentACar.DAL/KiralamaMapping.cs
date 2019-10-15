using RentACar.DATA;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DAL
{
    public class KiralamaMapping : EntityTypeConfiguration<Kiralama>
    {
        public KiralamaMapping()
        {
            ToTable("KiralamaBilgileri");
            HasKey(x => x.ID);
            Property(x => x.Fiyat).HasColumnType("money");
            Property(x => x.Indirim).IsRequired();

            HasRequired(x => x.Musteri).WithMany(x => x.Kiralamalar).HasForeignKey(x => x.MusteriID);

        }
    }
}
