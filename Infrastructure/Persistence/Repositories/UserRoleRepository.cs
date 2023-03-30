using Application.Common.Interfaces.Persistence;
using Domain.Entities.UserRole;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
  public class UserRoleRepository
    : GenericRepository<UserRole>, IUserRoleRepository
  {
    private readonly BookMeetsDbContext _context;

    public UserRoleRepository(BookMeetsDbContext context) : base(context)
    {
      _context = context;
    }

    public async Task<UserRole> GetUserRoleByUserIdAsync(int userId)
    {
      return await _context.UserRoles.FirstOrDefaultAsync(x => x.UserId == userId);
    }
  }
}
