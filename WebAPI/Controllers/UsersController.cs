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
    }
}
