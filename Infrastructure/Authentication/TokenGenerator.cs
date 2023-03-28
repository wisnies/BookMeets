using Application.Common.Interfaces.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Authentication
{
  public class TokenGenerator : ITokenGenerator
  {
    private readonly JwtSettings _jwtSettings;

    public TokenGenerator(IOptions<JwtSettings> options)
    {
      _jwtSettings = options.Value;
    }

    public string GenerateAccessToken(string email)
    {

      var signingCredentials = new SigningCredentials(
        new SymmetricSecurityKey(
          Encoding.UTF8.GetBytes(_jwtSettings.Key)),
          SecurityAlgorithms.HmacSha256);

      var claims = new[]
      {
        new Claim(JwtRegisteredClaimNames.Sub, email),
      };

      var securityToken = new JwtSecurityToken(
        issuer: _jwtSettings.Issuer,
        audience: _jwtSettings.Audience,
        expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationTimeInMinutes),
        claims: claims,
        signingCredentials: signingCredentials);

      return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }

    public string GenerateRefreshToken()
    {
      var byteArray = new byte[64];
      using (var cryptoProvider = new RNGCryptoServiceProvider())
      {
        cryptoProvider.GetBytes(byteArray);
        return Convert.ToBase64String(byteArray);
      }
    }
  }
}
