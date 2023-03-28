using System.ComponentModel.DataAnnotations;

namespace Contracts.Authentication
{
  public class AuthRequest
  {
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
  }
}
