namespace MyMDb.DTO
{
    using System.ComponentModel.DataAnnotations;

    public class UserDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
