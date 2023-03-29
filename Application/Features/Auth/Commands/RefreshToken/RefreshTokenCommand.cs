using Contracts.Authentication;
using ErrorOr;
using MediatR;
using System.IdentityModel.Tokens.Jwt;

namespace Application.Features.Auth.Commands.RefreshToken
{
  public record RefreshTokenCommand(
    JwtSecurityToken ExpiredToken,
    string RefreshToken
    ) : IRequest<ErrorOr<RefreshTokenResponse>>;
}
