using Application.Common.Interfaces.Persistence;
using Contracts.Common;
using Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Application.Features.Genre.Commands.Upsert
{
  public class UpsertGenreCommandHandler
    : IRequestHandler<UpsertGenreCommand, ErrorOr<BaseCommandResponse>>
  {
    private readonly IGenreRepository _genreRepository;

    public UpsertGenreCommandHandler(IGenreRepository genreRepository)
    {
      _genreRepository = genreRepository;
    }

    public async Task<ErrorOr<BaseCommandResponse>> Handle(
      UpsertGenreCommand request,
      CancellationToken cancellationToken)
    {

      if (await _genreRepository.GetNoTrackingAsync(request.Id) is not Domain.Entities.Genre.Genre existingGenre)
      {

        var newGenre = new Domain.Entities.Genre.Genre()
        {
          Title = request.Title.ToLower(),
          Description = request.Description
        };

        var dbGenre = await _genreRepository.AddAsync(newGenre);

        return new BaseCommandResponse()
        {
          Id = dbGenre.Id,
          Message = "Genre " + dbGenre.Title + " created successfully."
        };
      }
      else
      {

        if (await _genreRepository.ExistsByTitleNoTrackingAsync(request.Title.ToLower()))
        {
          return Errors.Genre.DuplicateTitle;
        }

        var genre = new Domain.Entities.Genre.Genre()
        {
          Id = request.Id,
          Title = request.Title.ToLower(),
          Description = request.Description,
          DateCreated = existingGenre.DateCreated
        };

        await _genreRepository.UpdateAsync(genre);

        return new BaseCommandResponse()
        {
          Id = genre.Id,
          Message = "Genre " + genre.Title + " updated successfully."
        };
      }
    }
  }
}
