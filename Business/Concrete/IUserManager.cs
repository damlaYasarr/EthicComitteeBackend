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
using System.Text.RegularExpressions;
using Lucene.Net.Support;

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
                    arastirma_niteligi = applyInfo.arastirma_niteligi_id
                    

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
                    Parola_id = personalInfo.parola,
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
                                     //Created = r.Zaman_Damgası,
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
                    applyDetail.arastirma_niteligi = applyInfo.arastirma_niteligi_id;
                }
                context.SaveChanges();
                return new SuccessResult(Messages.ApplyUpdatedInfo);
            }
        }

        public IResult addFile(int basvuru_id, int file_type, IFormFile file)
        {
            using (EtikContext context = new EtikContext())
            {
                // dosya formatı ve null olması sorgulanır
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
                    string local_document_dir = Directory.GetCurrentDirectory();
                    string filename = Guid.NewGuid().ToString();
                    document_path = local_document_dir + @"\" + filename + ".pdf";
                } while (File.Exists(document_path));

                //iffilepathexist get another path

                //createing the file
                Stream fileStream = new FileStream(document_path, FileMode.Create);
                file.CopyTo(fileStream); ;




                Entities.Concrete.Documents doc = new Entities.Concrete.Documents()
                {
                    basvuru_id = basvuru_id,
                    doc_type = file_type,
                    doc_path = document_path

                };
                context.documents.Add(doc);
                context.SaveChanges();

                return new SuccessResult("Dosya başarı ile yüklendi.");



            }
        }

        public IResult updateFile(int file_id, IFormFile file)
        {
            //burada sadece path güncelleniyor.
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
                    string local_document_dir = Directory.GetCurrentDirectory();
                    string filename = Guid.NewGuid().ToString();
                    document_path = local_document_dir + @"\" + filename + ".pdf";

                } while (File.Exists(document_path));

                //iffilepathexist get another path



                Stream fileStream = new FileStream(document_path, FileMode.Create);
                file.CopyTo(fileStream); ;




                var doc = context.documents.SingleOrDefault(b => b.id == file_id);

                //önceki dosyayı sil
                File.Delete(doc.doc_path);

                if (doc == null)
                {
                    return new ErrorResult("Güncellenecek dosya bulunamadı.");
                }
                else
                {

                    doc.doc_path = document_path;

                }

                context.SaveChanges();
                return new SuccessResult("Dosya başarı ile güncellendi.");
            }
        }



        public void toPdfFile(int apply_id, int pdf_type)
        {


            using (EtikContext context = new EtikContext())
            {
                var worddocumentpaths = new List<String>();

                //doc tipi sayısı alınır
                var doctype = context.doc_type;

                foreach (var item in doctype)
                {
                    Entities.Concrete.Documents file = context.documents.SingleOrDefault
                           (b => (b.basvuru_id == apply_id) && (b.doc_type == item.id));

                    if (file != null && File.Exists(file.doc_path) && file.doc_type != pdf_type)
                    {
                        worddocumentpaths.Add(file.doc_path);
                        //Console.WriteLine(file.doc_path);
                        //Console.WriteLine(file.id);

                    }
                }



                //basvurudaki tüm dosyaları pathlarını listeye ekle
                PdfDocument mergedPdf = new PdfDocument();

                //word to pdf
                int docnum = 0;
                foreach (string file in worddocumentpaths)
                {
                    docnum++;
                    string docnumstring;

                    var appWord = new Application();
                    if (appWord.Documents != null)
                    {


                        var wordDocument = appWord.Documents.Open(file);
                        //path 
                        docnumstring = docnum.ToString();
                        string local_document_dir = Directory.GetCurrentDirectory();
                        string filenamea = Guid.NewGuid().ToString();
                        string pdfDocName = local_document_dir + @"\" + filenamea + ".pdf";

                        if (wordDocument != null)
                        {
                            wordDocument.ExportAsFixedFormat(pdfDocName,
                            WdExportFormat.wdExportFormatPDF);

                            //merge işlemi
                            PdfDocument pdfDoc = PdfReader.Open((pdfDocName), PdfDocumentOpenMode.Import);
                            CopyPages(pdfDoc, mergedPdf);

                            wordDocument.Close();
                        }
                        File.Delete(pdfDocName);

                    }



                }

                //merged pdf için path oluştur
                string document_path;
                do
                {
                    //a random path is given

                    string local_document_dir = Directory.GetCurrentDirectory();
                    string filenameb = Guid.NewGuid().ToString();
                    document_path = local_document_dir + @"\" + filenameb + ".pdf";
                } while (File.Exists(document_path));


                mergedPdf.Save(document_path);

                //veritabanına kayıt



                Entities.Concrete.Documents doc = new Entities.Concrete.Documents()
                {
                    basvuru_id = apply_id,
                    doc_type = pdf_type,
                    doc_path = document_path

                };

                context.documents.Add(doc);
                context.SaveChanges();

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
                                    // created = r.Zaman_Damgası,
                                     status_id = a.id,
                                     baslik = r.Baslik
                                 };
                    return new SuccessDataResult<List<ApplicationInfoWithUserDto>>(result.ToList());
                }
          

        }



       public string getFeedbackforGuest(int userid)
        {

            using(EtikContext context=new EtikContext())
            {
                var result = context.users.SingleOrDefault(b => b.Id == userid);
                if (result == null) return null;
               
                return result.Feedback;
            }
            
        }

        public HashMap<string, int> getConfirmationCount()
        { 
            int temp = 0;
            HashMap<string, int> hmap = new HashMap<string, int>();
            using (EtikContext context= new EtikContext())
            {
               
                var query = from x in context.basvuru
                            join t in context.etik_kurul on x.Onerilen_Etik_Kurulu equals t.Id into ux
                            from t in ux.DefaultIfEmpty()
                            where x.status == 2//onaylanan sayısı
                            orderby x.status
                          
                            select new
                            {   
                                Key=x.Id,
                                Type = t.Etik_Kurul_Adi,
                                Count = context.basvuru.Where(i=>i.Onerilen_Etik_Kurulu .Equals(t.Id)).Count(), 
                            };
        
                temp= query.Count();
               
                foreach(var item in query)
                {
                    hmap.Add(item.Type, item.Count);
                }

            }
            return hmap;

        }

        public HashMap<string, int> getApplicationCount()
        {
            int temp = 0;
            HashMap<string, int> hmap = new HashMap<string, int>();
            using (EtikContext context = new EtikContext())
            {

                var query = from x in context.basvuru
                            join t in context.etik_kurul on x.Onerilen_Etik_Kurulu equals t.Id into ux
                            from t in ux.DefaultIfEmpty()
                            where x.status == 3 //onaylanma bekleyen sayısı
                            orderby x.status

                            select new
                            {
                                Key = x.Id,
                                Type = t.Etik_Kurul_Adi,
                                Count = context.basvuru.Where(i => i.Onerilen_Etik_Kurulu.Equals(t.Id)).Count(),
                            };

                temp = query.Count();

                foreach (var item in query)
                {
                    hmap.Add(item.Type, item.Count);
                }

            }
            return hmap;
        }

        public IResult AddFeedBackforGuest(feedbackDto k)
        {
            using (EtikContext context = new EtikContext())
            {
                var user = context.users.SingleOrDefault(b => b.Id == k.id);
             
                if (user == null)
                {
                    return new ErrorResult("böyle bir kullanıcı yok");
                }
                else
                {
                    if (user.User_Type == 3)//kullanıcı birden fazla feedback yollayabilir m?
                    {
                        user.Id = k.id;
                        user.Feedback = k.feedback;
                    }
                    else
                    {
                        return new ErrorResult("feed back göndermeye yetkili değilsiniz");
                    }

                    context.SaveChanges();
                }
             

            }

            return new SuccessResult("hey başarılı");
        }





    }
}
