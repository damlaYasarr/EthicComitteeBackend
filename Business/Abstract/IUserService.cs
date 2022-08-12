
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


        //başvuru sayfasındaki istekler
        IResult DeleteApply(int id);//başvuru sil --başvuru detayı silinmeliS-->DONE
        IDataResult<List<ApplicationSchemaDto>> GetApplyforStudent(int user_id);//tarih-başlık-durum-karar işlem-->DONE
        
        List<PersonalInfoDto> GetUserDetails();//-->DONE user detay bilgsi

         //anasayfada çalışan servis başvuru sayısı ve onay sayısı bekleyen kişi sayısı
        public HashMap<string, int> getConfirmationCount();
        public HashMap<string, int> getApplicationCount();

        //başvuru esnasında sırayla kişi blgisi-başvuru bilgisi- dosya yükleme
        void addPersonalInfo(PersonalInfoDto personalInfo);//-->DONE
        void addApplicationInfo(ApplyInfoDto applyInfo);//-->DONE
         IResult updateFile(int file_id, IFormFile file);
         IResult addFile(int basvuru_id, int file_type, IFormFile file);
         string GetFilePath(int file_id);
        void toPdfFile(int apply_id, int pdf_type);

        //kişinin bilgisi ve detay bilgsinin güncellenmesi
        IResult updatePersonalInfo(PersonalInfoDto personalInfo); //aynı kişinin blgileri gelmeli. -->DONE
        IResult updateApplicationInfo(ApplyInfoDto applyInfo);//-->DONE


        //misafir olarak giriş yapanların geribildirimi
        string getFeedbackforGuest(int userid);//
        IResult AddFeedBackforGuest(feedbackDto f);

        //adminin yapacağı işlemler
        IDataResult<List<ApplicationInfoWithUserDto>> GetAllApplicationforAdmin();//tüm userları başvurularıyla getir getir 
        //admin başvurunun statüsünü değiştirmesi işlemi
        IResult changeProjectstatus(int user_id,int status); //admin kullanıcının başvurusnun durumunu günceller DONE
      

    }
}

