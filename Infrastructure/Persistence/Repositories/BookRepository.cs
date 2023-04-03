using Application.Common.Interfaces.Persistence;
using Application.DTOs.Author;
using Application.DTOs.Book;
using Application.DTOs.Genre;
using AutoMapper;
using Domain.Entities.Book;
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

    public async Task<ICollection<BookListItemDto>> GetBookListItems()
    {
      return await _context.Books.Select(b => new BookListItemDto()
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
  }
}
