using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ApplyTable
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User_Id")]
        public int User_Id { get; set; }
        public string Baslik { get; set; }

        public string Ozet { get; set; }
        public string Aciklama { get; set; }

        public DateTime zaman { get; set; }
        //public File Word { get; set; }


        [ForeignKey("etikkurul")]
        public int? etikkurulID { get; set; }
        [ForeignKey("calismalanı")]
        public int? calismaalaniID { get; set; }

        public virtual EtikKurul etikkurul { get; set; }
        public virtual Calisma_alani calismalanı { get; set; }
        //buranın id'leri ile classların id'leri aynı olmalı 
       
        public ICollection<Users> Users { get; set; }
    }
}
