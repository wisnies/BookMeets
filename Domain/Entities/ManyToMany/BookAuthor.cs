using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.ManyToMany
{
  public class BookAuthor
  {
    public int BookId { get; set; }
    public int AuthorId { get; set; }
    [ForeignKey("BookId")]
    public Book.Book Book { get; set; }
    [ForeignKey("AuthorId")]
    public Author.Author Author { get; set; }
  }
}
