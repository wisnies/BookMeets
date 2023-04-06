using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Contracts.Author
{
  public class UpsertAuthorRequest
  {
    [Required]
    public string FullName { get; set; } = null!;
    [Required]
    public string Description { get; set; } = null!;
    [Required]
    public string ImageUrl { get; set; } = null!;
    [Required]
    public string ImagePublicId { get; set; } = null!;
    public IFormFile? Image { get; set; }
  }
}
