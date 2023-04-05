using Application.Common.Interfaces.Persistence;
using Application.DTOs.Genre;
using MediatR;

namespace Application.Features.Genre.Queries.List
{
  public class GetGenreMinimalListQueryHandler
    : IRequestHandler<GetGenreMinimalListQuery, IEnumerable<GenreMinimalListItemDto>>
  {

    private readonly IGenreRepository _genreRepository;

    public GetGenreMinimalListQueryHandler(IGenreRepository genreRepository)
    {
      _genreRepository = genreRepository;
    }

    public async Task<IEnumerable<GenreMinimalListItemDto>> Handle(
      GetGenreMinimalListQuery request,
      CancellationToken cancellationToken)
    {
      return await _genreRepository.GetMinimalListAsync();
    }
  }
}
