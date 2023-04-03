using Application.Common.Interfaces.Persistence;
using Domain.Entities.Book;

namespace Infrastructure.Persistence.Repositories
{
  public class BookRepository : GenericRepository<Book>, IBookRepository
  {
    private readonly BookMeetsDbContext _context;

    public BookRepository(BookMeetsDbContext context) : base(context)
    {
      _context = context;
    }
  }
}
