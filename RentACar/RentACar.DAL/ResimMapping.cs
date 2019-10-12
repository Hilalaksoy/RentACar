using RentACar.DATA;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DAL
{
    public class ResimMapping : EntityTypeConfiguration<Resim>
    {
        public ResimMapping()
        {
            ToTable("Resimler");
            HasKey(x => x.ResimID);
            Property(x => x.Fotograf).HasColumnType("image").IsRequired();

            HasRequired(x => x.Araba).WithMany(x => x.Resimler).HasForeignKey(x => x.ID);
        }
    }
}
