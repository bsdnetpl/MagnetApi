using MagnetApi.DTO;

namespace MagnetApi.Service
    {
    public interface IUserService
        {
        Task<string?> AuthenticateAsync(UserDto userDto);
        Task<bool> RegisterAsync(UserDtoRegister userDtoRegister);
        Task<bool> UpdatePasswordAsync(int userId, string currentPassword, string newPassword);
        }
    }