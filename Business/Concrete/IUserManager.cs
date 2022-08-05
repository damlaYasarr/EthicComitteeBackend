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
using Core.Utilities.Result;
using Business.Constants;

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
                   // Parola_id = personalInfo.parola,
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

       
        //it is DONE!
        public IDataResult<List<ApplicationSchemaDto>> GetApplyforStudent(int user_id)
        {
            //tarih-başlık-status 
            using(EtikContext context = new EtikContext())
            {
                var user = context.basvuru.SingleOrDefault(b => b.User_Id == user_id);
          
                if(user == null)
                {
                    return new ErrorDataResult<List<ApplicationSchemaDto>>("kullanıcı yok");
                }
                else
                {
                    var result = from r in context.basvuru
                                 join x in context.users on user_id equals x.Id
                                 join u in context.status_table on r.status equals u.id into ux
                                 from u in ux.DefaultIfEmpty()
                                 where r.Id == user_id
                                 select new ApplicationSchemaDto
                                 {
                                     id = r.Id,
                                     user_id = r.User_Id,
                                     Created = r.Zaman_Damgası,
                                     status = u.id,
                                     baslik = r.Baslik
                                 };
                    return new SuccessDataResult<List<ApplicationSchemaDto>>(result.ToList()); 
                }
                
            }
           

        }

        public int getConfirmationCount()
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
                                 Kurumu = p.Kurumu //başka tablodan çekerken id'lerden birleştirriz
                             };

                return result.ToList();

            }

        }

      

        public void updateFile(Users users)
        {
            throw new NotImplementedException();
        }

       public  IResult getFile(Users user)
        {
            throw new NotImplementedException();
        }
        //it is done!!
        public IResult updatePersonalInfo(PersonalInfoDto personalInfo)
        {
            using (EtikContext context = new EtikContext())
            {

                var user = context.users.SingleOrDefault(b=>b.Id==personalInfo.Id);
                if (user == null)
                {
                   return  new ErrorResult("Güncellenecek kayıt bulunamadı");
                }
                else
                {
                    user.Ad = personalInfo.Ad;
                    user.Kurumu=personalInfo.Kurumu;
                    user.Soyad = personalInfo.Soyad;
                    user.Unvan = personalInfo.Unvan_id;
                    user.Uzmanlık_Alani = personalInfo.Uzmanlık_Alani;
                    user.Kurumu = personalInfo.Kurumu;
                    user.Tckn = personalInfo.Tckn;
                    user.Eposta = personalInfo.Eposta;
                    user.Parola_id = personalInfo.parola;
   
                 }
                
                context.SaveChanges();
                return new SuccessResult(Messages.PersonalUpdatedInfo);
            }
        }
        // it is DONE!
        public IResult updateApplicationInfo(ApplyInfoDto applyInfo)
        {
            using (EtikContext context = new EtikContext())
            {

                var applyDetail = context.basvuru.SingleOrDefault(b => b.Id == applyInfo.id);
                if (applyDetail == null)
                {
                    return new ErrorResult(Messages.ApplyErrorUpdatedInfo);
                }
                else
                {
                    applyDetail.Id=applyInfo.id;
                    applyDetail.User_Id = applyInfo.user_id;
                    applyDetail.Onerilen_Etik_Kurulu = applyInfo.Etik_Kurul_Id;
                    applyDetail.Baslik = applyInfo.Baslik;
                    applyDetail.Ozet = applyInfo.Ozet;
                    applyDetail.Aciklama = applyInfo.Aciklama;
                    applyDetail.arastirma_niteligi_id = applyInfo.arastirma_niteligi_id;
                }
                context.SaveChanges();
                return new SuccessResult(Messages.ApplyUpdatedInfo);
            }
        }
    }
}
