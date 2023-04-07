using Application.Common.Interfaces.Persistence;
using Application.DTOs.Author;
using Application.DTOs.Book;
using Application.DTOs.Genre;
using AutoMapper;
using Domain.Entities.Author;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
  public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
  {
    private readonly BookMeetsDbContext _context;
    private readonly IMapper _mapper;

    public AuthorRepository(BookMeetsDbContext context, IMapper mapper) : base(context)
    {
      _context = context;
      _mapper = mapper;
    }

    public async Task<AuthorDto> GetAuthorDetailsAsync(int id)
    {
      return await _context.Authors.Select(e => new AuthorDto()
      {
        Id = e.Id,
        FullName = e.FullName,
        Description = e.Description,
        ImageUrl = e.ImageUrl,
        ImagePublicId = e.ImagePublicId,
        Books = e.Books
        .Where(ba => ba.AuthorId == id)
        .Select(ba => new BookListItemDto()
        {
          Id = ba.Book.Id,
          Title = ba.Book.Title,
          Description = ba.Book.Description,
          Authors = ba.Book.Authors
          .Where(iba => iba.BookId == ba.BookId)
          .Select(iba => _mapper.Map<AuthorMinimalListItemDto>(ba.Author)).ToList(),
          Genres =
          ba.Book.Genres
          .Where(ibg => ibg.BookId == ba.BookId)
          .Select(ibg => _mapper.Map<GenreMinimalListItemDto>(ibg.Genre)).ToList()
        }).ToList(),

      }).FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<IEnumerable<AuthorNoBooksDto>> GetAuthorNoBooksListAsync()
    {
      return await _context.Authors.Select(e => _mapper.Map<AuthorNoBooksDto>(e)).ToListAsync();
    }

    public async Task<Author> GetNoTrackingAsync(int id)
    {
      return await _context.Authors.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<List<Author>> GetSelectedAuthorsAsync(int[] authorIds)
    {
      return await _context.Authors.Where(e => authorIds.Contains(e.Id)).ToListAsync();
    }
  }
}
