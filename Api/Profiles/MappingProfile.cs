﻿using Application.DTOs.Author;
using Application.DTOs.Book;
using Application.DTOs.Genre;
using Application.Features.Auth.Commands.Login;
using Application.Features.Auth.Commands.Logout;
using Application.Features.Auth.Commands.RefreshToken;
using Application.Features.Auth.Commands.Register;
using Application.Features.Author.Commands.Create;
using Application.Features.Author.Commands.Upsert;
using Application.Features.Author.Queries.NoBooksList;
using Application.Features.Book.Commands.Create;
using Application.Features.Book.Commands.Edit;
using Application.Features.Book.Queries.BookList;
using Application.Features.Genre.Commands.Create;
using Application.Features.Genre.Commands.Delete;
using Application.Features.Genre.Commands.Upsert;
using Application.Features.Genre.Queries.List;
using AutoMapper;
using Contracts.Authentication;
using Contracts.Author;
using Contracts.Book;
using Contracts.Genre;
using Domain.Entities.Author;
using Domain.Entities.Book;
using Domain.Entities.Genre;

namespace Api.Profiles
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      // AUTH PROFILES
      CreateMap<RegisterRequest, RegisterCommand>();
      CreateMap<LoginRequest, LoginCommand>();
      CreateMap<LogoutRequest, LogoutCommand>();
      CreateMap<RefreshTokenRequest, RefreshTokenCommand>();

      // AUTHOR PROFILES
      CreateMap<Author, AuthorMinimalListItemDto>();
      CreateMap<Author, AuthorNoBooksDto>();
      CreateMap<GetAuthorNoBooksListRequest, GetAuthorNoBooksListQuery>();
      CreateMap<(CreateAuthorRequest, string imageUrl, string imagePublicId), CreateAuthorCommand>()
        .ForMember(d => d.FullName, opt => opt.MapFrom(src => src.Item1.FullName))
        .ForMember(d => d.Description, opt => opt.MapFrom(src => src.Item1.Description))
        .ForMember(d => d.ImageUrl, opt => opt.MapFrom(src => src.imageUrl))
        .ForMember(d => d.ImagePublicId, opt => opt.MapFrom(src => src.imagePublicId));
      CreateMap<(UpsertAuthorRequest, string imageUrl, string imagePublicId, int authorId), UpsertAuthorCommand>()
        .ForMember(d => d.FullName, opt => opt.MapFrom(src => src.Item1.FullName))
        .ForMember(d => d.Description, opt => opt.MapFrom(src => src.Item1.Description))
        .ForMember(d => d.ImageUrl, opt => opt.MapFrom(src => src.imageUrl))
        .ForMember(d => d.ImagePublicId, opt => opt.MapFrom(src => src.imagePublicId))
        .ForMember(d => d.Id, opt => opt.MapFrom(src => src.authorId));

      // BOOK PROFILES
      CreateMap<Book, BookListItemDto>();
      CreateMap<Book, BookDto>();
      CreateMap<GetBookListRequest, GetBookListQuery>();

      CreateMap<(CreateBookRequest, string imageUrl, string imagePublicId), CreateBookCommand>()
        .ForMember(d => d.Title, opt => opt.MapFrom(src => src.Item1.Title))
        .ForMember(d => d.Description, opt => opt.MapFrom(src => src.Item1.Description))
        .ForMember(d => d.CoverType, opt => opt.MapFrom(src => src.Item1.CoverType))
        .ForMember(d => d.NumberOfPages, opt => opt.MapFrom(src => src.Item1.NumberOfPages))
        .ForMember(d => d.FirstPublished, opt => opt.MapFrom(src => src.Item1.FirstPublished))
        .ForMember(d => d.AuthorIds, opt => opt.MapFrom(src => src.Item1.AuthorIds.Distinct()))
        .ForMember(d => d.GenreIds, opt => opt.MapFrom(src => src.Item1.GenreIds.Distinct()))
        .ForMember(d => d.CoverImageUrl, opt => opt.MapFrom(src => src.imageUrl))
        .ForMember(d => d.CoverImagePublicId, opt => opt.MapFrom(src => src.imagePublicId));

      CreateMap<(EditBookRequest, string imageUrl, string imagePublicId, int bookId), EditBookCommand>()
        .ForMember(d => d.Id, opt => opt.MapFrom(src => src.bookId))
        .ForMember(d => d.Title, opt => opt.MapFrom(src => src.Item1.Title))
        .ForMember(d => d.Description, opt => opt.MapFrom(src => src.Item1.Description))
        .ForMember(d => d.CoverType, opt => opt.MapFrom(src => src.Item1.CoverType))
        .ForMember(d => d.NumberOfPages, opt => opt.MapFrom(src => src.Item1.NumberOfPages))
        .ForMember(d => d.FirstPublished, opt => opt.MapFrom(src => src.Item1.FirstPublished))
        .ForMember(d => d.CoverImageUrl, opt => opt.MapFrom(src => src.imageUrl))
        .ForMember(d => d.CoverImagePublicId, opt => opt.MapFrom(src => src.imagePublicId));

      // GENRE PROFILES
      CreateMap<Genre, GenreMinimalListItemDto>();
      CreateMap<Genre, GenreNoBooksDto>();
      CreateMap<GetGenreMinimalListRequest, GetGenreMinimalListQuery>();
      CreateMap<CreateGenreRequest, CreateGenreCommand>();
      CreateMap<(UpsertGenreRequest, int genreId), UpsertGenreCommand>()
        .ForMember(d => d.Id, opt => opt.MapFrom(src => src.genreId))
        .ForMember(d => d.Title, opt => opt.MapFrom(src => src.Item1.Title))
        .ForMember(d => d.Description, opt => opt.MapFrom(src => src.Item1.Description));
      CreateMap<int, DeleteGenreCommand>();

    }
  }
}
