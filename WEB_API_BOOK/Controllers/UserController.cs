using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WEB_API_BOOK.DbModels;
using WEB_API_BOOK.Models;
using WEB_API_BOOK.Services.Interfaces;

namespace WEB_API_BOOK.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserModel userModel)
        {
            var result = await _userService.Login(userModel);
            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("Logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            if(HttpContext.User == null)
                return BadRequest();
            await _userService.Logout();
            return Ok();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserModel userModel)
        {
            IActionResult requestResult = BadRequest();
            var result = await _userService.Register(userModel);
            if (result.Succeeded)
                requestResult = Ok();
            return requestResult;
        }

        [HttpPost("AddRole")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddRole(string roleName)
        {
            IActionResult requestResult = BadRequest();
            var result = await _userService.AddRole(roleName);
            if (result.Succeeded)
                requestResult = Ok();
            return requestResult;
        }

        [HttpPost("AddRoleToUser")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddRoleToUser(string userName, string roleName)
        {
            IActionResult requestResult = BadRequest();
            var result = await _userService.AddRoleToUser(userName, roleName);
            if (result.Succeeded)
                requestResult = Ok();
            return requestResult;
        }
    }
}
