using Application.Common.Interfaces.Persistence;
using Contracts.Common;
using Domain.Common.Errors;
using Domain.Entities.ManyToMany;
using ErrorOr;
using MediatR;

namespace Application.Features.Book.Commands.Create
{
  public class CreateBookCommandHandler
    : IRequestHandler<CreateBookCommand, ErrorOr<BaseCommandResponse>>
  {
    private readonly IBookRepository _bookRepository;
    private readonly IAuthorRepository _authorRepository;

    public CreateBookCommandHandler(
      IBookRepository bookRepository,
      IAuthorRepository authorRepository)
    {
      _bookRepository = bookRepository;
      _authorRepository = authorRepository;
    }

    public async Task<ErrorOr<BaseCommandResponse>> Handle(
      CreateBookCommand request,
      CancellationToken cancellationToken)
    {
      var newBook = new Domain.Entities.Book.Book()
      {
        Title = request.Title,
        Description = request.Description,
        CoverImageUrl = request.CoverImageUrl,
        CoverImagePublicId = request.CoverImagePublicId,
        CoverType = request.CoverType,
        NumberOfPages = request.NumberOfPages,
        FirstPublished = request.FirstPublished,
      };

      var dbBook = await _bookRepository.AddAsync(newBook);

      var bookAuthors = new List<BookAuthor>();

      foreach (int authorId in request.AuthorIds)
      {
        var ba = new BookAuthor()
        {
          AuthorId = authorId,
          BookId = dbBook.Id
        };
        bookAuthors.Add(ba);
      }

      bool baSuccess = await _bookRepository.AddBookAuthorsAsync(bookAuthors);
      if (!baSuccess)
      {
        await _bookRepository.DeleteAsync(dbBook);
        return Errors.Book.BookAuthors;
      }

      var bookGenres = new List<BookGenre>();

      foreach (int genreId in request.GenreIds)
      {
        var bg = new BookGenre()
        {
          BookId = dbBook.Id,
          GenreId = genreId,
        };
        bookGenres.Add(bg);
      }

      bool bgSuccess = await _bookRepository.AddBookGenresAsync(bookGenres);
      if (!bgSuccess)
      {
        await _bookRepository.DeleteAsync(dbBook);
        return Errors.Book.BookGenres;
      }

      return new BaseCommandResponse()
      {
        Id = dbBook.Id,
        Message = "Book " + dbBook.Title + " successfully created."
      };
    }
  }
}
