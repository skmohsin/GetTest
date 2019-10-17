using System.Threading.Tasks;
using GetTest.Contracts;
using GetTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace GetTest.Controllers
{

    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("api/v1/users")]
        public async Task<IActionResult> GetUserAsync()
        {
            var response = await _userService.GetUsersAsync();
            if (response.StatusCode == Services.Enum.StatusCode.Ok)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPost("api/v1/users")]
        public async Task<IActionResult> PostUserAsync(UserDto user)
        {
            var response = await _userService.PostUserAsync(user);
            if (response.StatusCode == Services.Enum.StatusCode.Ok)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}