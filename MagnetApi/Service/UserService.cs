using MagnetApi.DB;
using MagnetApi.DTO;
using MagnetApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MagnetApi.Service
    {
    public class UserService : IUserService
        {
        private readonly DBConnection _context;
        private readonly IConfiguration _configuration;

        public UserService(DBConnection context, IConfiguration configuration)
            {
            _context = context;
            _configuration = configuration;
            }

        public async Task<string?> AuthenticateAsync(UserDto userDto)
            {
            if (string.IsNullOrEmpty(userDto.Email) || string.IsNullOrEmpty(userDto.Password))
                {
                throw new ArgumentException("Email and password must be provided.");
                }

            // Find user by email
            var user = await _context.Set<User>().FirstOrDefaultAsync(u => u.Email == userDto.Email);
            if (user == null)
                {
                return null; // User not found
                }

            // Verify password
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(userDto.Password, user.Haslo);
            if (!isPasswordValid)
                {
                return null; // Invalid password
                }

            // Generate JWT
            var token = GenerateJwtToken(user);
            return token; // Authentication successful, return JWT
            }

        private string GenerateJwtToken(User user)
            {
            var jwtSettings = _configuration.GetSection("JwtSettings");

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Name, user.Email),
            new Claim(ClaimTypes.Role, user.Ranga)
        };

            var tokenOptions = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(double.Parse(jwtSettings["ExpirationMinutes"])),
                signingCredentials: signingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            }

        public async Task<bool> RegisterAsync(UserDtoRegister userDtoRegister)
            {
            if (string.IsNullOrEmpty(userDtoRegister.Email) || string.IsNullOrEmpty(userDtoRegister.Password))
                {
                throw new ArgumentException("Email and password must be provided.");
                }

            // Check if email already exists
            bool userExists = await _context.Set<User>().AnyAsync(u => u.Email == userDtoRegister.Email);
            if (userExists)
                {
                throw new InvalidOperationException("User with this email already exists.");
                }

            // Hash the password
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(userDtoRegister.Password);

            // Create a new user
            var newUser = new User
                {
                Login = userDtoRegister.Email,
                Haslo = hashedPassword,
                Data = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                Email = userDtoRegister.Email,
                ImieNazwisko = userDtoRegister.fullName,
                Ranga = userDtoRegister.Ranga,
                };

            await _context.Set<User>().AddAsync(newUser);
            await _context.SaveChangesAsync();

            return true;
            }

        public async Task<bool> UpdatePasswordAsync(int userId, string currentPassword, string newPassword)
            {
            if (string.IsNullOrEmpty(currentPassword) || string.IsNullOrEmpty(newPassword))
                {
                throw new ArgumentException("Both current and new passwords must be provided.");
                }

            // Find user by ID
            var user = await _context.Set<User>().FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
                {
                throw new KeyNotFoundException("User not found.");
                }

            // Verify current password
            bool isCurrentPasswordValid = BCrypt.Net.BCrypt.Verify(currentPassword, user.Haslo);
            if (!isCurrentPasswordValid)
                {
                throw new UnauthorizedAccessException("Current password is incorrect.");
                }

            // Hash the new password
            string hashedNewPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);

            // Update the password
            user.Haslo = hashedNewPassword;

            // Save changes to the database
            _context.Set<User>().Update(user);
            await _context.SaveChangesAsync();

            return true;
            }
        }

    }
