using System.ComponentModel.DataAnnotations;

namespace Contracts.Authentication
{
  public class LogoutRequest
  {
    [Required]
    public string RefreshToken { get; set; } = null!;
  }

}
