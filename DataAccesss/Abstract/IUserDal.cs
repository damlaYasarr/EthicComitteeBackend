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
        void add(PersonalInfo user);
        void add(ApplyInfo applyinfo);
        void update(PersonalInfo user);
        void delete(PersonalInfo user);
        List<PersonalInfo> getPersonalInfo();
        void add(Users user);
        void add(ApplyTable applyTable);    
        //void add(ApplyInfo applyInfo);

    }
}
