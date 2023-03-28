using Application.Common.Interfaces.Authentication;
using Infrastructure.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Infrastructure
{
  public static class InfrastructureServicesRegistration
  {
    public static IServiceCollection ConfigureInfrastructureServices(
      this IServiceCollection services,
      ConfigurationManager configuration)
    {
      services.AddAuth(configuration);

      return services;
    }

    public static IServiceCollection AddAuth(
      this IServiceCollection services,
      ConfigurationManager configuration)
    {
      //services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));


      var jwtSettings = new JwtSettings();
      configuration.Bind(JwtSettings.SectionName, jwtSettings);
      services.AddSingleton(Options.Create(jwtSettings));

      services.AddTransient<ITokenGenerator, TokenGenerator>();

      TokenValidationParameters tokenValidationParameters
        = new TokenValidationParameters()
        {
          ValidateIssuer = true,
          ValidateAudience = true,
          ValidateLifetime = true,
          ValidateIssuerSigningKey = true,
          ValidIssuer = jwtSettings.Issuer,
          ValidAudience = jwtSettings.Audience,
          ClockSkew = TimeSpan.Zero,
          IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),
        };

      services.AddAuthentication(authOptions =>
      {
        authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      }).AddJwtBearer(jwtOptions =>
      {
        jwtOptions.TokenValidationParameters = tokenValidationParameters;
      });
      return services;
    }
  }
}
