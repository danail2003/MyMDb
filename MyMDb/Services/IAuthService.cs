namespace MyMDb.Services
{
    using MyMDb.DTO;

    public interface IAuthService
    {
        Task<Guid> Register(UserDTO dto);

        Task<bool> IsUserAvailable(string email);

        Task<bool> IsPasswordCorrect(UserDTO dto);

        Task<string> Login(UserDTO dto);
    }
}
