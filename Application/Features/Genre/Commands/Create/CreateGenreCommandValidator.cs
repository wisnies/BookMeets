using FluentValidation;

namespace Application.Features.Genre.Commands.Create
{
  public class CreateGenreCommandValidator
    : AbstractValidator<CreateGenreCommand>
  {
    public CreateGenreCommandValidator()
    {
      RuleFor(c => c.Title).NotEmpty();
      RuleFor(c => c.Description).NotEmpty();
    }
  }
}
