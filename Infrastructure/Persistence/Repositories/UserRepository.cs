using Application.Common.Interfaces.Persistence;
using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
  public class UserRepository : GenericRepository<User>, IUserRepository
  {
    private readonly BookMeetsDbContext _context;

    public UserRepository(BookMeetsDbContext context) : base(context)
    {
      _context = context;
    }


    public async Task<User> GetUserByEmailAsync(string email)
    {
      return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

    }
  }
}
