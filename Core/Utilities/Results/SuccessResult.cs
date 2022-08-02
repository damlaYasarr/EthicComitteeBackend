using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult(string msg) : base(true, msg)
        {

        }
        public SuccessResult() : base(true)
        {
            //parametre vermek istemedik
        }

    }
}
