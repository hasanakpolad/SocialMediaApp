using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.Business.UserService;
using SocialMediaApp.Data.Dtoes;

namespace SocialMediaApp.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet(nameof(GetUser) + "/{userId}")]
        public IActionResult GetUser(int userId)
        {
            try
            {
                var data = _userService.Get(userId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet(nameof(GetAllUser))]
        public IActionResult GetAllUser()
        {
            try
            {
                var data = _userService.GetAll();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost(nameof(AddUser))]
        public IActionResult AddUser(UserDto model)
        {
            try
            {
                if (model == null) return BadRequest();
                _userService.Add(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
