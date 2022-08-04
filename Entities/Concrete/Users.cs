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
        public string Uzmanlık_Alani { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string Tckn { get; set; }
        public string Eposta { get; set; }
      
      
        public int User_id { get; set; }//başvuru tablosuna bağlı
       
        public int Unvan { get; set; }//unvan tablosu
       
        public int Kurumu { get; set; }//kurum tablosu
      
        public int Ogrenim_Durumu { get;set; }//ogrenim durumu tablosu
       
        public int Parola_id { get; set; }//parola tablosu
      
        public int User_Type { get; set; }//user type tablosuna bağlı


        //çekilen yerde obje olarak açılacak
        public  user_types usertype { get; set; }
       
        public  Unvan Unvans { get; set; }
        
        public  ApplyTable applytable { get; set; }
       
        public  OgrenimDurumu ogrenimdurumu { get; set; }
        public  KurumTable kurumtable { get; set; }
        public  Parola parola { get; set; }
    }
}
