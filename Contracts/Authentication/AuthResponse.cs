namespace Contracts.Authentication
{
  public record AuthResponse(
    int UserId, string UserName, string AccessToken, string RefreshToken);
}
