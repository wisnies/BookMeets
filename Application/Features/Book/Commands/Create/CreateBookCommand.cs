using Contracts.Common;
using ErrorOr;
using MediatR;

namespace Application.Features.Book.Commands.Create
{
  public class CreateBookCommand : IRequest<ErrorOr<BaseCommandResponse>>
  {
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string CoverType { get; set; } = null!;
    public int NumberOfPages { get; set; }
    public DateTime FirstPublished { get; set; }
    public string CoverImageUrl { get; set; } = null!;
    public string CoverImagePublicId { get; set; } = null!;
    public int[] GenreIds { get; set; }
    public int[] AuthorIds { get; set; }
  }
}
