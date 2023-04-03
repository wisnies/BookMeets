using Domain.Common.Models;
using Domain.Entities.ManyToMany;

namespace Domain.Entities.Genre
{
  public class Genre : BaseEntity
  {
    public string Title { get; set; }
    public string Description { get; set; }
    public ICollection<BookGenre> Books { get; set; }
  }
}
