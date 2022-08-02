using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {  //en mük. constructr kullanımı
        //this const.kendisi demek
        public Result(bool v1, string v2) : this(v1)
        {

            Message = v2;
        }
        public Result(bool v1)
        {
            Success = v1;
        }
        public bool Success { get; }

        public string Message { get; }

    }
}
