using Contracts.Common;
using ErrorOr;
using MediatR;

namespace Application.Features.Genre.Commands.Create
{
  public record CreateGenreCommand(
    string Title,
    string Description
    ) : IRequest<ErrorOr<BaseCommandResponse>>;
}
