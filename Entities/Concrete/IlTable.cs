using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class IlTable
    {
        [Key]
        public int id { get; set; }
        public string il_adi { get; set; }

        public ICollection<KurumTable> KurumTable { get; set; }
    }
}
