
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Documents
    {
        [Key]
        public int id { get; set; }
        public int doc_type { get; set; }
        public string doc_path { get; set; }
        public int basvuru_id { get; set; }
    }
}
