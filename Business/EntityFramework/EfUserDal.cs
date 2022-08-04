
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
    public class EfUserDal
    {
      

        public void add(Users user)
        {
            using (EtikContext context = new EtikContext())
            {   //get the info from resource 
               
                context.SaveChanges();
            }
        }
      



        public void add(ApplyInfoDto b)
        {//veritabanında görünmüyo
          
           
                using (EtikContext context = new EtikContext())
                {   //get the info from resource 

                Basvuru bsr = new Basvuru()
                {
                    Id = b.id,
                    User_Id = b.user_id,
                    Baslik=b.Baslik,
                    Ozet=b.Ozet,
                    Aciklama=b.Aciklama
                    
                    
                };
                    context.basvuru.Add(bsr);
                  
                    context.SaveChanges();
                }
              
                
            
        }

        public void add(PersonalInfoDto user)
        {
            throw new NotImplementedException();
        }

       

        public void delete(PersonalInfoDto user)
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

        public List<PersonalInfoDto> getPersonalInfo()
        {
            throw new NotImplementedException();
        }


     






        public void update(PersonalInfoDto user)
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