using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Services;
using Infrastructure.Authentication;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
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
      services.AddPersitence(configuration);
      services.AddServices(configuration);

      return services;
    }

    public static IServiceCollection AddAuth(
      this IServiceCollection services,
      ConfigurationManager configuration)
    {

      var bcryptSettings = new BcryptSettings();
      configuration.Bind(BcryptSettings.SectionName, bcryptSettings);
      services.AddSingleton(Options.Create(bcryptSettings));

      services.AddTransient<IPasswordService, PasswordService>();

      var jwtSettings = new JwtSettings();
      configuration.Bind(JwtSettings.SectionName, jwtSettings);
      services.AddSingleton(Options.Create(jwtSettings));

      services.AddTransient<ITokenGenerator, TokenGenerator>();

      TokenValidationParameters tokenValidationParameters
        = new TokenValidationParameters()
        {
          ValidateIssuer = false,
          ValidateAudience = false,
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

    public static IServiceCollection AddPersitence(
      this IServiceCollection services,
      ConfigurationManager configuration)
    {
      services.AddScoped<IUserRepository, UserRepository>();
      services.AddScoped<IUserRefreshTokenRepository, UserRefreshTokenRepository>();
      services.AddScoped<IUserRoleRepository, UserRoleRepository>();
      services.AddScoped<IBookRepository, BookRepository>();
      services.AddScoped<IAuthorRepository, AuthorRepository>();
      services.AddScoped<IGenreRepository, GenreRepository>();
      services.AddDbContext<BookMeetsDbContext>(options =>
      {
        options.UseSqlServer(
          configuration.GetConnectionString("BookMeetsConnection"), b => b.MigrationsAssembly("Api"));
      });
      return services;
    }

    public static IServiceCollection AddServices(
      this IServiceCollection services,
      ConfigurationManager configuration)
    {

      var cloudinarySettings = new CloudinarySettings();
      configuration.Bind(CloudinarySettings.SectionName, cloudinarySettings);
      services.AddSingleton(Options.Create(cloudinarySettings));

      services.AddScoped<ICloudinaryService, CloudinaryService>();

      return services;
    }
  }
}
