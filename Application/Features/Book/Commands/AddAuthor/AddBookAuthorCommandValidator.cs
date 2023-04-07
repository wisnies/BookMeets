using FluentValidation;

namespace Application.Features.Book.Commands.AddAuthor
{
  public class AddBookAuthorCommandValidator : AbstractValidator<AddBookAuthorCommand>
  {
    public AddBookAuthorCommandValidator()
    {
      RuleFor(c => c.Id).NotEmpty();
      RuleFor(c => c.AuthorId).NotEmpty();
    }
  }
}
