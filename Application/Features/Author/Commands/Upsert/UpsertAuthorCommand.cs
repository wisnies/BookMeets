using Contracts.Common;
using ErrorOr;
using MediatR;

namespace Application.Features.Author.Commands.Upsert
{
  public class UpsertAuthorCommand : IRequest<ErrorOr<BaseCommandResponse>>
  {
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public string ImagePublicId { get; set; }
  }
}
