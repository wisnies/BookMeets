using Domain.Entities.UserRefreshToken;

namespace Application.Common.Interfaces.Persistence
{
  public interface IUserRefreshTokenRepository : IGenericRepository<UserRefreshToken>
  {
    public Task<UserRefreshToken> GetRefreshTokenByTokenAsync(string refreshToken);
  }
}
