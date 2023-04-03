using Domain.Common.Models;
using Domain.Entities.ManyToMany;

namespace Domain.Entities.Book
{
  public class Book : BaseEntity
  {
    public ICollection<BookAuthor> Authors { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string CoverType { get; set; }
    public string CoverImageUrl { get; set; }
    public string CoverImagePublicId { get; set; }
    public ICollection<BookGenre> Genres { get; set; }
    public int NumberOfPages { get; set; }
    public DateTime FirstPublished { get; set; }
  }
}
