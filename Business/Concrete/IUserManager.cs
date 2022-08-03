using Business.Abstract;

using Core.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EntityState = System.Data.Entity.EntityState;

namespace Business.Concrete
{
    public class IUserManager : IUserService
    {
        public void addApplicationInfo(Users user)
        {
            throw new NotImplementedException();
        }

        public void addFile(Users user)
        {
            throw new NotImplementedException();
        }

        public void addPersonalInfo(PersonalInfo personalInfo)
        {
            throw new NotImplementedException();
        }

        public void changeProjectstatus(Users user)
        {
            throw new NotImplementedException();
        }

        public Users controlToken(Users user)
        {
            throw new NotImplementedException();
        }

        public void DeleteApply(Users user)
        {
            throw new NotImplementedException();
        }

        public List<Users> GetAll(Expression<Func<Users, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public int getApplicationCount()
        {
            throw new NotImplementedException();
        }

        public List<ApplyTable> GetApply(int id)
        {
            throw new NotImplementedException();
        }

        public List<Users> GetApplyforStudent()
        {
            throw new NotImplementedException();
        }

        public int getConfirmationCount()
        {
            throw new NotImplementedException();
        }

        public void updateApplicationInfo(Users users)
        {
            throw new NotImplementedException();
        }

        public void updateFile(Users users)
        {
            throw new NotImplementedException();
        }

        public void updatePersonalInfo(Users users)
        {
            throw new NotImplementedException();
        }
    }
}
