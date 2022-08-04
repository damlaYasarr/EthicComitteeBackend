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
using DataAccesss.Abstract;

namespace Business.Concrete
{
    public class IUserManager : IUserService
    {
        IUserDal _IUserdal;
        public IUserManager(IUserDal IUserdal)
        {
            _IUserdal = IUserdal;
        }



        public void addApplicationInfo(ApplyInfo applyInfo)
        {
           
            ApplyTable applyInfo1= new ApplyTable()  
              {
                  Id = applyInfo.id,
                  Etikkuruls = new EtikKurul() { Id = applyInfo.Etik_Kurul_Id },
                  Baslik = applyInfo.Baslik,
                  Ozet = applyInfo.Ozet,
                  Aciklama = applyInfo.Aciklama
              };

                _IUserdal.add(applyInfo1);
            
            
        }

        public void addFile(Users user)
        {
            throw new NotImplementedException();
        }

        public void addPersonalInfo(PersonalInfo personalInfo)
        {
            Users user = new Users()
            {
                Ad = personalInfo.Ad,
                Soyad = personalInfo.Soyad,
                Unvan=personalInfo.Unvan_id, //BAŞKA TABLODAN ÇEKERKEN İDD'LERDEN BİRLEŞTİRDİK
                Uzmanlık_Alani = personalInfo.Uzmanlık_Alani,
                Kurumu = personalInfo.Kurumu
            };
            _IUserdal.add(user);
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

        public void getFile(Users user)
        {
            throw new NotImplementedException();
        }

        //burası çalışan metot
        public List<PersonalInfo> GetUserDetails()
        {
            return _IUserdal.GetUserDetailDtos();

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
