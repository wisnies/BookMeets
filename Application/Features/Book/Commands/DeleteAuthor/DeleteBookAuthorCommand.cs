using Contracts.Common;
using ErrorOr;
using MediatR;

namespace Application.Features.Book.Commands.DeleteAuthor
{
  public class DeleteBookAuthorCommand : IRequest<ErrorOr<BaseCommandResponse>>
  {

    public int Id { get; set; }
    public int AuthorId { get; set; }

  }
}
