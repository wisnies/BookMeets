using Application.Common.Interfaces.Persistence;
using Contracts.Common;
using Domain.Common.Errors;
using Domain.Entities.ManyToMany;
using ErrorOr;
using MediatR;

namespace Application.Features.Book.Commands.AddAuthor
{
  public class AddBookAuthorCommandHandler
    : IRequestHandler<AddBookAuthorCommand, ErrorOr<BaseCommandResponse>>
  {
    private readonly IBookRepository _bookRepository;

    public AddBookAuthorCommandHandler(IBookRepository bookRepository)
    {
      _bookRepository = bookRepository;
    }

    public async Task<ErrorOr<BaseCommandResponse>> Handle(
      AddBookAuthorCommand request,
      CancellationToken cancellationToken)
    {
      var bookAuthors = new List<BookAuthor>() {
        new BookAuthor()
        {
          BookId = request.Id,
          AuthorId = request.AuthorId,
        }
      };

      if (!await _bookRepository.AddBookAuthorsAsync(bookAuthors))
      {
        return Errors.Book.BookAuthors;
      }
      return new BaseCommandResponse()
      {
        Id = request.Id,
        Message = "Relation created."
      };
    }
  }
}
