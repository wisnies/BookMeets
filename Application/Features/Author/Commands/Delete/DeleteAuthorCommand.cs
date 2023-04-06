using Contracts.Common;
using ErrorOr;
using MediatR;

namespace Application.Features.Author.Commands.Delete
{
  public class DeleteAuthorCommand : IRequest<ErrorOr<BaseCommandResponse>>
  {
    public int Id { get; set; }
  }
}
