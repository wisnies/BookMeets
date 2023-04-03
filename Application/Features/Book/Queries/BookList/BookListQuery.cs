using Application.DTOs.Book;
using MediatR;

namespace Application.Features.Book.Queries.BookList
{
  public record BookListQuery() : IRequest<ICollection<BookListItemDto>>;
}
