using ErrorOr;
using MediatR;

namespace Application.Features.Auth.Commands.Register
{
  public record RegisterCommand(
    string Email,
    string Password,
    string UserName
    ) : IRequest<ErrorOr<Unit>>;

}
