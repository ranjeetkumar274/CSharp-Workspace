using dotnetapp.Models;
using dotnetapp.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnetapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService ser;

        public UserController(UserService userService)
        {
            ser = userService;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await ser.GetAllUsersAsync();
            return Ok(users);
        }

       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(long id)
        {
            var user = await ser.GetUserByIdAsync(id);
            if (user == null)
                return NotFound(new { message = "User not found" });

            return Ok(user);
        }

    
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var created = await ser.RegisterUserAsync(user);
                return CreatedAtAction(nameof(GetUserById), new { id = created.UserId }, created);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            try
            {
                var user = await ser.LoginAsync(model.Email, model.Password);
                return Ok(new { message = "Login successful", user });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(long id, [FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var updated = await ser.UpdateUserAsync(id, user);
                if (updated == null)
                    return NotFound(new { message = "User not found" });

                return Ok(updated);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

     
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            var result = await ser.DeleteUserAsync(id);
            if (!result)
                return NotFound(new { message = "User not found" });

            return Ok(new { message = "User deleted successfully" });
        }
    }
}

 
