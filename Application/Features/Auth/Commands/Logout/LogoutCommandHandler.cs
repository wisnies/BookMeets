using Application.Common.Interfaces.Persistence;
using Domain.Common.Errors;
using Domain.Entities.UserRefreshToken;
using ErrorOr;
using MediatR;

namespace Application.Features.Auth.Commands.Logout
{
  public class LogoutCommandHandler
    : IRequestHandler<LogoutCommand, ErrorOr<Unit>>
  {
    private readonly IUserRefreshTokenRepository _userRefreshTokenRepository;

    public LogoutCommandHandler(IUserRefreshTokenRepository userRefreshTokenRepository)
    {
      _userRefreshTokenRepository = userRefreshTokenRepository;
    }

    public async Task<ErrorOr<Unit>> Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
      if (await _userRefreshTokenRepository.GetRefreshTokenByTokenAsync(
        request.RefreshToken) is not UserRefreshToken userRefreshToken)
      {
        return Errors.Authentication.InvalidCredentials;
      }
      await _userRefreshTokenRepository.DeleteAsync(userRefreshToken);

      return Unit.Value;
    }
  }
}
