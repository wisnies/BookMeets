using Application.Common.Interfaces.Persistence;
using Application.DTOs.Book;
using MediatR;

namespace Application.Features.Book.Queries.BookList
{
  public class GetBookListQueryHandler
    : IRequestHandler<GetBookListQuery, ICollection<BookListItemDto>>
  {
    private readonly IBookRepository _bookRepository;
    public GetBookListQueryHandler(IBookRepository bookRepository)
    {
      _bookRepository = bookRepository;
    }
    public async Task<ICollection<BookListItemDto>> Handle(
      GetBookListQuery request,
      CancellationToken cancellationToken)
    {
      return await _bookRepository.GetBookListItemsAsync();
    }
  }
}
