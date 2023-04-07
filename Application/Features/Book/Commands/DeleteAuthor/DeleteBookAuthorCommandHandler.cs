using Application.Common.Interfaces.Persistence;
using Contracts.Common;
using Domain.Common.Errors;
using Domain.Entities.ManyToMany;
using ErrorOr;
using MediatR;

namespace Application.Features.Book.Commands.DeleteAuthor
{
  public class DeleteBookAuthorCommandHandler
    : IRequestHandler<DeleteBookAuthorCommand, ErrorOr<BaseCommandResponse>>
  {
    private readonly IBookRepository _bookRepository;

    public DeleteBookAuthorCommandHandler(IBookRepository bookRepository)
    {
      _bookRepository = bookRepository;
    }

    public async Task<ErrorOr<BaseCommandResponse>> Handle(
      DeleteBookAuthorCommand request,
      CancellationToken cancellationToken)
    {
      var bookAuthor = new BookAuthor()
      {
        BookId = request.Id,
        AuthorId = request.AuthorId,
      };

      if (!await _bookRepository.DeleteBookAuthorAsync(bookAuthor))
      {
        return Errors.Book.BookAuthors;
      }

      return new BaseCommandResponse()
      {
        Id = request.Id,
        Message = "Relation deleted."
      };
    }
  }
}
