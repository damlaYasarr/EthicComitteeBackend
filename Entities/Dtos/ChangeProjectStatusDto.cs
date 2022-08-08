using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class ChangeProjectStatusDto
    {
        public int id { get; set; }//basvuru tablonun id'si
        public int user_id { get; set; }//başvuran kişinin id's
        public int status_id { get; set; }//status id
        
    }
}
