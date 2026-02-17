using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnetapp.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private static readonly HashSet<string> ValidRoles = new(StringComparer.OrdinalIgnoreCase)
    {
        "Admin",
        "Organizer"
    };

    private readonly ApplicationDbContext _context;

    public UserController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost("register")]
    public async Task<ActionResult<User>> Register(User user)
    {
        if (user == null)
        {
            return BadRequest(new { Message = "Invalid user data" });
        }

        if (!IsValidRole(user.Role))
        {
            return BadRequest(new { Message = "Invalid role" });
        }

        var existingUser = await _context.Users
            .AnyAsync(u => u.Username == user.Username);

        if (existingUser)
        {
            return Conflict(new { Message = "Username already exists" });
        }

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Register), new { id = user.Id }, user);
    }

    [HttpPost("login")]
    public async Task<ActionResult<object>> Login(LoginModel user)
    {
        if (user == null)
        {
            return BadRequest(new { Message = "Invalid login data" });
        }

        var existingUser = await _context.Users
            .FirstOrDefaultAsync(u => u.Username == user.Username && u.Password == user.Password);

        if (existingUser == null)
        {
            return BadRequest(new { Message = "Login failed" });
        }

        return Ok(new { Message = "Login successful", User = existingUser });
    }

    private static bool IsValidRole(string role)
    {
        return !string.IsNullOrWhiteSpace(role) && ValidRoles.Contains(role);
    }
}