using Application.Features.Auth.Commands.Login;
using Application.Features.Auth.Commands.Logout;
using Application.Features.Auth.Commands.RefreshToken;
using Application.Features.Auth.Commands.Register;
using AutoMapper;
using Contracts.Authentication;

namespace Api.Profiles
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<RegisterRequest, RegisterCommand>();
      CreateMap<LoginRequest, LoginCommand>();
      CreateMap<LogoutRequest, LogoutCommand>();
      CreateMap<RefreshTokenRequest, RefreshTokenCommand>();
    }
  }
}
