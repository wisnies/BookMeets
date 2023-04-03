using Application.DTOs.Common;

namespace Application.DTOs.Book
{
  public class BookListDto : BaseDto
  {
    public string Title { get; set; }
    public string CoverImageUrl { get; set; }
  }
}
