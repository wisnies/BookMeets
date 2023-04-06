using Application.Common.Interfaces.Persistence;
using Application.DTOs.Author;
using Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Application.Features.Author.Queries.Details
{
  public class GetAuthorDetailsQueryHandler
    : IRequestHandler<GetAuthorDetailsQuery, ErrorOr<AuthorDto>>
  {
    private readonly IAuthorRepository _authorRepository;

    public GetAuthorDetailsQueryHandler(IAuthorRepository authorRepository)
    {
      _authorRepository = authorRepository;
    }

    public async Task<ErrorOr<AuthorDto>> Handle(
      GetAuthorDetailsQuery request,
      CancellationToken cancellationToken)
    {
      if (await _authorRepository.GetAuthorDetailsAsync(request.Id) is not AuthorDto dbAuthor)
      {
        return Errors.Author.NotFound;
      }

      return dbAuthor;
    }
  }
}
