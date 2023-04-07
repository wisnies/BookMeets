using Application.Common.Interfaces.Persistence;
using Application.DTOs.Author;
using MediatR;

namespace Application.Features.Author.Queries.NoBooksList
{
  public class GetAuthorNoBooksListQueryHandler
    : IRequestHandler<GetAuthorNoBooksListQuery, AuthorNoBooksPaginatedResponseDto>
  {

    private readonly IAuthorRepository _authorRepository;

    public GetAuthorNoBooksListQueryHandler(IAuthorRepository authorRepository)
    {
      _authorRepository = authorRepository;
    }

    public async Task<AuthorNoBooksPaginatedResponseDto> Handle(
      GetAuthorNoBooksListQuery request,
      CancellationToken cancellationToken)
    {
      var authors = await _authorRepository.GetAuthorNoBooksListAsync(request.After, request.Take);
      return new AuthorNoBooksPaginatedResponseDto()
      {
        HasMore = authors.Count() < request.Take ? false : true,
        Data = authors
      };
    }
  }
}
