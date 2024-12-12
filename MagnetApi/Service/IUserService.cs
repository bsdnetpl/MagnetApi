using MagnetApi.DTO;
using MagnetApi.Models;

namespace MagnetApi.Service
    {
    public interface IUserService
        {
        Task<User?> AuthenticateAsync(UserDto userDto);
        Task<bool> RegisterAsync(UserDtoRegister userDtoRegister);
        Task<bool> UpdatePasswordAsync(int userId, string currentPassword, string newPassword);
        }
    }