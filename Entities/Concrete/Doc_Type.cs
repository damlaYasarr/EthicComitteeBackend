using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Doc_Type
    {
        [Key]
        public int id { get; set; }
        public string doc_type_name { get; set; }
    }
}
