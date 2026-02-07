Week 5 Day 1 Session 2 
Q 1
 
 
User.cs


csharp


using System.ComponentModel.DataAnnotations;


using System.ComponentModel.DataAnnotations.Schema;
 
namespace dotnetapp.Models


{


    public class User


    {


        [Key]


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]


        public long UserId { get; set; }


        public string Email { get; set; }


        public string Password { get; set; }


        public string Username { get; set; }


        public string MobileNumber { get; set; }


        public string UserRole { get; set; }


    }


}


Use code with caution.
 
LoginModel.cs


csharp


namespace dotnetapp.Models


{


    public class LoginModel


    {


        public string Email { get; set; }


        public string Password { get; set; }


    }


}


Use code with caution.
 
Plant.cs


csharp


using System.ComponentModel.DataAnnotations;


using System.ComponentModel.DataAnnotations.Schema;
 
namespace dotnetapp.Models


{


    public class Plant


    {


        [Key]


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]


        public int Plantid { get; set; }


        public string Name { get; set; }


        public string ScientificName { get; set; }


        public string Description { get; set; }


        public double Price { get; set; }


    }


}


Use code with caution.
 
ApplicationDbContext.cs


csharp


using Microsoft.EntityFrameworkCore;
 
namespace dotnetapp.Models


{


    public class ApplicationDbContext : DbContext


    {


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
 
        public DbSet<User> Users { get; set; }


        public DbSet<Plant> Plants { get; set; }


    }


}


Use code with caution.
 
2. Services Folder


IAuthService.cs


csharp


using System.Collections.Generic;


using System.Security.Claims;


using System.Threading.Tasks;


using dotnetapp.Models;
 
namespace dotnetapp.Services


{


    public interface IAuthService


    {


        Task<bool> Registration(User model, string role);


        Task<string> Login(LoginModel model);


        string GenerateToken(IEnumerable<Claim> claims);


    }


}


Use code with caution.
 
AuthService.cs


csharp


using System;


using System.Collections.Generic;


using System.IdentityModel.Tokens.Jwt;


using System.Linq;


using System.Security.Claims;


using System.Text;


using System.Threading.Tasks;


using dotnetapp.Models;


using Microsoft.Extensions.Configuration;


using Microsoft.IdentityModel.Tokens;
 
namespace dotnetapp.Services


{


    public class AuthService : IAuthService


    {


        private readonly ApplicationDbContext _context;


        private readonly IConfiguration _config;
 
        public AuthService(ApplicationDbContext context, IConfiguration config)


        {


            _context = context;


            _config = config;


        }
 
        public async Task<bool> Registration(User model, string role)


        {


            if (role != "Admin" && role != "Customer") return false;


            return true; // Logic handled in Controller as per instructions


        }
 
        public async Task<string> Login(LoginModel model)


        {


            var user = _context.Users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);


            if (user == null) return null;
 
            var claims = new[] {


                new Claim(ClaimTypes.Name, user.Username),


                new Claim(ClaimTypes.Email, user.Email),


                new Claim(ClaimTypes.Role, user.UserRole)


            };
 
            return GenerateToken(claims);


        }
 
        public string GenerateToken(IEnumerable<Claim> claims)


        {


            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Secret"]));


            var token = new JwtSecurityToken(


                issuer: _config["JWT:ValidIssuer"],


                audience: _config["JWT:ValidAudience"],


                expires: DateTime.Now.AddHours(3),


                claims: claims,


                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)


            );
 
            return new JwtSecurityTokenHandler().WriteToken(token);


        }


    }


}


Use code with caution.
 
3. Controllers Folder


AuthenticationController.cs


csharp


using System;


using System.Threading.Tasks;


using dotnetapp.Models;


using dotnetapp.Services;


using Microsoft.AspNetCore.Mvc;
 
namespace dotnetapp.Controllers


{


    [Route("api")]


    [ApiController]


    public class AuthenticationController : ControllerBase


    {


        private readonly IAuthService _authService;


        private readonly ApplicationDbContext _context;
 
        public AuthenticationController(IAuthService authService, ApplicationDbContext context)


        {


            _authService = authService;


            _context = context;


        }
 
        [HttpPost("register")]


        public async Task<IActionResult> Register([FromBody] User user)


        {


            if (!ModelState.IsValid) return BadRequest("Invalid payload");


            try {


                if (user.UserRole != "Admin" && user.UserRole != "Customer")


                    return BadRequest("Invalid Role");
 
                _context.Users.Add(user);


                await _context.SaveChangesAsync();


                return Ok("Registration successful");


            }


            catch (Exception ex) { return BadRequest(ex.Message); }


        }
 
        [HttpPost("login")]


        public async Task<IActionResult> Login([FromBody] LoginModel model)


        {


            if (!ModelState.IsValid) return BadRequest("Invalid payload");


            try {


                var token = await _authService.Login(model);


                if (token == null) return BadRequest("Invalid credentials");


                return Ok(new { token });


            }


            catch (Exception ex) { return BadRequest(ex.Message); }


        }


    }


}


Use code with caution.
 
PlantController.cs


csharp


using System.Threading.Tasks;


using dotnetapp.Models;


using Microsoft.AspNetCore.Authorization;


using Microsoft.AspNetCore.Mvc;


using Microsoft.EntityFrameworkCore;
 
namespace dotnetapp.Controllers


{


    [Authorize]


    [Route("api/plants")]


    [ApiController]


    public class PlantController : ControllerBase


    {


        private readonly ApplicationDbContext _context;
 
        public PlantController(ApplicationDbContext context)


        {


            _context = context;


        }
 
        [HttpGet]


        public async Task<IActionResult> Get()


        {


            var plants = await _context.Plants.ToListAsync();


            return Ok(plants);


        }
 
        [HttpPost]


        [Authorize(Roles = "Admin")]


        public async Task<IActionResult> Post([FromBody] Plant plant)


        {


            if (plant == null) return BadRequest();


            _context.Plants.Add(plant);


            await _context.SaveChangesAsync();


            return CreatedAtAction(nameof(Get), new { id = plant.Plantid }, plant);


        }


    }


}


Use code with caution.
 
4. Configuration (appsettings.json)


json


{


  "ConnectionStrings": {


    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=appdb;Trusted_Connection=True;"


  },


  "JWT": {


    "ValidAudience": "http://localhost:8080",


    "ValidIssuer": "http://localhost:8080",


    "Secret": "ByYM000OLlMQG6VVVp1OH7Xzyr7gHuw1qvUC5dcGt3SNM"


  }


}


Use code with caution.
 
5. Program.cs (Simplified .NET 6+)


csharp


using System.Text;


using dotnetapp.Models;


using dotnetapp.Services;


using Microsoft.AspNetCore.Authentication.JwtBearer;


using Microsoft.EntityFrameworkCore;


using Microsoft.IdentityModel.Tokens;
 
var builder = WebApplication.CreateBuilder(args);
 
builder.Services.AddControllers();


builder.Services.AddDbContext<ApplicationDbContext>(options =>


    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
 
builder.Services.AddScoped<IAuthService, AuthService>();
 
builder.Services.AddAuthentication(options => {


    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;


    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;


})


.AddJwtBearer(options => {


    options.TokenValidationParameters = new TokenValidationParameters {


        ValidateIssuer = true,


        ValidateAudience = true,


        ValidAudience = builder.Configuration["JWT:ValidAudience"],


        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],


        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))


    };


});
 
var app = builder.Build();


app.UseAuthentication();


app.UseAuthorization();


app.MapControllers();


app.Run();
 
Week 5 Day 1 -  S2  Q1
 
 
Controllers
 
 
using System;
using System.Threading.Tasks;
using dotnetapp.Models;
using dotnetapp.Services;
using Microsoft.AspNetCore.Mvc;
 
namespace dotnetapp.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ApplicationDbContext _context;
 
        public AuthenticationController(IAuthService authService, ApplicationDbContext context)
        {
            _authService = authService;
            _context = context;
        }
 
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid payload");
            try
            {
                if (user.UserRole != "Admin" && user.UserRole != "Customer")
                    return BadRequest("Invalid Role");
 
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return Ok("Registration successful");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
 
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login model)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid payload");
            try
            {
                var token = await _authService.Login(model);
                if (token == null) return BadRequest("Invalid credentials");
                return Ok(new { token });
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}
 
 
 
 
using System.Threading.Tasks;
using dotnetapp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
 
namespace dotnetapp.Controllers
{
    [Authorize]
    [Route("api/plants")]
    [ApiController]
    public class PlantController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
 
        public PlantController(ApplicationDbContext context)
        {
            _context = context;
        }
 
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var plants = await _context.Plants.ToListAsync();
            return Ok(plants);
        }
 
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post([FromBody] Plant plant)
        {
            if (plant == null) return BadRequest();
            _context.Plants.Add(plant);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = plant.PlantId }, plant);
        }
    }
}
 
 
 
 
 
 
