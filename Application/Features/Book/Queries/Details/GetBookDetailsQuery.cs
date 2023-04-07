using Application.DTOs.Book;
using ErrorOr;
using MediatR;

namespace Application.Features.Book.Queries.Details
{
  public class GetBookDetailsQuery : IRequest<ErrorOr<BookDto>>
  {
    public int Id { get; set; }
  }
}
