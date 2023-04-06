using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Contracts.Author
{
  public class CreateAuthorRequest
  {
    [Required]
    public string FullName { get; set; } = null!;
    [Required]
    public string Description { get; set; } = null!;
    public IFormFile? Image { get; set; }
  }
}
