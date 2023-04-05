using System.ComponentModel.DataAnnotations;

namespace Contracts.Genre
{
  public class CreateGenreRequest
  {
    [Required]
    public string Title { get; set; } = null!;
    [Required]
    public string Description { get; set; } = null!;
  }

}
