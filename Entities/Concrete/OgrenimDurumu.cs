using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class OgrenimDurumu
    {
        [Key]
        public int Id { get; set; }
        public string Type_name { get; set; }
        public ICollection<Users> Users { get; set; }
    }
}
