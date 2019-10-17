using System.Threading.Tasks;
using GetTest.Contracts;
using GetTest.Services;
using Microsoft.AspNetCore.Mvc;
using GetTest.Utilities.Extension;

namespace GetTest.Api.Controllers.V1
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("api/v1/token")]
        public async Task<IActionResult> AuthenticationAsync(AuthDto auth)
        {
            var response = await _authService.Authentication(auth);
            if (response.StatusCode == Services.Enum.StatusCode.Ok)
            {
                return Ok(response.RemoveNullKey());
            }
            return BadRequest(response);
        }
    }
}
