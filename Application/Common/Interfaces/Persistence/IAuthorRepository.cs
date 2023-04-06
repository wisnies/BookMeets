using Application.DTOs.Author;
using Domain.Entities.Author;

namespace Application.Common.Interfaces.Persistence
{
  public interface IAuthorRepository : IGenericRepository<Author>
  {
    Task<Author> GetNoTrackingAsync(int id);
    Task<AuthorDto> GetAuthorDetailsAsync(int id);
    Task<IEnumerable<AuthorNoBooksDto>> GetAuthorNoBooksListAsync();
  }
}
