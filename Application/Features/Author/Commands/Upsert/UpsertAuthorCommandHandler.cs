using Application.Common.Interfaces.Persistence;
using Contracts.Common;
using ErrorOr;
using MediatR;

namespace Application.Features.Author.Commands.Upsert
{
  public class UpsertAuthorCommandHandler
    : IRequestHandler<UpsertAuthorCommand, ErrorOr<BaseCommandResponse>>
  {
    private readonly IAuthorRepository _authorRepository;

    public UpsertAuthorCommandHandler(IAuthorRepository authorRepository)
    {
      _authorRepository = authorRepository;
    }
    public async Task<ErrorOr<BaseCommandResponse>> Handle(
      UpsertAuthorCommand request,
      CancellationToken cancellationToken)
    {
      if (await _authorRepository.GetNoTrackingAsync(request.Id) is not Domain.Entities.Author.Author existingAuthor)
      {

        var newGenre = new Domain.Entities.Author.Author()
        {
          FullName = request.FullName,
          Description = request.Description,
          ImageUrl = request.ImageUrl,
          ImagePublicId = request.ImagePublicId,
        };

        var dbAuthor = await _authorRepository.AddAsync(newGenre);

        return new BaseCommandResponse()
        {
          Id = dbAuthor.Id,
          Message = "Author " + dbAuthor.FullName + " created successfully."
        };
      }
      else
      {

        var author = new Domain.Entities.Author.Author()
        {
          Id = request.Id,
          FullName = request.FullName,
          Description = request.Description,
          ImageUrl = request.ImageUrl,
          ImagePublicId = request.ImagePublicId,
          DateCreated = existingAuthor.DateCreated
        };

        await _authorRepository.UpdateAsync(author);

        return new BaseCommandResponse()
        {
          Id = author.Id,
          Message = "Author " + author.FullName + " updated successfully."
        };
      }
    }
  }
}
