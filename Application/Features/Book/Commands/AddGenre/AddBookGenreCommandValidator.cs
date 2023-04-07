using FluentValidation;

namespace Application.Features.Book.Commands.AddGenre
{
  public class AddBookGenreCommandValidator : AbstractValidator<AddBookGenreCommand>
  {
    public AddBookGenreCommandValidator()
    {
      RuleFor(c => c.Id).NotEmpty();
      RuleFor(c => c.GenreId).NotEmpty();
    }
  }
}
