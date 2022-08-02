using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class ApplyInfo
    {
        public int Id { get; set; }
        [ForeignKey("User_Id")]
        public int User_Id { get; set; }
        public string Baslik { get; set; }

        public string Ozet { get; set; }
        public string Aciklama { get; set; }
    }
}
