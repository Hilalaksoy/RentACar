using RentACar.DATA;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DAL
{
    public class Context:DbContext
    {
        public Context()
        {
            Database.Connection.ConnectionString = "server = . ; database = RentACarDb; uid = sa ; pwd = 123";

        }
        public DbSet<Uye> Uyeler { get; set; }
        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<Araba> Arabalar { get; set; }
        public DbSet<Kiralama> Kiralamalar { get; set; }
        public DbSet<Resim> Resimler { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UyeMapping());
            modelBuilder.Configurations.Add(new MusteriMapping());
            modelBuilder.Configurations.Add(new ArabaMapping());
            modelBuilder.Configurations.Add(new KiralamaMapping());
            modelBuilder.Configurations.Add(new ResimMapping());


            base.OnModelCreating(modelBuilder);
        }
    }
}
