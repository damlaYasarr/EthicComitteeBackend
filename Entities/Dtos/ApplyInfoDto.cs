using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class ApplyInfoDto
    {   
        public int id { get; set; }
        public int user_id { get; set; }//user id de eklenmel
        public int Etik_Kurul_Id { get; set; }//başvurulack etik kurul
        public string Baslik { get; set; }//applytable
       public string Uzmanlık_alani { get; set; }
        public string Ozet { get; set; }//applytable
        public string Aciklama { get; set; }//applytable
        public int arastirma_niteligi_id { get; set; }
    }
}
