using Contracts.Common;
using ErrorOr;
using MediatR;

namespace Application.Features.Book.Commands.Edit
{
  public class EditBookCommand : IRequest<ErrorOr<BaseCommandResponse>>
  {
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string CoverType { get; set; } = null!;
    public string CoverImageUrl { get; set; } = null!;
    public string CoverImagePublicId { get; set; } = null!;
    public int NumberOfPages { get; set; }
    public DateTime FirstPublished { get; set; }
  }
}
