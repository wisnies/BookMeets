using Application.DTOs.Author;
using Application.DTOs.Common;
using Application.DTOs.Genre;

namespace Application.DTOs.Book
{
  public class BookDto : BaseDto
  {
    public ICollection<AuthorNoBooksDto> Authors { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string CoverType { get; set; }
    public string CoverImageUrl { get; set; }
    public string CoverImagePublicId { get; set; }
    public ICollection<GenreNoBooksDto> Genres { get; set; }
    public int NumberOfPages { get; set; }
    public DateTime FirstPublished { get; set; }
  }
}
