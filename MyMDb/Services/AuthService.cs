namespace MyMDb.Services
{
    using System.Security.Cryptography;

    using MyMDb.DTO;
    using MyMDb.Models;

    public class AuthService : IAuthService
    {
        private readonly MyMDbContext _dbContext;

        public AuthService(MyMDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Register(UserDTO dto)
        {
            CreatePasswordHash(dto.Password, out byte[] passwordHash);

            var user = new User
            {
                Email = dto.Email,
                Password = passwordHash.ToString()
            };

            await _dbContext.Users.AddAsync(user);

            await _dbContext.SaveChangesAsync();

            return user.Id;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash)
        {
            using var hmac = new HMACSHA512();
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
}
