using Application.Common.Interfaces.Persistence;
using Contracts.Common;
using Domain.Common.Errors;
using Domain.Entities.ManyToMany;
using ErrorOr;
using MediatR;

namespace Application.Features.Book.Commands.AddGenre
{
  public class AddBookGenreCommandHandler
    : IRequestHandler<AddBookGenreCommand, ErrorOr<BaseCommandResponse>>
  {
    private readonly IBookRepository _bookRepository;

    public AddBookGenreCommandHandler(IBookRepository bookRepository)
    {
      _bookRepository = bookRepository;
    }

    public async Task<ErrorOr<BaseCommandResponse>> Handle(
      AddBookGenreCommand request,
      CancellationToken cancellationToken)
    {
      var bookGenres = new List<BookGenre>() {
        new BookGenre()
        {
          BookId = request.Id,
          GenreId = request.GenreId,
        }
      };

      if (!await _bookRepository.AddBookGenresAsync(bookGenres))
      {
        return Errors.Book.BookGenres;
      }
      return new BaseCommandResponse()
      {
        Id = request.Id,
        Message = "Relation created."
      };
    }
  }
}
