using Domain.Entities.UserRole;

namespace Application.Common.Interfaces.Persistence
{
  public interface IUserRoleRepository : IGenericRepository<UserRole>
  {
    Task<UserRole> GetUserRoleByUserIdAsync(int userId);
  }
}
