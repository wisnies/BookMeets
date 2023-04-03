using Application.DTOs.Book;
using Domain.Entities.Book;

namespace Application.Common.Interfaces.Persistence
{
  public interface IBookRepository : IGenericRepository<Book>
  {

    Task<ICollection<BookListItemDto>> GetBookListItems();
  }
}
