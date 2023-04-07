using Application.Common.Interfaces.Persistence;
using Contracts.Common;
using Domain.Common.Errors;
using Domain.Entities.ManyToMany;
using ErrorOr;
using MediatR;

namespace Application.Features.Book.Commands.DeleteGenre
{
  public class DeleteBookGenreCommandHandler
    : IRequestHandler<DeleteBookGenreCommand, ErrorOr<BaseCommandResponse>>
  {
    private readonly IBookRepository _bookRepository;

    public DeleteBookGenreCommandHandler(IBookRepository bookRepository)
    {
      _bookRepository = bookRepository;
    }

    public async Task<ErrorOr<BaseCommandResponse>> Handle(
      DeleteBookGenreCommand request,
      CancellationToken cancellationToken)
    {
      var bookGenre = new BookGenre()
      {
        BookId = request.Id,
        GenreId = request.GenreId,
      };

      if (!await _bookRepository.DeleteBookGenreAsync(bookGenre))
      {
        return Errors.Book.BookGenres;
      }

      return new BaseCommandResponse()
      {
        Id = request.Id,
        Message = "Relation deleted."
      };
    }
  }
}
