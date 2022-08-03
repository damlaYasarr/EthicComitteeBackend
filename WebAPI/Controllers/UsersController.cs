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
        /*
    [HttpGet("getall")]
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
           
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int userid)
        {
            var result = _userService.GetById(userid);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Success);
        }*/
        [HttpPost("addguest")]
        public ActionResult AddNewGuest(PersonalInfo users)
        {
          _userService.addPersonalInfo(users);
            return Ok("eklenme başarılı");
        }
        //burası çalışan metot
        [HttpGet("getpersonalinfo")]
        public ActionResult getpersonal()
        {
          var result =  _userService.GetUserDetails();
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
