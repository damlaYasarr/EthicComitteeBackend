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
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Unvan { get; set; }
        public string UzmanlıkAlanı { get; set; }
        public string Kurumu { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string Tckn { get; set; }
        public string Eposta { get; set; }
        public string parola { get; set; }
        [ForeignKey("applytable")]
        public int? applytableId { get; set; }
        [ForeignKey("role")]
        public int? roleid { get; set; }
        [ForeignKey("ogrenimdurumu")]
        public int? ogrenimdurum { get;set; }
        [JsonIgnore]
        public virtual Role role { get; set; }
        [JsonIgnore]
        public virtual ApplyTable applytable { get; set; }
        [JsonIgnore]
        public virtual OgrenimDurumu ogrenimdurumu { get; set; }
    }
}
