﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Unvan
    {//user types olarak yer alır
        [Key]
        public int id { get; set; }

        public string unvan_adi { get; set; }

    }
}
