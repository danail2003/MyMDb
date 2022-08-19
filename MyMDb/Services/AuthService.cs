namespace MyMDb.Services
{
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Security.Cryptography;
    using System.Text;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.IdentityModel.Tokens;

    using MyMDb.DTO;
    using MyMDb.Models;

    public class AuthService : IAuthService
    {
        private readonly MyMDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public AuthService(MyMDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public async Task<Guid> Register(UserDTO dto)
        {
            var hashedPassword = Hash(dto.Password);

            var user = new User
            {
                Email = dto.Email,
                Password = hashedPassword
            };

            await _dbContext.Users.AddAsync(user);

            await _dbContext.SaveChangesAsync();

            return user.Id;
        }

        private string Hash(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            var hashBytes = MD5.Create().ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }

        public async Task<bool> IsUserAvailable(string email)
            => await _dbContext.Users.AnyAsync(x => x.Email.Equals(email));

        public async Task<bool> IsPasswordCorrect(UserDTO dto)
            => await _dbContext.Users.AnyAsync(x => x.Email.Equals(dto.Email) && x.Password.Equals(Hash(dto.Password)));

        public async Task<string> Login(UserDTO dto)
        {
            string token = CreateToken(dto.Email);

            return token;
        }

        private string CreateToken(string email)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Email, email),
            };

            var key = Encoding.UTF8.GetBytes(_configuration.GetSection("SecretToken:Token").Value);
            var cred = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddDays(2), signingCredentials: cred);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
