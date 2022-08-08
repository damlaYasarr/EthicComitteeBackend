using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class ApplicationInfoWithUserDto
    {
        public int id { get; set; }
        public int basvuru_id { get; set; }
        public string baslik { get; set; }
        public DateTime created { get; set; }   
        public int status_id { get; set; }



    }
}
