namespace Application.Common.Interfaces.Authentication
{
  public interface ITokenGenerator
  {
    public string GenerateAccessToken(int id, string email);
    public string GenerateRefreshToken();
  }
}
