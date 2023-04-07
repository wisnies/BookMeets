using FluentValidation;

namespace Application.Features.Book.Commands.DeleteAuthor
{
  public class DeleteBookAuthorCommandValidator : AbstractValidator<DeleteBookAuthorCommand>
  {
    public DeleteBookAuthorCommandValidator()
    {
      RuleFor(c => c.Id).NotEmpty();
      RuleFor(c => c.AuthorId).NotEmpty();
    }
  }
}
