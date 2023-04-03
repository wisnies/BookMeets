using Application.Common.Interfaces.Persistence;
using Domain.Entities.Author;

namespace Infrastructure.Persistence.Repositories
{
  public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
  {
    private readonly BookMeetsDbContext _context;

    public AuthorRepository(BookMeetsDbContext context) : base(context)
    {
      _context = context;
    }
  }
}
