using Contracts.Common;
using ErrorOr;
using MediatR;

namespace Application.Features.Genre.Commands.Delete
{
  public record DeleteGenreCommand(int Id) : IRequest<ErrorOr<BaseCommandResponse>>;
}
