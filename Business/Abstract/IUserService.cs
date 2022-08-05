
using Core.Utilities.Result;
using Entities.Concrete;
using Entities.Dtos;
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
        Users controlToken(Users user);  

        //anasayfada çalışacak servis 
        int getConfirmationCount(); //onaylanma sayısı
        int getApplicationCount();//başvuru sayısı


        //başvuru sayfasındaki istekler
        void DeleteApply(Users user);//başvuru sil
        IDataResult<List<ApplicationSchemaDto>> GetApplyforStudent(int user_id);//tarih-başlık-durum-karar işlem-->DONE
        
        List<PersonalInfoDto> GetUserDetails();//-->DONE


        void addPersonalInfo(PersonalInfoDto personalInfo);//-->DONE
        void addApplicationInfo(ApplyInfoDto applyInfo);//-->DONE
        void addFile(Users user);//7 tane word dosyası eklenir sırayla-- bu
        IResult getFile(Users user);//bu işlemde 7 word dosyası bir pdf'e dönüşür.
       
        IResult updatePersonalInfo(PersonalInfoDto personalInfo); //aynı kişinin blgileri gelmeli. -->DONE
        IResult updateApplicationInfo(ApplyInfoDto applyInfo);//-->DONE
        void updateFile(Users users);


        //adminin yapacağı işlemler
        List<Users> GetAll(Expression<Func<Users, bool>> filter = null);//tüm userları başvurularıyla getir getir 
        void changeProjectstatus(Users user); //admin kullanıcının başvurusnun durumunu günceller
        //List<Basvuru> GetApply(int id); //tm başvuruları getir-admin için--USER'IN BAŞVURULARINI GETİR

    }
}
