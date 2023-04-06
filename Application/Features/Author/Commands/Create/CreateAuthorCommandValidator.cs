using FluentValidation;

namespace Application.Features.Author.Commands.Create
{
  public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
  {
    public CreateAuthorCommandValidator()
    {
      RuleFor(c => c.FullName).NotEmpty();
      RuleFor(c => c.Description).NotEmpty();
      RuleFor(c => c.ImageUrl).NotEmpty();
      RuleFor(c => c.ImagePublicId).NotEmpty();
    }
  }
}
