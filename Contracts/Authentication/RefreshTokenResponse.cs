using System.ComponentModel.DataAnnotations;

namespace Contracts.Authentication
{
  public class RefreshTokenResponse
  {
    [Required]
    public string AccessToken { get; set; } = null!;
  }
}
