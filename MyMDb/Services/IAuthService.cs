namespace MyMDb.Services
{
    using MyMDb.DTO;

    public interface IAuthService
    {
        Task<Guid> Register(UserDTO dto);
    }
}
