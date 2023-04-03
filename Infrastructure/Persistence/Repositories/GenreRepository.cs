using Application.Common.Interfaces.Persistence;
using Domain.Entities.Genre;

namespace Infrastructure.Persistence.Repositories
{
  public class GenreRepository : GenericRepository<Genre>, IGenreRepository
  {
    private readonly BookMeetsDbContext _context;

    public GenreRepository(BookMeetsDbContext context) : base(context)
    {
      _context = context;
    }
  }
}
