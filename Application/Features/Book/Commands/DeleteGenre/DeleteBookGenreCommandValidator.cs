using FluentValidation;

namespace Application.Features.Book.Commands.DeleteGenre
{
  public class DeleteBookGenreCommandValidator : AbstractValidator<DeleteBookGenreCommand>
  {
    public DeleteBookGenreCommandValidator()
    {
      RuleFor(c => c.Id).NotEmpty();
      RuleFor(c => c.GenreId).NotEmpty();
    }
  }
}
