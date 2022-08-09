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
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using Microsoft.Office.Interop.Word;

using System.IO;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class IUserManager : IUserService
    {
        //it is DONE!
        public void addApplicationInfo(ApplyInfoDto applyInfo)
        {
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
        //it is Done!!
        public IResult changeProjectstatus(int user_id, int status)
        {
            using(EtikContext context=new EtikContext())
            {
                var result = context.basvuru.SingleOrDefault(b => b.User_Id == user_id);
                if(result == null)
                {
                    return new ErrorResult("kullanıcı başvurusu bulunamadı");
                }
                else
                {
                    var xx = from r in context.basvuru
                             join x in context.users on user_id equals x.Id
                             join u in context.status_table on r.status equals u.id into ux
                             from u in ux.DefaultIfEmpty()
                             where r.Id == user_id
                             select new ChangeProjectStatusDto
                             {
                                 id = r.Id,
                                 user_id=x.Id,
                                 status_id=u.id
                             };
                    context.SaveChanges();
                }

            }
            return new SuccessResult("hey başarılı");
        }

       
        //it is Done!
        public IResult DeleteApply(int id)
        {
            using (EtikContext context = new EtikContext())
            {
                var applydetail = context.basvuru.SingleOrDefault(b => b.Id == id);
                if(applydetail == null)
                {
                    return new ErrorResult(Messages.NotFound);
                }
                else
                {
                    context.basvuru.Remove(applydetail);
                    context.SaveChanges();
                }
               
                return new SuccessResult("silinme başarılı");
            }
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

        public IResult addFile(Entities.Concrete.Documents document, IFormFile file)
        {
            using (EtikContext context = new EtikContext())
            {   //get the info from resource 

                var errors = new List<string>();
                if (file == null || file.Length == 0)
                {
                    return new ErrorResult("Dosya boş yüklenemez.");
                }

                var extension = Path.GetExtension(file.FileName).Trim('.').ToLower();
                if (!(new[] { "doc", "docx" }.Contains(extension)))
                {
                    return new ErrorResult("Dosya formatı hatalı.");
                }

                string document_path;
                do
                {
                    //a random path is given
                    string local_document_dir = @"C:\Users\Lenovo\Desktop\deneme";
                    string randFileName = Path.GetRandomFileName();

                    //give right extension format
                    string filepath = Path.ChangeExtension(randFileName, Path.GetExtension(file.FileName));
                    document_path = local_document_dir + @"\" + filepath;
                } while (File.Exists(document_path));

                //iffilepathexist get another path

                //createing the file
                Stream fileStream = new FileStream(document_path, FileMode.Create);
                file.CopyTo(fileStream); ;

                //document.doc_type = doc_type
                document.doc_path = document_path;

                Entities.Concrete.Documents doc = new Entities.Concrete.Documents()
                {
                    basvuru_id = document.basvuru_id,
                    doc_type = document.doc_type,
                    doc_path = document.doc_path

                };
                context.documents.Add(doc);
                context.SaveChanges();

                return new SuccessResult("Dosya başarı ile yüklendi.");
            }
        }

        public IResult updateFile(Entities.Concrete.Documents document, IFormFile file)
        {
            //sadece path güncelleniyor.
            using (EtikContext context = new EtikContext())
            {

                var errors = new List<string>();
                if (file == null || file.Length == 0)
                {
                    //hata ver
                }

                var extension = Path.GetExtension(file.FileName).Trim('.').ToLower();
                if (!(new[] { "doc", "docx" }.Contains(extension)))
                {
                    //hata ver
                }

                string document_path;
                do
                {
                    //a random path is given
                    string local_document_dir = @"C:\Users\Lenovo\Desktop\deneme";
                    string randFileName = Path.GetRandomFileName();

                    //give right extension format
                    string filepath = Path.ChangeExtension(randFileName, Path.GetExtension(file.FileName));
                    document_path = local_document_dir + @"\" + filepath;
                } while (File.Exists(document_path));

                //iffilepathexist get another path



                Stream fileStream = new FileStream(document_path, FileMode.Create);
                file.CopyTo(fileStream); ;

                document.doc_path = document_path;


                var doc = context.documents.SingleOrDefault(b => b.id == document.id);

                //önceki dosyayı sil (İkinci seferde hata veriyor?)
                File.Delete(doc.doc_path);

                if (doc == null)
                {
                    return new ErrorResult("Güncellenecek dosya bulunamadı.");
                }
                else
                {

                    doc.doc_path = document.doc_path;

                }

                context.SaveChanges();
                return new SuccessResult("Dosya başarı ile güncellendi.");
            }
        }


        public static void CopyPages(PdfDocument from, PdfDocument to)
        {
            for (int i = 0; i < from.PageCount; i++)
            {
                to.AddPage(from.Pages[i]);
            }
        }
        public IDataResult<List<ApplicationInfoWithUserDto>> GetAllApplicationforAdmin()
        {
            //başlık-status-tarih
            //
            using(EtikContext context =new EtikContext())
            {
                 
               
                    var result = from r in context.basvuru
                                 join a in context.status_table on r.status equals a.id into ux
                                 from a in ux.DefaultIfEmpty()
                                
                                 select new ApplicationInfoWithUserDto
                                 {
                                     id = r.Id,
                                     basvuru_id = r.User_Id, //başvuran kişi
                                     created = r.Zaman_Damgası,
                                     status_id = a.id,
                                     baslik = r.Baslik
                                 };
                    return new SuccessDataResult<List<ApplicationInfoWithUserDto>>(result.ToList());
                }
          

        }

        public IResult getFeedbackforGuest(Users u)
        {

            using(EtikContext context=new EtikContext())
            {
                var result=context.users.SingleOrDefault(p=>p.Id == u.Id);
                if (result.User_Type == 3)
                {

                }
            }
            throw new NotImplementedException();
        }
    }
}
