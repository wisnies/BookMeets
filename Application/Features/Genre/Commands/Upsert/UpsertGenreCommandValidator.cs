using FluentValidation;

namespace Application.Features.Genre.Commands.Upsert
{
  public class UpsertGenreCommandValidator
    : AbstractValidator<UpsertGenreCommand>
  {
    public UpsertGenreCommandValidator()
    {
      RuleFor(c => c.Id).NotEmpty();
      RuleFor(c => c.Title).NotEmpty();
      RuleFor(c => c.Description).NotEmpty();
    }
  }
}
