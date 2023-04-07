using FluentValidation;

namespace Application.Features.Book.Commands.Delete
{
  public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
  {
    public DeleteBookCommandValidator()
    {
      RuleFor(c => c.Id).NotEmpty();
    }
  }
}
