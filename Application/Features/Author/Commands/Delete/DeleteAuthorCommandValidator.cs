using FluentValidation;

namespace Application.Features.Author.Commands.Delete
{
  public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
  {
    public DeleteAuthorCommandValidator()
    {
      RuleFor(c => c.Id).NotEmpty();
    }
  }
}
