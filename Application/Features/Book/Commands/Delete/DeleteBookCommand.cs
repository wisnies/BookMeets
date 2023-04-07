using Contracts.Common;
using ErrorOr;
using MediatR;

namespace Application.Features.Book.Commands.Delete
{
  public class DeleteBookCommand : IRequest<ErrorOr<BaseCommandResponse>>
  {
    public int Id { get; set; }
  }
}
