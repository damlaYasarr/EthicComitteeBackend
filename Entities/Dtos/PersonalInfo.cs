using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class PersonalInfo
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Unvan { get; set; }
        public string Uzmanlık_Alani { get; set; }
        public string Kurumu { get; set; }
        //public DateTime DogumTarihi { get; set; }
        //public string Tckn { get; set; }
        //public string Eposta { get; set; }
        //public string parola { get; set; }
    }
}
