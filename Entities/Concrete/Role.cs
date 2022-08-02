using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Role
    {//user types olarak yer alır
        [Key]
        public int id { get; set; }

        public string type_name { get; set; }

        public ICollection<Users> users { get; set; }

    }
}
