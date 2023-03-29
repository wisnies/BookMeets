using Contracts.Authentication;
using ErrorOr;
using MediatR;

namespace Application.Features.Auth.Commands.Login
{
  public record LoginCommand(
    string Email,
    string Password
    ) : IRequest<ErrorOr<AuthResponse>>;

}
