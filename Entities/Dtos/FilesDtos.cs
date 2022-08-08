using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class FilesDtos
    { //id-userid-files-
        public int id { get; set; }
        public int user_id { get; set; }

        public List<IFormFile> doc { get; set; }

    }
}
