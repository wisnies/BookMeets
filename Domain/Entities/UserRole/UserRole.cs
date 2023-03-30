using Domain.Common.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.UserRole
{
  public sealed class UserRole : BaseEntity
  {
    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public User.User User { get; set; }
    public string Role { get; set; }
  }
}
