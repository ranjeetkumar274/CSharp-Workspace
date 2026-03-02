using dotnetapp.Models;
using dotnetapp.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnetapp.Controllers
{
    [Route("api")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            var existingUser = await _userService.GetUserByEmailAsync(user.Email);
            if (existingUser != null)
                return Conflict(new { message = "User already exists." });

            var registeredUser = await _userService.RegisterUserAsync(user);
            return Ok(new { message = "Registration successful", userId = registeredUser.UserId });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            try
            {
                if (model == null)
                    return BadRequest("Login data is null");

                var user = await _userService.GetUserByEmailAsync(model.Email);
                if (user == null || user.Password != model.Password)
                    return Unauthorized(new { message = "Invalid email or password." });

                var token = _userService.GenerateJwtToken(user);
                return Ok(new { token });
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
