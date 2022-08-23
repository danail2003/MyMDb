namespace MyMDb.Services
{
    using System.Text;
    using System.Security.Claims;
    using System.Security.Cryptography;
    using System.IdentityModel.Tokens.Jwt;

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
            var isValidEmail = IsValidEmail(dto.Email);

            if (!isValidEmail)
            {
                throw new InvalidOperationException("Email should be valid!");
            }

            if (string.IsNullOrWhiteSpace(dto.Password) || string.IsNullOrEmpty(dto.RepeatPassword))
            {
                throw new InvalidOperationException("Password and Repeat Password should be not null!");
            }

            if (!dto.Password.Equals(dto.RepeatPassword))
            {
                throw new InvalidOperationException("Password and Repeat password must be equal!");
            }

            var hashedPassword = Hash(dto.Password);

            var user = new User
            {
                Email = dto.Email,
                Password = hashedPassword,
                RoleId = 0
            };

            await _dbContext.Users.AddAsync(user);

            await _dbContext.SaveChangesAsync();

            return user.Id;
        }

        public async Task<string> Login(LoginUserDTO dto)
        {
            string token = CreateToken(dto.Email, dto.Role);

            return token;
        }

        private string Hash(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            var hashBytes = MD5.Create().ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }

        public async Task<bool> IsUserAvailable(string email)
            => await _dbContext.Users.AnyAsync(x => x.Email.Equals(email));

        public async Task<bool> IsPasswordCorrect(LoginUserDTO dto)
            => await _dbContext.Users.AnyAsync(x => x.Email.Equals(dto.Email) && x.Password.Equals(Hash(dto.Password)));

        private string CreateToken(string email, string role)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, role)
            };

            var key = Encoding.UTF8.GetBytes(_configuration.GetSection("SecretToken:Token").Value);
            var cred = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddDays(2), signingCredentials: cred);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
    }
}
