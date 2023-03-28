using System.ComponentModel.DataAnnotations;

namespace Contracts.Authentication
{
  public class RegisterRequest
  {
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string ConfirmPassword { get; set; }
    [Required]
    public string UserName { get; set; }
  }
}
