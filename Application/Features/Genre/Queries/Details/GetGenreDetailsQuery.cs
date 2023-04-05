using Application.DTOs.Genre;
using ErrorOr;
using MediatR;

namespace Application.Features.Genre.Queries.Details
{
  public record GetGenreDetailsQuery(int Id) : IRequest<ErrorOr<GenreDto>>;
}
