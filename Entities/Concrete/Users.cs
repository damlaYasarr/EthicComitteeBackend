using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Users : IEntity
    {
        [Key]
        public int Id { get; set; }
        
        public int? User_Type { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int? Unvan { get; set; }
        public int? Ogrenim_Durumu { get; set; }
        public int? Kurumu { get; set; }
        public string Uzmanlık_Alani { get; set; }
        // public DateTime Dogum_Tarihi { get; set; }
        public string Tckn { get; set; }
        public string Eposta { get; set; }
        public int? Parola_id { get; set; }
    }
}
