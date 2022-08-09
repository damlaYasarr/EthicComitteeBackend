
using Core.Utilities.Result;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        //giriş sayfası servisleri
      
       //sadece user tokenini kontrol et 
        //Users controlToken(Users user);  

        //anasayfada çalışacak servis 
        //int getConfirmationCount(); //onaylanma sayısı
        //int getApplicationCount();//başvuru sayısı


        //başvuru sayfasındaki istekler
        IResult DeleteApply(int id);//başvuru sil --başvuru detayı silinmeliS-->DONE
        IDataResult<List<ApplicationSchemaDto>> GetApplyforStudent(int user_id);//tarih-başlık-durum-karar işlem-->DONE
        
        List<PersonalInfoDto> GetUserDetails();//-->DONE


        void addPersonalInfo(PersonalInfoDto personalInfo);//-->DONE
        void addApplicationInfo(ApplyInfoDto applyInfo);//-->DONE

        IResult updateFile(Entities.Concrete.Documents document, IFormFile file);
        public IResult addFile(Entities.Concrete.Documents document, IFormFile file);

        IResult updatePersonalInfo(PersonalInfoDto personalInfo); //aynı kişinin blgileri gelmeli. -->DONE
        IResult updateApplicationInfo(ApplyInfoDto applyInfo);//-->DONE

        IResult getFeedbackforGuest(Users u);
        IResult AddFeedBackforGuest(Users u);

        //adminin yapacağı işlemler
        IDataResult<List<ApplicationInfoWithUserDto>> GetAllApplicationforAdmin();//tüm userları başvurularıyla getir getir 
        //admin baslık-durumu güncelle-tarih. 

        IResult changeProjectstatus(int user_id,int status); //admin kullanıcının başvurusnun durumunu günceller DONE
      

    }
}

