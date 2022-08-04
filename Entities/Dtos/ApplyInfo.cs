using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class ApplyInfo
    {
        public int id { get; set; }
        public int Etik_Kurul_Id { get; set; }//başvurulack etik kurul
        public string Baslik { get; set; }//applytable
       // public string ArastirmaNteligi { get; set; } -> Araştırma niteliği tablosu olması lazım
        public string Ozet { get; set; }//applytable
        public string Aciklama { get; set; }//applytable
    }
}
