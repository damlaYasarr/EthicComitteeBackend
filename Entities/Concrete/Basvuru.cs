using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Basvuru
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public string Baslik { get; set; }
        public string Ozet { get; set; }
        public int? Onerilen_Etik_Kurulu { get; set; }
        public int? Calisma_Alanı { get; set; }
        public string Aciklama { get; set; }
        public DateTime Zaman_Damgası { get; set; }
        public int? status { get; set; }
        public int? arastirma_niteligi_id { get; set; }
         public byte[]? basvuru_formu { get; set; }
         public byte[]? basvuru_dilekcesi { get; set; }
         public byte[]? gonullu_katilim_formu { get; set; }
         public byte[]? degerlendirme_formu { get; set; }
         public byte[]? taahhutname { get; set; }
         public byte[]? yukseklisans_doktora_basvuru { get; set; }
         public byte[]? evrak_kontrol_cizelgesi { get; set; }

    }
}
