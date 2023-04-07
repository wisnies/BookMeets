using Application.Common.Interfaces.Persistence;
using Application.DTOs.Book;
using MediatR;

namespace Application.Features.Book.Queries.BookList
{
  public class GetBookListQueryHandler
    : IRequestHandler<GetBookListQuery, BookListItemPaginatedResponseDto>
  {
    private readonly IBookRepository _bookRepository;
    public GetBookListQueryHandler(IBookRepository bookRepository)
    {
      _bookRepository = bookRepository;
    }
    public async Task<BookListItemPaginatedResponseDto> Handle(
      GetBookListQuery request,
      CancellationToken cancellationToken)
    {
      var books = await _bookRepository.GetBookListItemsAsync(request.After, request.Take);

      return new BookListItemPaginatedResponseDto()
      {
        HasMore = books.Count() < request.Take ? false : true,
        Data = books,
      };
    }
  }
}
