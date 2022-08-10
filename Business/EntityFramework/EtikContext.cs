
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
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



        //veritabanındaki tabloların isimlerini alttaki metotla eşleştirmiş olduk
        public DbSet<Users> users { get; set; }
        public DbSet<Basvuru> basvuru { get; set; }
        public DbSet<Calisma_alani> calisma_alani { get; set; }
        public DbSet<EtikKurul> etik_kurul { get; set; }
        public DbSet<Unvan> unvan { get; set; }
        public DbSet<OgrenimDurumu> ogrenim_durumu { get; set; }
        public DbSet<Users> user_types { get; set; }
        public DbSet<IlTable> il_tables { get; set; }
        public DbSet<Parola> parola { get; set; }
        public DbSet<StatusTable> status_table { get; set; }
        public DbSet<KurumTable> kurum_table { get; set; }
        public DbSet<ArastirmaNiteligi> arastirma_niteligi { get; set; }
        public DbSet<Documents> documents { get; set; }
        public DbSet<Doc_Type> doc_type { get; set; }



    }
}
