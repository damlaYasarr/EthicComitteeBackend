using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesss.Abstract
{
    public interface IUserDal
    {
        List<PersonalInfo> GetUserDetailDtos();
        List<Users> GetClaims(Users user);
        void add(Users user);
        void update(Users user);
        void delete(Users user);
        //void add(ApplyInfo applyInfo);

    }
}
