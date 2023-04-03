using Application.Features.Auth.Commands.Login;
using Application.Features.Auth.Commands.Logout;
using Application.Features.Auth.Commands.RefreshToken;
using Application.Features.Auth.Commands.Register;
using AutoMapper;
using Contracts.Authentication;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace Api.Controllers
{
  [Route("auth")]
  public class AuthController : ApiController
  {
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    public AuthController(ISender mediator, IMapper mapper)
    {
      _mediator = mediator;
      _mapper = mapper;
    }

    [Route("register")]
    [HttpPost]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
      var command = _mapper.Map<RegisterCommand>(request);
      ErrorOr<Unit> response = await _mediator.Send(command);
      return response.Match(
        response => Ok(),
        errors => Problem(errors));

    }

    [Route("login")]
    [HttpPost]
    public async Task<IActionResult> Login(LoginRequest request)
    {
      var command = _mapper.Map<LoginCommand>(request);
      ErrorOr<AuthResponse> response = await _mediator.Send(command);
      return response.Match(
        response => Ok(response),
        errors => Problem(errors));
    }

    [Route("logout")]
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Logout(LogoutRequest request)
    {
      var command = _mapper.Map<LogoutCommand>(request);
      ErrorOr<Unit> response = await _mediator.Send(command);
      return response.Match(
        response => Ok(),
        errors => Problem(errors));
    }
    [Route("[action]")]
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> RefreshToken(RefreshTokenRequest request)
    {
      var expiredToken = GetJwtToken(request.ExpiredToken);
      var command = new RefreshTokenCommand(expiredToken, request.RefreshToken);
      ErrorOr<RefreshTokenResponse> response = await _mediator.Send(command);
      return response.Match(
        response => Ok(response),
        errors => Problem(errors));
    }
    private JwtSecurityToken GetJwtToken(string expiredToken)
    {
      JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
      return tokenHandler.ReadJwtToken(expiredToken);
    }
  }
}
