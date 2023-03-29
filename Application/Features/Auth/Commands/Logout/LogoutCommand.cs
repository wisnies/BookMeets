using ErrorOr;
using MediatR;

namespace Application.Features.Auth.Commands.Logout
{
  public record LogoutCommand(
    string RefreshToken
    ) : IRequest<ErrorOr<Unit>>;

}
