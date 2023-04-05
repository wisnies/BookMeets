using System.ComponentModel.DataAnnotations;

namespace Contracts.Authentication
{
  public class RefreshTokenRequest
  {
    [Required]
    public string ExpiredToken { get; set; } = null!;
    [Required]
    public string RefreshToken { get; set; } = null!;
  }
}
