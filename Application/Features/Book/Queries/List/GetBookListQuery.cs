using Application.DTOs.Book;
using MediatR;

namespace Application.Features.Book.Queries.BookList
{
  public class GetBookListQuery : IRequest<BookListItemPaginatedResponseDto>
  {
    public int After { get; set; }
    public int Take { get; set; }
  };
}
