using Contracts.Common;
using ErrorOr;
using MediatR;

namespace Application.Features.Book.Commands.AddAuthor
{
  public class AddBookAuthorCommand : IRequest<ErrorOr<BaseCommandResponse>>
  {
    public int Id { get; set; }
    public int AuthorId { get; set; }
  }
}
