using Application.DTOs.Author;
using MediatR;

namespace Application.Features.Author.Queries.NoBooksList
{
  public class GetAuthorNoBooksListQuery : IRequest<AuthorNoBooksPaginatedResponseDto>
  {
    public int After { get; set; }
    public int Take { get; set; }
  }
}
