using Application.Common.Interfaces.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;

namespace Infrastructure.Authentication
{
  public class PasswordService : IPasswordService
  {
    private readonly BcryptSettings _bcryptSettings;

    public PasswordService(IOptions<BcryptSettings> options)
    {
      _bcryptSettings = options.Value;
    }

    public string GenerateHash(string password)
    {
      byte[] bytes = RandomNumberGenerator.GetBytes(_bcryptSettings.KeySize);
      int salt = BitConverter.ToInt32(bytes);
      return BCrypt.Net.BCrypt.HashPassword(password, 10);
    }

    public bool VerifyHashedPassword(string password, string hash)
    {
      return BCrypt.Net.BCrypt.Verify(password, hash);
    }
  }
}
