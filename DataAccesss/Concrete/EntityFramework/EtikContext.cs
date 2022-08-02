
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concrete.EntityFramework
{
    public class EtikContext : Microsoft.EntityFrameworkCore.DbContext
    {   //alt metot proje hangi veritabanı ile ilişki olduğunu belirtir
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //connectionstring yazılır- VİEW->SQL CONNETİON-> SQL ADI YAZAR. ALT KISIMA İSİM BELİRTİLİR
            optionsBuilder.UseSqlServer("Data Source =.; Initial Catalog = otomasyonDB; Integrated Security = True");
           
            Console.WriteLine("dbbağlandı");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
           .HasOne(e => e.applytable)
           .WithMany(c => c.Users);

            modelBuilder.Entity<ApplyTable>()
           .HasOne(e => e.etikkurul)
           .WithMany(c => c.Applytable);

        }
    
        
        //veritabanındaki tabloların isimlerini alttaki metotla eşleştirmiş olduk
        public System.Data.Entity.DbSet<Users> users { get; set; }
        public System.Data.Entity.DbSet<ApplyTable> basvuru { get; set; }
        public System.Data.Entity.DbSet<Calisma_alani> calisma_alani { get; set; }
        public System.Data.Entity.DbSet<EtikKurul> etik_kurul { get; set; }
        public System.Data.Entity.DbSet<Role> unvan { get; set; }
        public System.Data.Entity.DbSet<OgrenimDurumu> ogrenim_durumu { get; set; }
        public System.Data.Entity.DbSet<Users> user_types { get; set; }
    }
}
