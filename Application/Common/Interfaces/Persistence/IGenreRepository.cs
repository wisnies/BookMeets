using Application.DTOs.Genre;
using Domain.Entities.Genre;

namespace Application.Common.Interfaces.Persistence
{
  public interface IGenreRepository : IGenericRepository<Genre>
  {
    Task<bool> ExistsByTitleNoTrackingAsync(string title);
    Task<Genre> GetNoTrackingAsync(int id);

    Task<IEnumerable<GenreMinimalListItemDto>> GetMinimalListAsync();
    Task<GenreDto> GetGenreDetailsAsync(int id);
  }
}
