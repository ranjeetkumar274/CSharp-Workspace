using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using dotnetapp.Models;
using dotnetapp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace dotnetapp.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext cont;
        private readonly IConfiguration config;

        public UserService(ApplicationDbContext context, IConfiguration configuration)
        {
            cont = context;
            config = configuration;
        }

        public async Task<User> RegisterUserAsync(User user)
        {
            cont.Users.Add(user);
            await cont.SaveChangesAsync();
            return user;
        }

        public async Task<string> GenerateJwtTokenAsync(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.UserRole),
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: config["JWT:Issuer"],
                audience: config["JWT:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: credentials
            );

            return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await cont.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await cont.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(long userId)
        {
            return await cont.Users.FirstOrDefaultAsync(u => u.UserId == userId);
        }
    }
}