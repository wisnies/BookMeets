using Application.Common.Interfaces.Persistence;
using Application.DTOs.Book;
using MediatR;

namespace Application.Features.Book.Queries.BookList
{
  public class BookListQueryHandler
    : IRequestHandler<BookListQuery, ICollection<BookListItemDto>>
  {
    private readonly IBookRepository _bookRepository;
    public BookListQueryHandler(IBookRepository bookRepository)
    {
      _bookRepository = bookRepository;
    }
    public async Task<ICollection<BookListItemDto>> Handle(
      BookListQuery request,
      CancellationToken cancellationToken)
    {
      return await _bookRepository.GetBookListItems();
    }
  }
}
