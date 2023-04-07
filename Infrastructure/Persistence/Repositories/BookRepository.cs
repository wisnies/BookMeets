using Application.Common.Interfaces.Persistence;
using Application.DTOs.Author;
using Application.DTOs.Book;
using Application.DTOs.Genre;
using AutoMapper;
using Domain.Entities.Book;
using Domain.Entities.ManyToMany;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
  public class BookRepository : GenericRepository<Book>, IBookRepository
  {
    private readonly BookMeetsDbContext _context;
    private readonly IMapper _mapper;

    public BookRepository(BookMeetsDbContext context, IMapper mapper) : base(context)
    {
      _context = context;
      _mapper = mapper;
    }

    public async Task<BookDto> GetBookDetailsAsync(int id)
    {
      return await _context.Books.Select(e => new BookDto()
      {
        Id = e.Id,
        Title = e.Title,
        Description = e.Description,
        CoverImageUrl = e.CoverImageUrl,
        CoverImagePublicId = e.CoverImagePublicId,
        CoverType = e.CoverType,
        FirstPublished = e.FirstPublished,
        NumberOfPages = e.NumberOfPages,
        Authors = e.Authors
        .Where(ba => ba.BookId == id)
        .Select(ba => _mapper.Map<AuthorNoBooksDto>(ba.Author))
        .ToList(),
        Genres = e.Genres
        .Where(bg => bg.BookId == id)
        .Select(bg => _mapper.Map<GenreMinimalListItemDto>(bg.Genre))
        .ToList()
      }).FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<ICollection<BookListItemDto>> GetBookListItemsAsync(int after, int take)
    {
      return await _context.Books
        .OrderBy(e => e.Id)
        .Where(e => e.Id > after)
        .Take(take)
        .Select(b => new BookListItemDto()
        {
          Id = b.Id,
          Title = b.Title,
          CoverImageUrl = b.CoverImageUrl,
          Authors =
          b.Authors
          .Where(ba => ba.BookId == b.Id)
          .Select(ba => _mapper.Map<AuthorMinimalListItemDto>(ba.Author)).ToList(),
          Genres =
          b.Genres
          .Where(bg => bg.BookId == b.Id)
          .Select(bg => _mapper.Map<GenreMinimalListItemDto>(bg.Genre)).ToList()
        }).ToListAsync();
    }

    public async Task<Book> GetNoTrackingAsync(int id)
    {
      return await _context.Books.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<bool> AddBookAuthorsAsync(List<BookAuthor> bookAuthors)
    {
      try
      {
        await _context.BookAuthors.AddRangeAsync(bookAuthors);
        await _context.SaveChangesAsync();
        return true;
      }
      catch
      {
        return false;
      }
    }


    public async Task<bool> AddBookGenresAsync(List<BookGenre> bookGenres)
    {
      try
      {
        await _context.BookGenres.AddRangeAsync(bookGenres);
        await _context.SaveChangesAsync();
        return true;
      }
      catch
      {
        return false;
      }
    }

    public async Task<bool> DeleteBookAuthorAsync(BookAuthor bookGenre)
    {
      try
      {
        _context.BookAuthors.Remove(bookGenre);
        await _context.SaveChangesAsync();
        return true;
      }
      catch
      {
        return false;
      }
    }

    public async Task<bool> DeleteBookGenreAsync(BookGenre bookGenre)
    {
      try
      {
        _context.BookGenres.Remove(bookGenre);
        await _context.SaveChangesAsync();
        return true;
      }
      catch
      {
        return false;
      }
    }
  }
}
