using Domain.Entities.User;

namespace Application.Common.Interfaces.Persistence
{
  public interface IUserRepository : IGenericRepository<User>
  {
    public Task<User> GetUserByEmailAsync(string email);
  }
}
