using System.ComponentModel.DataAnnotations;

namespace Contracts.Authentication
{

  public class AuthResponse
  {
    [Required]
    public int UserId { get; set; }
    [Required]
    public string UserName { get; set; } = null!;
    [Required]
    public string AccessToken { get; set; } = null!;
    [Required]
    public string RefreshToken { get; set; } = null!;
  }

}
