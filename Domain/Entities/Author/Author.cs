using Domain.Common.Models;
using Domain.Entities.ManyToMany;

namespace Domain.Entities.Author
{
  public class Author : BaseEntity
  {
    public string FullName { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public string ImagePublicId { get; set; }
    public ICollection<BookAuthor> Books { get; set; }
  }
}
