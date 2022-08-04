using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ApplyTable
    {
        [Key]
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Ozet { get; set; }
        public string Aciklama { get; set; }
        public DateTime Zaman_Damgası { get; set; }
        //public File Word { get; set; }
       
        public byte[] basvuru_formu { get; set; }
        public byte[] basvuru_dilekcesi { get; set; }
        public byte[] gonullu_katilim_formu { get; set; }
        public byte[] degerlendirme_formu { get; set; }
        public byte[] taahhütname { get; set; }
        public byte[] yukseklisand_doktora_basvuru { get; set; }
        public byte[] evrak_kontrol_cizelgesi { get; set; }


        public int User_Id { get; set; } //basvuru tablosu 
        public int Onerilen_Etik_Kurulu { get; set; } //etik kurulu tablosu
        public int status { get; set; }//status tablosu
        public int Calisma_Alanı { get; set; } //calisma alanı

        public StatusTable statustable { get; set; }
      
        public EtikKurul Etikkuruls { get; set; }
      
        public  Calisma_alani calismalanı { get; set; }
       
       
        public ICollection<Users> Users { get; set; }
    }
}
