using Application.DTOs.Genre;
using MediatR;

namespace Application.Features.Genre.Queries.List
{
  public class GetGenreMinimalListQuery : IRequest<GenreMinimalListPagniatedResponseDto>
  {
    public int After { get; set; }
    public int Take { get; set; }
  }
}
