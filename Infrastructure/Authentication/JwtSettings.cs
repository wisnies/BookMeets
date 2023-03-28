﻿namespace Infrastructure.Authentication
{
  public class JwtSettings
  {
    public const string SectionName = "JwtSettings";
    public string Key { get; init; } = null!;
    public int ExpirationTimeInMinutes { get; init; }
    public string Issuer { get; init; } = null!;
    public string Audience { get; init; } = null!;
  }
}
