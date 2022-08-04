using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class StatusTable
    {
        [Key]
        public int id { get; set; }
        public string status_type { get; set; }
        public ICollection<ApplyTable> applyTable { get; set; }
    }
}
