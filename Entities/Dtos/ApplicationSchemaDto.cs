using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class ApplicationSchemaDto
    {
        public int id { get; set; }
        public int user_id { get; set; }//kimin başvurusu bu?
       // public DateTime Created { get; set; }
        public int status { get; set; } 
        public string baslik { get; set; }  
    }
}
