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
        //public DateTime Zaman_Damgası { get; set; }
        public int? status { get; set; }
        public int? arastirma_niteligi { get; set; }
        

    }
}
