using System.Threading.Tasks;
using GetTest.Contracts;
using GetTest.Services;
using Microsoft.AspNetCore.Mvc;
using GetTest.Utilities.Extension;

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

        [HttpPost("api/v1/user")]
        public async Task<IActionResult> PostUserAsync(UserDto user)
        {
            var response = await _userService.PostUserAsync(user);
            if (response.StatusCode == Services.Enum.StatusCode.Created)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("api/v1/user/{userID}")]
        public async Task<IActionResult> DeleteUserAsync(int userID)
        {
            var response = await _userService.DeleteUserAsync(userID);
            if (response.StatusCode == Services.Enum.StatusCode.Ok)
            {
                return Ok(response.RemoveNullKey());
            }
            return BadRequest(response.RemoveNullKey());
        }

        [HttpPut("api/v1/user/{userID}")]
        public async Task<IActionResult> UpdateUserAsync(int userID, UserDto user)
        {
            var response = await _userService.UpdateUserAsync(userID, user);
            if (response.StatusCode == Services.Enum.StatusCode.Ok)
            {
                return Ok(response.RemoveNullKey());
            }
            return BadRequest(response.RemoveNullKey());
        }
    }
}