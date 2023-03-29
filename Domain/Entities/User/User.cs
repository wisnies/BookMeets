using Domain.Common.Models;

namespace Domain.Entities.User
{
  public class User : BaseEntity
  {
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string UserName { get; set; } = null!;
  }
}
