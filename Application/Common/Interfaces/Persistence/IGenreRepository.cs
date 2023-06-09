﻿using Application.DTOs.Genre;
using Domain.Entities.Genre;

namespace Application.Common.Interfaces.Persistence
{
  public interface IGenreRepository : IGenericRepository<Genre>
  {
    Task<bool> ExistsByTitleNoTrackingAsync(string title);
    Task<Genre> GetNoTrackingAsync(int id);

    Task<IEnumerable<GenreMinimalListItemDto>> GetMinimalListAsync(int after, int take);
    Task<GenreDto> GetGenreDetailsAsync(int id);
    Task<List<Genre>> GetSelectedGenresAsync(int[] genreIds);
  }
}
