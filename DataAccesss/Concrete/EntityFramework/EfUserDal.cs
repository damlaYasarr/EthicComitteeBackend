
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
    public class EfUserDal : IUserDal
    {
        public void add(PersonalInfo personalInfo)
        {
            using (EtikContext context = new EtikContext())
            {   //get the info from resource 
                var addEntitiy = context.Entry(personalInfo);
                addEntitiy.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void add(Users user)
        {
            using (EtikContext context = new EtikContext())
            {   //get the info from resource 
                var addEntitiy = context.Entry(user);
                addEntitiy.State = EntityState.Added;
                context.SaveChanges();
            }
        }

       

        public void add(ApplyTable applyTable)
        {
            using (EtikContext context = new EtikContext())
            {
                //db den include gibi bir bilgi eklenecek sanırım 

                var result = context.basvuru.Include(x => x.Id).Include(y => y.Etikkuruls.Id)
                    .Select new ApplyTable
                {

                }
                
            }
        }

        public void add(ApplyInfo applyinfo)
        {
            throw new NotImplementedException();
        }

        public void delete(PersonalInfo user)
        {
            using (EtikContext context = new EtikContext())
            {   //get the info from resource 
                var deletedEntity = context.Entry(user);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
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

        public List<PersonalInfo> getPersonalInfo()
        {
            throw new NotImplementedException();
        }
        //burası çalışan metot
        public List<PersonalInfo> GetUserDetailDtos()
        {
            using (EtikContext context = new EtikContext())
            {
                var result = from p in context.users
                                 //join u in context.unvan on p.Unvan equals u.id into ux
                                 //from u in ux.DefaultIfEmpty()
                             select new PersonalInfo
                             {
                                 Id = p.Id,
                                 Ad = p.Ad,
                                 Soyad = p.Soyad,
                                 //Unvan = u.Unvan,
                                 Uzmanlık_Alani = p.Uzmanlık_Alani,
                                 Kurumu=p.Kurumu //başka tablodan çekerken id'lerden birleştirriz
                             };

                return result.ToList();

            }

        }






        public void update(PersonalInfo user)
        {
            using (EtikContext context = new EtikContext())
            {   //get the info from resource 
                var updatedEntity = context.Entry(user);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}