using Application.DTOs.Book;
using MediatR;

namespace Application.Features.Book.Queries.BookList
{
  public record GetBookListQuery() : IRequest<ICollection<BookListItemDto>>;
}
