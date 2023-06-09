﻿using Application.Common.Interfaces.Persistence;
using Application.DTOs.Author;
using Application.DTOs.Book;
using Application.DTOs.Genre;
using AutoMapper;
using Domain.Entities.Genre;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
  public class GenreRepository : GenericRepository<Genre>, IGenreRepository
  {
    private readonly BookMeetsDbContext _context;
    private readonly IMapper _mapper;

    public GenreRepository(BookMeetsDbContext context, IMapper mapper) : base(context)
    {
      _context = context;
      _mapper = mapper;
    }

    public async Task<bool> ExistsByTitleNoTrackingAsync(string title)
    {
      var entity = await _context.Genres.AsNoTracking().FirstOrDefaultAsync(e => e.Title == title);
      return entity != null;
    }

    public async Task<GenreDto> GetGenreDetailsAsync(int id)
    {
      return await _context.Genres.Select(e => new GenreDto()
      {
        Id = e.Id,
        Title = e.Title,
        Description = e.Description,
        Books = e.Books
        .Where(bg => bg.GenreId == id)
        .Select(bg => new BookListItemDto()
        {
          Id = bg.Book.Id,
          Title = bg.Book.Title,
          Description = bg.Book.Description,
          Authors = bg.Book.Authors
          .Where(iba => iba.BookId == bg.BookId)
          .Select(iba => _mapper.Map<AuthorMinimalListItemDto>(iba.Author)).ToList(),
          Genres =
          bg.Book.Genres
          .Where(ibg => ibg.BookId == bg.BookId)
          .Select(ibg => _mapper.Map<GenreMinimalListItemDto>(ibg.Genre)).ToList()
        }).ToList(),

      }).FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<IEnumerable<GenreMinimalListItemDto>> GetMinimalListAsync(int after, int take)
    {
      return await _context.Genres
        .OrderBy(e => e.Id)
        .Where(e => e.Id > after)
        .Take(take)
        .Select(e => _mapper.Map<GenreMinimalListItemDto>(e)).ToListAsync();
    }

    public async Task<Genre> GetNoTrackingAsync(int id)
    {
      return await _context.Genres.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<List<Genre>> GetSelectedGenresAsync(int[] genreIds)
    {
      return await _context.Genres.Where(e => genreIds.Contains(e.Id)).ToListAsync();
    }
  }
}
