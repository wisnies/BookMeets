using Application.Common.Interfaces.Persistence;
using Application.DTOs.Book;
using Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Application.Features.Book.Queries.Details
{
  public class GetBookDetailsQueryHandler
    : IRequestHandler<GetBookDetailsQuery, ErrorOr<BookDto>>
  {
    private readonly IBookRepository _bookRepository;

    public GetBookDetailsQueryHandler(IBookRepository bookRepository)
    {
      _bookRepository = bookRepository;
    }

    public async Task<ErrorOr<BookDto>> Handle(
      GetBookDetailsQuery request,
      CancellationToken cancellationToken)
    {
      if (await _bookRepository.GetBookDetailsAsync(request.Id) is not BookDto dbBook)
      {
        return Errors.Book.NotFound;
      }
      return dbBook;
    }
  }
}
