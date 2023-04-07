using Contracts.Common;
using ErrorOr;
using MediatR;

namespace Application.Features.Book.Commands.DeleteGenre
{
  public class DeleteBookGenreCommand : IRequest<ErrorOr<BaseCommandResponse>>
  {
    public int Id { get; set; }
    public int GenreId { get; set; }
  }
}
