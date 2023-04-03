using Application.DTOs.Author;
using Application.DTOs.Book;
using Application.DTOs.Genre;
using Application.Features.Auth.Commands.Login;
using Application.Features.Auth.Commands.Logout;
using Application.Features.Auth.Commands.RefreshToken;
using Application.Features.Auth.Commands.Register;
using AutoMapper;
using Contracts.Authentication;
using Domain.Entities.Author;
using Domain.Entities.Book;
using Domain.Entities.Genre;

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

      CreateMap<Book, BookListItemDto>();
      CreateMap<Book, BookDto>();
      CreateMap<Author, AuthorMinimalListItemDto>();
      CreateMap<Author, AuthorNoBooksDto>();
      CreateMap<Genre, GenreMinimalListItemDto>();
      CreateMap<Genre, GenreNoBooksDto>();
    }
  }
}
