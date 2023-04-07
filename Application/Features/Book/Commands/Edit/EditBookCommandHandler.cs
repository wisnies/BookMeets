using Application.Common.Interfaces.Persistence;
using Contracts.Common;
using Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Application.Features.Book.Commands.Edit
{
  public class EditBookCommandHandler
    : IRequestHandler<EditBookCommand, ErrorOr<BaseCommandResponse>>
  {
    private readonly IBookRepository _bookRepository;

    public EditBookCommandHandler(IBookRepository bookRepository)
    {
      _bookRepository = bookRepository;
    }

    public async Task<ErrorOr<BaseCommandResponse>> Handle(
      EditBookCommand request,
      CancellationToken cancellationToken)
    {
      if (await _bookRepository.GetNoTrackingAsync(request.Id) is not Domain.Entities.Book.Book existingBook)
      {
        return Errors.Book.NotFound;
      }

      var newBook = new Domain.Entities.Book.Book()
      {
        Id = request.Id,
        Title = request.Title,
        Description = request.Description,
        CoverType = request.CoverType,
        CoverImageUrl = request.CoverImageUrl,
        CoverImagePublicId = request.CoverImagePublicId,
        FirstPublished = request.FirstPublished,
        NumberOfPages = request.NumberOfPages,
        DateCreated = existingBook.DateCreated,
      };

      await _bookRepository.UpdateAsync(newBook);

      return new BaseCommandResponse()
      {
        Id = request.Id,
        Message = "Book " + newBook.Title + " updated successfully."
      };
    }
  }
}
