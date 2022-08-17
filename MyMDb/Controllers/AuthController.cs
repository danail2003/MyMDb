namespace MyMDb.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using MyMDb.DTO;
    using MyMDb.Services;

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserDTO dto)
        {
            var result = await _authService.Register(dto);

            return Ok(result);
        }
    }
}
