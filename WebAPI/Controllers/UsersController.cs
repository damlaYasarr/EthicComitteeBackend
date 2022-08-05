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

        /*[HttpGet("getall")]
         public IActionResult GetAll()
            {  //dependency chain
                var result = _userService.GetAll();
                if (result.Success)
                {
                    return Ok(result.Data);
                }
                else
                {
                    return BadRequest(result.Message);
                }

            }*/
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
        /*
        [HttpPost("userdelete")]
        public IActionResult DeleteUser(Users users)
        {
            return Ok();

        }*/
    }
}
