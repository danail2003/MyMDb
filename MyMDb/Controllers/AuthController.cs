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

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(UserDTO dto)
        {
            var isUserAvailable = await _authService.IsUserAvailable(dto.Email);

            if (isUserAvailable)
            {
                return BadRequest("User is already exists!");
            }

            var result = await _authService.Register(dto);

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserDTO dto)
        {
            var isUserAvailable = await _authService.IsUserAvailable(dto.Email);

            if (!isUserAvailable)
            {
                return BadRequest("User doesn't exist.");
            }

            var isPasswordCorrect = await _authService.IsPasswordCorrect(dto);

            if (!isPasswordCorrect)
            {
                return BadRequest("Password is not correct");
            }

            var token = _authService.Login(dto);

            return Ok(token);
        }
    }
}
