using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LeverX.WebAPI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MusicStore.Shared.Models.JWT_Authentication;


namespace LeverX.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private static List<User> _users = new();
    private readonly IConfiguration _configuration;

    public AuthController(IDbConnection dbConnection, IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterDto dto)
    {
        if (_users.Any(u => u.Username == dto.Username))
            return BadRequest("User already exists");

        var user = new User
        {
            Username = dto.Username,
            Password = PasswordHasher.Hash(dto.Password),
            Role = MusicStore.Shared.Models.UserRole.User
        };

        _users.Add(user);
        return Ok("User registered");
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDto dto)
    {
        var user = _users.FirstOrDefault(u => u.Username == dto.Username);
        if (user is null || !PasswordHasher.Verify(dto.Password, user.Password))
            return Unauthorized("Invalid credentials");

        var token = GenerateJwtToken(user);
        return Ok(new { token });
    }

    [Authorize]
    [HttpGet("secret")]
    public IActionResult SecretData()
    {
        var username = User.Identity?.Name;
        return Ok($"Access granted for user: {username}");
    }

    private string GenerateJwtToken(User user)
    {
        var claims = new[]
        {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(60),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
