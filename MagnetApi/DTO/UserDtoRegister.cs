using Microsoft.EntityFrameworkCore.Metadata;

namespace MagnetApi.DTO
    {
    public class UserDtoRegister
        {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string fullName { get; set; } = string.Empty;
        public string Ranga { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        }
    }
