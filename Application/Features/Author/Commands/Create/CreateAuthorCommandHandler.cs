using Application.Common.Interfaces.Persistence;
using Contracts.Common;
using ErrorOr;
using MediatR;

namespace Application.Features.Author.Commands.Create
{
  public class CreateAuthorCommandHandler
    : IRequestHandler<CreateAuthorCommand, ErrorOr<BaseCommandResponse>>
  {
    private readonly IAuthorRepository _authorRepository;

    public CreateAuthorCommandHandler(IAuthorRepository authorRepository)
    {
      _authorRepository = authorRepository;
    }

    public async Task<ErrorOr<BaseCommandResponse>> Handle(
      CreateAuthorCommand request,
      CancellationToken cancellationToken)
    {
      var newAuthor = new Domain.Entities.Author.Author()
      {
        FullName = request.FullName,
        Description = request.Description,
        ImageUrl = request.ImageUrl,
        ImagePublicId = request.ImagePublicId,
      };
      var dbAuthor = await _authorRepository.AddAsync(newAuthor);

      return new BaseCommandResponse()
      {
        Id = dbAuthor.Id,
        Message = "Author " + dbAuthor.FullName + " successfully created."
      };
    }
  }
}
