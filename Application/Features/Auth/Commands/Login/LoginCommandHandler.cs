using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Contracts.Authentication;
using Domain.Common.Errors;
using Domain.Entities.User;
using Domain.Entities.UserRefreshToken;
using ErrorOr;
using MediatR;

namespace Application.Features.Auth.Commands.Login
{
  public class LoginCommandHandler
    : IRequestHandler<LoginCommand, ErrorOr<AuthResponse>>
  {
    private readonly IUserRepository _userRepository;
    private readonly IUserRefreshTokenRepository _userRefreshTokenRepository;
    private readonly ITokenGenerator _tokenGenerator;
    private readonly IPasswordService _passwordService;

    public LoginCommandHandler(
      IUserRepository userRepository,
      IUserRefreshTokenRepository userRefreshTokenRepository,
      ITokenGenerator tokenGenerator,
      IPasswordService passwordService)
    {
      _userRepository = userRepository;
      _userRefreshTokenRepository = userRefreshTokenRepository;
      _tokenGenerator = tokenGenerator;
      _passwordService = passwordService;
    }

    public async Task<ErrorOr<AuthResponse>> Handle(
      LoginCommand request,
      CancellationToken cancellationToken)
    {
      if (await _userRepository.GetUserByEmailAsync(request.Email) is not User user)
      {
        return Errors.Authentication.InvalidCredentials;
      }
      if (!_passwordService.VerifyHashedPassword(request.Password, user.Password))
      {
        return new[] { Errors.Authentication.InvalidCredentials };
      }

      var accessToken = _tokenGenerator.GenerateAccessToken(user.Id, request.Email);
      var refreshToken = _tokenGenerator.GenerateRefreshToken();

      var userRefreshToken = new UserRefreshToken()
      {
        AccessToken = accessToken,
        RefreshToken = refreshToken,
        // add some configuration for expiration date
        ExpirationDate = DateTime.UtcNow.AddMinutes(240),
        UserId = user.Id
      };

      await _userRefreshTokenRepository.AddAsync(userRefreshToken);

      return new AuthResponse(user.Id, user.UserName, accessToken, refreshToken);
    }
  }
}
