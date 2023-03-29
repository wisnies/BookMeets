using Application.DTOs.Common;

namespace Application.DTOs.Authentication
{
  public class AuthResultDto : BaseDto
  {
    public int UserId { get; set; }
    public string AccessToken { get; set; }
  }
}
