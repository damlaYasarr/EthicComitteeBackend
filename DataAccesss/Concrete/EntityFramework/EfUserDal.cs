
using DataAccesss.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concrete.EntityFramework
{
    public class EfUserDal :IUserDal
    {
        public void add(Users user)
        {
            throw new NotImplementedException();
        }

        public void Delete(Users user)
        {
            using (EtikContext context = new EtikContext())
            {   //get the info from resource 
                var deletedEntity = context.Entry(user);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void delete(Users user)
        {
            throw new NotImplementedException();
        }

        public Users Get(Expression<Func<Users, bool>> filter = null)
        {
            using (EtikContext context = new EtikContext())
            {   //if not null convert to list
                //emaili db'den aratmamız gerekir
                return context.Set<Users>().SingleOrDefault(filter);
            }
        }



        public List<Users> GetAll(Expression<Func<Users, bool>> filter = null)
        {
            using (EtikContext context = new EtikContext())
            {   //if not null convert to list
                return filter == null
                    ? context.Set<Users>().ToList()
                    : context.Set<Users>().Where(filter).ToList();
            }

        }

        public List<Users> GetClaims(Users user)
        {
            throw new NotImplementedException();
        }

        public List<PersonalInfo> GetUserDetailDtos()
        {
            throw new NotImplementedException();
        }

        public void Login(Users user)
        {
            throw new NotImplementedException();
        }

        public void Register(Users user)
        {//IDısposable pattern implementation of c# for research "using"
            using (EtikContext context = new EtikContext())
            {   //get the info from resource 
                var addedEntity = context.Entry(user);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }


        public void Update(Users user)
        {
            using (EtikContext context = new EtikContext())
            {   //get the info from resource 
                var updatedEntity = context.Entry(user);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void update(Users user)
        {
            throw new NotImplementedException();
        }
    }
}