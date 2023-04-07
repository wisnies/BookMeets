using Application.DTOs.Book;
using Domain.Entities.Book;
using Domain.Entities.ManyToMany;

namespace Application.Common.Interfaces.Persistence
{
  public interface IBookRepository : IGenericRepository<Book>
  {
    Task<Book> GetNoTrackingAsync(int id);
    Task<BookDto> GetBookDetailsAsync(int id);
    Task<ICollection<BookListItemDto>> GetBookListItemsAsync(int after, int take);
    Task<bool> AddBookAuthorsAsync(List<BookAuthor> bookAuthors);
    Task<bool> AddBookGenresAsync(List<BookGenre> bookGenres);
    Task<bool> DeleteBookAuthorAsync(BookAuthor bookGenre);
    Task<bool> DeleteBookGenreAsync(BookGenre bookGenre);
  }
}
