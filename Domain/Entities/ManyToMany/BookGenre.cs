using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.ManyToMany
{
  public class BookGenre
  {
    public int BookId { get; set; }
    public int GenreId { get; set; }
    [ForeignKey("BookId")]
    public Book.Book Book { get; set; }
    [ForeignKey("GenreId")]
    public Genre.Genre Genre { get; set; }
  }
}
