namespace Contracts.Authentication
{
  public record RefreshTokenRequest(
  string ExpiredToken, string RefreshToken);
}
