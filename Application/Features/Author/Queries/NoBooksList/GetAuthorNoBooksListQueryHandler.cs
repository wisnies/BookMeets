using Application.Common.Interfaces.Persistence;
using Application.DTOs.Author;
using MediatR;

namespace Application.Features.Author.Queries.NoBooksList
{
  public class GetAuthorNoBooksListQueryHandler
    : IRequestHandler<GetAuthorNoBooksListQuery, IEnumerable<AuthorNoBooksDto>>
  {

    private readonly IAuthorRepository _authorRepository;

    public GetAuthorNoBooksListQueryHandler(IAuthorRepository authorRepository)
    {
      _authorRepository = authorRepository;
    }

    public async Task<IEnumerable<AuthorNoBooksDto>> Handle(
      GetAuthorNoBooksListQuery request,
      CancellationToken cancellationToken)
    {
      return await _authorRepository.GetAuthorNoBooksListAsync();
    }
  }
}
