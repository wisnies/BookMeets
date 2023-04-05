using FluentValidation;

namespace Application.Features.Genre.Commands.Delete
{
  public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommand>
  {
    public DeleteGenreCommandValidator()
    {
      RuleFor(c => c.Id).NotEmpty();
    }
  }
}
