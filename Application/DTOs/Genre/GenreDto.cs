using Application.DTOs.Book;
using Application.DTOs.Common;

namespace Application.DTOs.Genre
{
  public class GenreDto : BaseDto
  {
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public IEnumerable<BookListItemDto> Books { get; set; }
  }
}
