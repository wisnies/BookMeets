using Application.DTOs.Common;

namespace Application.DTOs.Author
{
  public class AuthorNoBooksDto : BaseDto
  {
    public string FullName { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public string ImagePublicId { get; set; }
  }
}
