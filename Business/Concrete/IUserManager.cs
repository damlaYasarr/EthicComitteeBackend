using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Core.Concrete.EntityFramework;

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

        public void addApplicationInfo(ApplyInfoDto applyInfo)
        {//it is DONE!
            using (EtikContext context = new EtikContext())
            {   //get the info from resource 

                Basvuru bsr = new Basvuru()
                {
                    Id = applyInfo.id,
                    User_Id = applyInfo.user_id,
                    Onerilen_Etik_Kurulu=applyInfo.Etik_Kurul_Id,
                    Baslik = applyInfo.Baslik,
                    Ozet = applyInfo.Ozet,
                    Aciklama = applyInfo.Aciklama,
                    arastirma_niteligi_id = applyInfo.arastirma_niteligi_id
                    

                };
                context.basvuru.Add(bsr);

                context.SaveChanges();
            }   
            
        }


        public void addFile(Users user)
        {
            throw new NotImplementedException();
        }

        public void addPersonalInfo(PersonalInfoDto personalInfo)
        { //it is DONE!
            using (EtikContext context = new EtikContext())
            {   //get the info from resource 
                Users user = new Users()
                {
                    Id  =  personalInfo.Id,
                    Ad = personalInfo.Ad,
                    Soyad = personalInfo.Soyad,
                    Unvan = personalInfo.Unvan_id,
                    Uzmanlık_Alani=personalInfo.Uzmanlık_Alani,
                    Tckn = personalInfo.Tckn,
                    Eposta = personalInfo.Eposta,
                    Parola_id = personalInfo.parola,
                    Kurumu = personalInfo.Kurumu
                };
                context.users.Add(user);
                context.SaveChanges();
            }
          
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

        public List<Basvuru> GetApply(int id)
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

        public void getFile(Users user)
        {
            throw new NotImplementedException();
        }

        //is it DONE!
        public List<PersonalInfoDto> GetUserDetails()
        {
            using (EtikContext context = new EtikContext())
            {
                var result = from p in context.users
                             join u in context.unvan on p.Unvan equals u.id into ux
                             from u in ux.DefaultIfEmpty()
                             select new PersonalInfoDto
                             {
                                 Id = p.Id,
                                 Ad = p.Ad,
                                 Soyad = p.Soyad,
                                 Unvan_id = u.id,
                                 //uzmanlık alanı olmalı
                                 Kurumu = (int)p.Kurumu //başka tablodan çekerken id'lerden birleştirriz
                             };

                return result.ToList();

            }

        }

        public void updateApplicationInfo(Users users)
        {
            throw new NotImplementedException();
        }

      

        public void updatePersonalInfo(Users users)
        {
            throw new NotImplementedException();
        }

        public void updateFile(Users users)
        {
            throw new NotImplementedException();
        }
    }
}
