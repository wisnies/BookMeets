using Application.Common.Interfaces.Persistence;
using Application.DTOs.Genre;
using MediatR;

namespace Application.Features.Genre.Queries.List
{
  public class GetGenreMinimalListQueryHandler
    : IRequestHandler<GetGenreMinimalListQuery, GenreMinimalListPagniatedResponseDto>
  {

    private readonly IGenreRepository _genreRepository;

    public GetGenreMinimalListQueryHandler(IGenreRepository genreRepository)
    {
      _genreRepository = genreRepository;
    }

    public async Task<GenreMinimalListPagniatedResponseDto> Handle(
      GetGenreMinimalListQuery request,
      CancellationToken cancellationToken)
    {
      var genres = await _genreRepository.GetMinimalListAsync(request.After, request.Take);
      return new GenreMinimalListPagniatedResponseDto()
      {
        HasMore = genres.Count() < request.Take ? false : true,
        Data = genres
      };
    }
  }
}
