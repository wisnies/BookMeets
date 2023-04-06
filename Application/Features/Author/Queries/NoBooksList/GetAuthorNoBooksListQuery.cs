using Application.DTOs.Author;
using MediatR;

namespace Application.Features.Author.Queries.NoBooksList
{
  public class GetAuthorNoBooksListQuery : IRequest<IEnumerable<AuthorNoBooksDto>>
  {
  }
}
