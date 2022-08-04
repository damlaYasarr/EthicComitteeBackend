using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Parola
    {
        [Key]
        public int id { get; set; }
        public string? parola { get; set; }
        public ICollection<Users> Users { get; set; }
    }
}
