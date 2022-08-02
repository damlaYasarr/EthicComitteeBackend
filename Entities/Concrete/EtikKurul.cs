using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class EtikKurul
    {
        [Key]
        public int Id { get; set; }
        public string Etik_Kurul_Adi { get; set; }
        public ICollection<ApplyTable> Applytable { get; set; }
    }
}
