using Application.DTOs.Book;
using Application.DTOs.Common;

namespace Application.DTOs.Author
{
  public class AuthorDto : BaseDto
  {
    public string FullName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public string ImagePublicId { get; set; } = null!;
    public IEnumerable<BookListItemDto> Books { get; set; }
  }
}
