using Application.Common.Interfaces.Persistence;
using Application.DTOs.Genre;
using Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Application.Features.Genre.Queries.Details
{
  public class GetGenreDetailsQueryHandler
    : IRequestHandler<GetGenreDetailsQuery, ErrorOr<GenreDto>>
  {

    private readonly IGenreRepository _genreRepository;

    public GetGenreDetailsQueryHandler(IGenreRepository genreRepository)
    {
      _genreRepository = genreRepository;
    }

    public async Task<ErrorOr<GenreDto>> Handle(
      GetGenreDetailsQuery request,
      CancellationToken cancellationToken)
    {
      if (await _genreRepository.GetGenreDetailsAsync(request.Id) is not GenreDto dbGenre)
      {
        return Errors.Genre.NotFound;
      }
      return dbGenre;
    }
  }
}
