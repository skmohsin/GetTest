using System.Threading.Tasks;
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
        public async Task<IActionResult> GetDoctorAsync()
        {
            var response = await _userService.GetDoctorsAsync();
            if (response.StatusCode == Services.Enum.StatusCode.Ok)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}