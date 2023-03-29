using Application.Common.Interfaces.Persistence;
using Domain.Entities.UserRefreshToken;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
  public class UserRefreshTokenRepository
    : GenericRepository<UserRefreshToken>, IUserRefreshTokenRepository
  {
    private readonly BookMeetsDbContext _context;

    public UserRefreshTokenRepository(BookMeetsDbContext context) : base(context)
    {
      _context = context;
    }

    public async Task<UserRefreshToken> GetRefreshTokenByTokenAsync(string refreshToken)
    {
      return await _context.UserRefreshTokens.FirstOrDefaultAsync(
        x => x.RefreshToken == refreshToken);
    }
  }
}
