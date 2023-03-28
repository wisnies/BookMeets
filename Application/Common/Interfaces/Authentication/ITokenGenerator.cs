namespace Application.Common.Interfaces.Authentication
{
  public interface ITokenGenerator
  {
    public string GenerateAccessToken(string email);
    public string GenerateRefreshToken();
  }
}
