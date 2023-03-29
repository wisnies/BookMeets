namespace Application.Common.Interfaces.Authentication
{
  public interface IPasswordService
  {
    public string GenerateHash(string password);
    public bool VerifyHashedPassword(string password, string hash);
  }
}
