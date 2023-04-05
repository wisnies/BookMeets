using Contracts.Common;
using ErrorOr;
using MediatR;

namespace Application.Features.Genre.Commands.Upsert
{
  public class UpsertGenreCommand : IRequest<ErrorOr<BaseCommandResponse>>
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
  }
}
