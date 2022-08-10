
using Core.Utilities.Result;
using Entities.Concrete;
using Entities.Dtos;
using Lucene.Net.Support;
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

        public HashMap<string, int> getConfirmationCount();
        public HashMap<string, int> getApplicationCount();

        void addPersonalInfo(PersonalInfoDto personalInfo);//-->DONE
        void addApplicationInfo(ApplyInfoDto applyInfo);//-->DONE

        public IResult updateFile(int file_id, IFormFile file);
        public IResult addFile(int basvuru_id, int file_type, IFormFile file);

        IResult updatePersonalInfo(PersonalInfoDto personalInfo); //aynı kişinin blgileri gelmeli. -->DONE
        IResult updateApplicationInfo(ApplyInfoDto applyInfo);//-->DONE

        string getFeedbackforGuest(int userid);//
        IResult AddFeedBackforGuest(feedbackDto f);

        //adminin yapacağı işlemler
        IDataResult<List<ApplicationInfoWithUserDto>> GetAllApplicationforAdmin();//tüm userları başvurularıyla getir getir 
        //admin baslık-durumu güncelle-tarih. 

        IResult changeProjectstatus(int user_id,int status); //admin kullanıcının başvurusnun durumunu günceller DONE
      

    }
}

