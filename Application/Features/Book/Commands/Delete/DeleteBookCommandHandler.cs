using Application.Common.Interfaces.Persistence;
using Contracts.Common;
using Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Application.Features.Book.Commands.Delete
{
  public class DeleteBookCommandHandler
    : IRequestHandler<DeleteBookCommand, ErrorOr<BaseCommandResponse>>
  {
    private readonly IBookRepository _bookRepository;

    public DeleteBookCommandHandler(IBookRepository bookRepository)
    {
      _bookRepository = bookRepository;
    }

    public async Task<ErrorOr<BaseCommandResponse>> Handle(
      DeleteBookCommand request,
      CancellationToken cancellationToken)
    {
      if (await _bookRepository.GetAsync(request.Id) is not Domain.Entities.Book.Book dbBook)
      {
        return Errors.Book.NotFound;
      }

      await _bookRepository.DeleteAsync(dbBook);

      return new BaseCommandResponse()
      {
        Id = dbBook.Id,
        Message = "Book " + dbBook.Title + " deleted successfully"
      };
    }
  }
}
