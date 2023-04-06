using Contracts.Common;
using ErrorOr;
using MediatR;

namespace Application.Features.Author.Commands.Create
{
  public class CreateAuthorCommand : IRequest<ErrorOr<BaseCommandResponse>>
  {
    public string FullName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public string ImagePublicId { get; set; } = null!;
  }
}
