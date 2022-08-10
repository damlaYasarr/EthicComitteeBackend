using Business.Abstract;
using Business.Concrete;
using Core.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
//break point kırılım noktasıdır. buraya gelince dur demek isteriz
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] //sign
    //Ioc container --inversion of control

    public class UsersController : ControllerBase
    {
        IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;

        }

  
        
    [HttpPost("changeProjectStatus")]
        public IActionResult changeProjectstatus(int user_id, int status )
        {
            var result = _userService.changeProjectstatus(user_id, status);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Success);
        }
        [HttpPost("updateApplylInfo")]
        public IActionResult updateApplylInfo(ApplyInfoDto applyInfoDto)
        {
            var result = _userService.updateApplicationInfo(applyInfoDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Success);
        }
        [HttpPost("updatePersonalInfo")]
        public IActionResult updatePersonalInfo(PersonalInfoDto personalInfoDto)
        {
            var result = _userService.updatePersonalInfo(personalInfoDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Success);
        }
        [HttpPost("addguest")]
        public ActionResult AddNewGuest(PersonalInfoDto users)
        {
          _userService.addPersonalInfo(users);
            return Ok("eklenme başarılı");
        }
        [HttpPost("postapp")]
        public ActionResult PostApplyInfo(ApplyInfoDto applyInfo)
        {
             _userService.addApplicationInfo(applyInfo);
            return Ok("ekleme başrılı");
        }
        //burası çalışan metot
        [HttpGet("getpersonalinfo")]
        public ActionResult getpersonal()
        {
          var result =  _userService.GetUserDetails();
            return Ok(result);
        }
        [HttpGet("getApplicationschema")]
        public ActionResult getApplicationschema(int user_id)
        {
            var result = _userService.GetApplyforStudent(user_id);
            return Ok(result);
        }
        
        [HttpDelete("applyDelete")]
        public IActionResult DeleteApply(int id)
        {
           var result= _userService.DeleteApply(id);

            return Ok(result.Success);

        }
        [HttpGet("forAdmin")]
        public IActionResult getinfoForAdmin()
        {
            var result = _userService.GetAllApplicationforAdmin();
            return Ok(result);
        }
        [HttpPost("addfeedback")]
        public ActionResult AddFeedback(feedbackDto f)
        {
           var result= _userService.AddFeedBackforGuest(f);
            return Ok(result);
        }
        [HttpGet("getfeedback")]
        public IActionResult getfeedback(int u)
        {
            var result = _userService.getFeedbackforGuest(u);
            return Ok(result);
        }
        [HttpGet("getcount")]
        public IActionResult getcount()
        {
            var result = _userService.getConfirmationCount();
            return Ok(result);
        }
        [HttpPost("AddFiles")]

        public IActionResult AddDoc(int basvuru_id, int file_type, IFormFile file)
        {
            _userService.addFile(basvuru_id, file_type, file);
            return Ok("Dosya eklendi.");


        }

        [HttpPost("UpdateFiles")]
        public IActionResult UpdateDoc(int file_id, IFormFile file)
        {
            _userService.updateFile(file_id, file);

            return Ok("Dosya değiştirildi.");
        }


        [HttpPost("toPdf")]
        public IActionResult toPdf(int apply_id, int pdf_type)
        {
            _userService.toPdfFile(apply_id, pdf_type);

            return Ok("Pdf dosyası oluşturuldu.");
        }

        [HttpGet("GetDocument")]
        public IActionResult GetDoc(int file_id)
        {
            string file_path = _userService.GetFilePath(file_id));

            if (file_path != null)
            {
                byte[] document = System.IO.File.ReadAllBytes(file_path);
                return Ok(document);
            }
            else {
                return BadRequest("Dosya bulunamadı.");
                    }

        }

    }
}
