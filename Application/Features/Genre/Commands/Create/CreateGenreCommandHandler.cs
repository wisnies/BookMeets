using Application.Common.Interfaces.Persistence;
using Contracts.Common;
using Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Application.Features.Genre.Commands.Create
{
  public class CreateGenreCommandHandler
    : IRequestHandler<CreateGenreCommand, ErrorOr<BaseCommandResponse>>
  {
    private readonly IGenreRepository _genreRepository;

    public CreateGenreCommandHandler(IGenreRepository genreRepository)
    {
      _genreRepository = genreRepository;
    }

    public async Task<ErrorOr<BaseCommandResponse>> Handle(
      CreateGenreCommand request,
      CancellationToken cancellationToken)
    {
      if (await _genreRepository.ExistsByTitleNoTrackingAsync(request.Title.ToLower()))
      {
        return Errors.Genre.DuplicateTitle;
      }

      var newGenre = new Domain.Entities.Genre.Genre()
      {
        Title = request.Title.ToLower(),
        Description = request.Description,
      };

      var dbGenre = await _genreRepository.AddAsync(newGenre);

      return new BaseCommandResponse()
      {
        Id = dbGenre.Id,
        Message = "Genre " + dbGenre.Title + " created successfully."
      };

    }
  }
}
