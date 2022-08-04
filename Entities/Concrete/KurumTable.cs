using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class KurumTable
    {
        [Key]
        public int id { get; set; }
        public string kurum_adi { get; set; }
        public int il_id { get; set; }
       

    }
}
