using Application.DTOs.Author;
using Application.DTOs.Common;
using Application.DTOs.Genre;

namespace Application.DTOs.Book
{
  public class BookListItemDto : BaseDto
  {
    public string Title { get; set; }
    public string Description { get; set; }
    public string CoverImageUrl { get; set; }
    public ICollection<AuthorMinimalListItemDto> Authors { get; set; }
    public ICollection<GenreMinimalListItemDto> Genres { get; set; }
  }
}
