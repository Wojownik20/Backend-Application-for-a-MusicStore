using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using LeverX.WebAPI.Features.Authentication.Commands;
using LeverX.WebAPI.Features.JWT.Dto;
using LeverXWebAPI.Features.Authentication.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using MusicStore.Identity.Models;
using MusicStore.Identity.Services;
using RegisterDto = LeverX.WebAPI.Features.JWT.Dto.RegisterDto;


namespace LeverX.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;
    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Register endpoint for users
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }


    /// <summary>
    /// Login endpoint for users
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }


    /// <summary>
    /// Return Users Name if User is authenticated
    /// </summary>
    /// <returns></returns>
    [Authorize]
    [HttpGet("secret")]
    public IActionResult SecretData()
    {
        var username = User.Identity?.Name;
        return Ok($"Access granted for user: {username}");
    }

    /// <summary>
    /// For every User with Id%==0 returns 200 True
    /// </summary>
    /// <returns></returns>
    [Authorize(Policy = "PremiumOnly")]
    [HttpGet("vip-only")]
    public IActionResult PremiumStuff()
    {
        return Ok("You are a premium user!");
    }
    /// <summary>
    /// Gives info about current User
    /// </summary>
    /// <returns></returns>
    [Authorize]
    [HttpGet("Info")]
    public IActionResult Info()
    {
        return Ok(User.Claims.Select(c => new { c.Type, c.Value }));
    }

    /// <summary>
    /// Checks Users refresh token
    /// </summary>
    /// <param name="refreshToken"></param>
    /// <returns></returns>
    [HttpPost("refresh")]
    public async Task<IActionResult> RefreshToken([FromBody] string refreshToken)
    {
        var result = await _mediator.Send(new RefreshTokenCommand { RefreshToken = refreshToken });
        return Ok(result);
    }

    /// <summary>
    /// Changes password for the user
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [Authorize]
    [HttpPost("change-password")]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand command)
    {
        var result = await _mediator.Send(command);
        return result ? Ok("Password changed successfully.") : BadRequest("Invalid credentials.");
    }

}
