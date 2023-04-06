using Application.Common.Interfaces.Persistence;
using Contracts.Common;
using Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Application.Features.Author.Commands.Delete
{
  public class DeleteAuthorCommandHandler
    : IRequestHandler<DeleteAuthorCommand, ErrorOr<BaseCommandResponse>>
  {
    private readonly IAuthorRepository _authorRepository;

    public DeleteAuthorCommandHandler(IAuthorRepository authorRepository)
    {
      _authorRepository = authorRepository;
    }

    public async Task<ErrorOr<BaseCommandResponse>> Handle(
      DeleteAuthorCommand request,
      CancellationToken cancellationToken)
    {
      if (await _authorRepository.GetAsync(request.Id) is not Domain.Entities.Author.Author dbAuthor)
      {
        return Errors.Author.NotFound;
      }

      await _authorRepository.DeleteAsync(dbAuthor);

      return new BaseCommandResponse()
      {
        Id = dbAuthor.Id,
        Message = "Author " + dbAuthor.FullName + " deleted successfully.",
      };
    }
  }
}
