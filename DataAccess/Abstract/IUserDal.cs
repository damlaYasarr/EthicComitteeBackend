using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserDal
    {
        List<Users> GetAll(Expression<Func<Users, bool>> filter = null);
        Users Get(Expression<Func<Users, bool>> filter = null);
        void Register(Users user);
        void Update(Users user);
        void Login(Users user);
        void Delete(Users user);
        List<Users> GetUserById(int user);
        List<Users> GetEmail(string email);
    }
}
