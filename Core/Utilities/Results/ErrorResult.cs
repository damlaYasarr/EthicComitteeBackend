using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    // :Result ifadesi javada extends
    public class ErrorResult : Result
    {

        public ErrorResult(string msg) : base(true, msg)
        {

        }
        public ErrorResult() : base(true)
        {
            //parametre vermek istemedik
        }


    }
}
