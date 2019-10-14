using RentACar.DATA;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;  
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DAL
{
    public class MusteriMapping : EntityTypeConfiguration<Musteri>
    {
        public MusteriMapping()
        {
            ToTable("Musteriler");
            HasKey(x => x.UyeID);
            Property(x => x.TcKimlikNo).HasColumnType("char").HasMaxLength(11).IsRequired();
            Property(x => x.Ad).HasMaxLength(20).IsRequired();
            Property(x => x.Soyad).HasMaxLength(20).IsRequired();
            Property(x => x.DogumTarihi).HasColumnType("datetime2");
            Property(x => x.Memleket).HasMaxLength(20).IsRequired();
            Property(x => x.NufusResim).HasColumnType("image").IsRequired();



        }
    }
}
