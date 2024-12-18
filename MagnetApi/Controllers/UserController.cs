using MagnetApi.DTO;
using MagnetApi.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MagnetApi.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowSpecificOrigins")] // Nazwa polityki CORS
    public class UserController : ControllerBase
        {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
            {
            _userService = userService;
            }

        [HttpPost("authenticate")]
        [AllowAnonymous] // Dostępny dla wszystkich
        public async Task<IActionResult> Authenticate([FromBody] UserDto userDto)
            {
            try
                {
                var user = await _userService.AuthenticateAsync(userDto);
                if (user == null)
                    {
                    return Unauthorized("Invalid email or password.");
                    }

                return Ok(user);
                }
            catch (ArgumentException ex)
                {
                return BadRequest(ex.Message);
                }
            }

        [HttpPost("register")]
        [Authorize(Policy = "AdminOnly")] // Wymaga roli Admin
        public async Task<IActionResult> Register([FromBody] UserDtoRegister userDtoRegister)
            {
            try
                {
                var result = await _userService.RegisterAsync(userDtoRegister);
                if (result)
                    {
                    return Ok("User registered successfully.");
                    }

                return BadRequest("Failed to register user.");
                }
            catch (ArgumentException ex)
                {
                return BadRequest(ex.Message);
                }
            catch (InvalidOperationException ex)
                {
                return Conflict(ex.Message);
                }
            }

        [HttpPut("update-password")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordDto updatePasswordDto)
            {
            try
                {
                var result = await _userService.UpdatePasswordAsync(
                    updatePasswordDto.UserId,
                    updatePasswordDto.CurrentPassword,
                    updatePasswordDto.NewPassword
                );

                if (result)
                    {
                    return Ok("Password updated successfully.");
                    }

                return BadRequest("Failed to update password.");
                }
            catch (ArgumentException ex)
                {
                return BadRequest(ex.Message);
                }
            catch (KeyNotFoundException ex)
                {
                return NotFound(ex.Message);
                }
            catch (UnauthorizedAccessException ex)
                {
                return Unauthorized(ex.Message);
                }
            }
        }
    }
