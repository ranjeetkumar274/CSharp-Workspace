w5 d1 s2 q2


book.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetapp.Models

{

    public class Book

    {

    public int BookId { get; set; }

    public string Title { get; set; }

    public string Author { get; set; }

    public string Description { get; set; }

    public double Price { get; set; }

    }

}
//loginmodel.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetapp.Models
{
    public class LoginModel

    {

    public string Email { get; set; }

    public string Password { get; set; }

    }

}
//user.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetapp.Models
{
    public class User

    {

    public long UserId { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string Username { get; set; }

    public string MobileNumber { get; set; }

    public string UserRole { get; set; } // Admin or Customer

    }
}
//appdb in models

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace dotnetapp.Models

{

    public class ApplicationDbContext : DbContext

    {

    public ApplicationDbContext(DbContextOptions`<ApplicationDbContext>` options)

    : base(options) { }

    public DbSet`<User>` Users { get; set; }

    public DbSet`<Book>` Books { get; set; }

    }

}
//services authservice
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetapp.Models;

using Microsoft.AspNetCore.Identity;

using Microsoft.Extensions.Configuration;

using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;

using System.Security.Claims;

using System.Text;

using Microsoft.EntityFrameworkCore;

namespace dotnetapp.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;
        private readonly PasswordHasher`<User>` _passwordHasher;

    public AuthService(ApplicationDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
            _passwordHasher = new PasswordHasher`<User>`();
        }

    public async Task<(bool Success, string Message)> Register(User model, string role)
        {
            if (model == null)
                return (false, "User object is null.");

    if (role != "Admin" && role != "Customer")
                return (false, "Invalid role. Must be Admin or Customer.");

    var exists = await _context.Users.AnyAsync(u => u.Email == model.Email);
            if (exists)
                return (false, "Email already registered.");

    model.UserRole = role;
            model.Password = _passwordHasher.HashPassword(model, model.Password);
            _context.Users.Add(model);
            await _context.SaveChangesAsync();

    return (true, "User registered successfully.");
        }

    public async Task<(bool Success, string Token, string Message)> Login(LoginModel model)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
            if (user == null)
                return (false, null, "Invalid credentials.");

    var result = _passwordHasher.VerifyHashedPassword(user, user.Password, model.Password);
            if (result == PasswordVerificationResult.Failed)
                return (false, null, "Invalid credentials.");

    var claims = new List`<Claim>`
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.UserRole)
            };

    var token = GenerateToken(claims);
            return (true, token, "Login successful.");
        }

    public string GenerateToken(IEnumerable`<Claim>` claims)
        {
            var key = _config["Jwt:Key"];
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var expiryMinutes = int.Parse(_config["Jwt:ExpiryMinutes"] ?? "60");

    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var creds = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

    var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expiryMinutes),
                signingCredentials: creds
            );

    return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
//iauthservice
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using dotnetapp.Models;

using System.Security.Claims;

namespace dotnetapp.Services

{

    public interface IAuthService

    {

    Task<(bool Success, string Message)> Register(User model, string role);

    Task<(bool Success, string Token, string Message)> Login(LoginModel model);

    string GenerateToken(IEnumerable`<Claim>` claims);

    }

}
//authentication controller
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using dotnetapp.Models;

using dotnetapp.Services;

using Microsoft.AspNetCore.Mvc;

namespace dotnetapp.Controllers

{

    [ApiController]

    [Route("api")]

    public class AuthenticationController : ControllerBase

    {

    private readonly IAuthService _authService;

    public AuthenticationController(IAuthService authService)

    {

    _authService = authService;

    }

    [HttpPost("register")]

    public async Task`<ActionResult>`  Register([FromBody] User user)

    {

    if (!ModelState.IsValid)

    return BadRequest("Invalid payload.");

    if (user.UserRole != "Admin" && user.UserRole != "Customer")

    return BadRequest("UserRole must be 'Admin' or 'Customer'.");

    var (success, message) = await _authService.Register(user, user.UserRole);

    if (!success)

    return BadRequest(message);

    return Ok(new { Message = message });

    }

    [HttpPost("login")]

    public async Task`<ActionResult>`  Login([FromBody] LoginModel model)

    {

    if (!ModelState.IsValid)

    return BadRequest("Invalid payload.");

    var (success, token, message) = await _authService.Login(model);

    if (!success)

    return BadRequest(message);

    return Ok(new { Token = token });

    }

    }

}
//bookcontroller
using dotnetapp.Models;

using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;

namespace dotnetapp.Controllers
{
    [ApiController]
    [Route("api/books")]
    [Authorize]
    public class BookController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

    public BookController(ApplicationDbContext context)
        {
            _context = context;
        }

    [HttpGet]
    [AllowAnonymous]
        public async Task`<ActionResult>` Get()
        {
            var m = await _context.Books.ToListAsync();
            return Ok(m);
        }

    [HttpPost]
    //[AllowAnonymous]
       [Authorize(Roles = "Admin")]
        public async Task`<ActionResult>` Post([FromBody] Book book)
        {
            if (book == null)
                return BadRequest("Movie payload is null.");

    _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = book.BookId }, book);
        }
    }
}
//prog.cs
using dotnetapp.Models;
using dotnetapp.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext `<ApplicationDbContext>`(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("a")));

builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var config = builder.Configuration;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = config["Jwt:Issuer"],
            ValidAudience = config["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]))
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

//appsettings.json

{
"Jwt": {

  "Key": "ThisIsASecretKeyForJwtTokenGeneration123!",

  "Issuer": "MovieAppIssuer",

  "Audience": "MovieAppAudience",

  "ExpiryMinutes": "60"

},

"Logging": {

  "LogLevel": {

  "Default": "Information",

  "Microsoft.AspNetCore": "Warning"

  }

},

"AllowedHosts": "*",
"ConnectionStrings": {
  "a":"user id=sa;password=examlyMssql@123;server=localhost;database=appdb;trusted_connection=false;persist security info=false;encrypt=false"
}
}

//dotnetapp.csproj

<Project Sdk="Microsoft.NET.Sdk.Web">

<PropertyGroup>
    <TargetFramework>net6.0</TargetFramework>
    <Nullable>enable</Nullable>
<AssemblyName>dotnetwebapi</AssemblyName>
    <ImplicitUsings>enable</ImplicitUsings>
    <GenerateAssemblyInfo>false</GenerateAssemblyInfo>
    <GenerateTargetFrameworkAttribute>false</GenerateTargetFrameworkAttribute>
<SonarQubeTestProject>false</SonarQubeTestProject>
  </PropertyGroup>

<ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.Authentication.JwtBearer" Version="6.0.0" />
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="6.0.0" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="6.0.0">
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
      <PrivateAssets>all</PrivateAssets>
    </PackageReference>
    <PackageReference Include="Microsoft.EntityFrameworkCore.InMemory" Version="6.0.0" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="6.0.0" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="6.0.0">
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
      <PrivateAssets>all</PrivateAssets>
    </PackageReference>
    <PackageReference Include="Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="6.0.0" />
    <PackageReference Include="Newtonsoft.Json" Version="13.0.3" />
    <PackageReference Include="NUnit" Version="3.13.3" />
    <PackageReference Include="NUnit3TestAdapter" Version="3" />
    <PackageReference Include="Swashbuckle.AspNetCore" Version="6.2.3" />
  </ItemGroup>

</Project>
