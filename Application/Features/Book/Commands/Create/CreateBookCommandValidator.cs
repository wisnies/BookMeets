using FluentValidation;

namespace Application.Features.Book.Commands.Create
{
  public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
  {
    public CreateBookCommandValidator()
    {

    }
  }
}
