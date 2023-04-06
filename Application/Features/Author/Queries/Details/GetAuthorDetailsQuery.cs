using Application.DTOs.Author;
using ErrorOr;
using MediatR;

namespace Application.Features.Author.Queries.Details
{
  public class GetAuthorDetailsQuery : IRequest<ErrorOr<AuthorDto>>
  {
    public int Id { get; set; }
  }
}
