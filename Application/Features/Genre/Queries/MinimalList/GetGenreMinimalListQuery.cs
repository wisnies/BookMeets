using Application.DTOs.Genre;
using MediatR;

namespace Application.Features.Genre.Queries.List
{
  public record GetGenreMinimalListQuery : IRequest<IEnumerable<GenreMinimalListItemDto>>;
}
