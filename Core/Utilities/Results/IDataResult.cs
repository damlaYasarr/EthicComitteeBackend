using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    //List<User> kullanırken bu yapıyı çağırırz
    public interface IDataResult<T> : IResult
    {
        T Data { get; }

    }
}
