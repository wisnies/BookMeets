using Domain.Common.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.UserRefreshToken
{
  [Table("UserRefreshToken")]
  public class UserRefreshToken : BaseEntity
  {
    public string AccessToken { get; set; } = null!;
    public string RefreshToken { get; set; } = null!;
    public DateTime ExpirationDate { get; set; }
    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public virtual User.User User { get; set; }
    [NotMapped]
    public bool IsActive
    {
      get
      {
        return ExpirationDate > DateTime.UtcNow;
      }
    }
  }
}

