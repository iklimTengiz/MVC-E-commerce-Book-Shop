using ModaKitap.Model.Core.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModaKitap.Model.Core
{
    public class ModaKitapDB : DbContext
    {
         public ModaKitapDB()
             : base(@"Data Source=DESKTOP-9R6DSE4\SQLEXPRESS;initial catalog=ModaKitapDB;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;")
          {


          }


        /*
       public ModaKitapDB()
      : base(@"Data Source=LAPTOP-B40RT1JO\SQLEXPRESS2012;initial catalog=ModaKitapDB; Integrated Security=true;MultipleActiveResultSets=True;App=EntityFramework")
       {


       } */
        public DbSet<User> Users { get; set; }
        public DbSet<UserAdres> UserAdress { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }
        public DbSet<Kitaplar> Kitaplars { get; set; }
        public DbSet<YayınEvi> YayınEvis { get; set; }
        public DbSet<Yazar> Yazars { get; set; }
        public DbSet<Durum> Durums { get; set; }
        public DbSet<Sepet> Sepets { get; set; }
        public DbSet<Siparis> Siparis { get; set; }
        public DbSet<SiparisDetay> SiparisDetay { get; set; }
        public DbSet<OdemeSecenekleri> OdemeSecenekleris { get; set; }
        public DbSet<Form>Forms { get; set; }
        public DbSet<Bulten> Bultens { get; set; }
        public DbSet<Begeni> Begenis { get; set; }
        public DbSet<KargoKimin> KargoKimins { get; set; }
        public DbSet<Kondisyon> Kondisyons { get; set; }
        public DbSet<CiltDurumu> CiltDurumus { get; set; }
       



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder); 
        }
    }
}
