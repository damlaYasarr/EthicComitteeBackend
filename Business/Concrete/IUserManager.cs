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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting.Internal;
using Grpc.Core;
using System.IO;

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

        public void addFile(FilesDtos b)
        {

       
        }

        public IResult getPdfFile(string[] docpaths)
        {
            //pdf sharp indir.
            //microsoft office interop word indir.
            var pdfpaths = new List<String>();
            PdfDocument mergedPdf = new PdfDocument();


            int docnum = 0;
            foreach (string doc in docpaths)
            {
                docnum++;
                string docnumstring;

                var appWord = new Application();
                if (appWord.Documents != null)
                {


                    var wordDocument = appWord.Documents.Open(doc);
                    //şimdilik path ver her birini pdf'e çevir sonra silmeye bak
                    docnumstring = docnum.ToString();
                    string pdfDocName = @"C:\Users\Lenovo\Desktop\eko_formlari\pdfDocument" + docnumstring + ".pdf";

                    if (wordDocument != null)
                    {
                        wordDocument.ExportAsFixedFormat(pdfDocName,
                        WdExportFormat.wdExportFormatPDF);

                        //merge işlemi
                        PdfDocument pdfDoc = PdfReader.Open((pdfDocName), PdfDocumentOpenMode.Import);
                        CopyPages(pdfDoc, mergedPdf);

                        wordDocument.Close();
                    }

                }

     

            }
            //path ver
            mergedPdf.Save("path");
            return new SuccessResult("başarılı");
        }

        public IResult updateFile(Entities.Concrete.Documents document)
        {
            //sadece path güncelleniyor.
            using (EtikContext context = new EtikContext())
            {

                var doc = context.documents.SingleOrDefault(b => b.id == document.id);
                if (doc == null)
                {
                    return new ErrorResult("Güncellenecek dosya bulunamadı");
                }
                else
                {
                    doc.doc_path = document.doc_path;

                }

                context.SaveChanges();
                return new SuccessResult(Messages.PersonalUpdatedInfo);
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
    }
}
