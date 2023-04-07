using FluentValidation;

namespace Application.Features.Book.Commands.Edit
{
  public class EditBookCommandValidator : AbstractValidator<EditBookCommand>
  {
    public EditBookCommandValidator()
    {
      RuleFor(c => c.Id).NotEmpty();
      RuleFor(c => c.Title).NotEmpty();
      RuleFor(c => c.Description).NotEmpty();
      RuleFor(c => c.CoverType).NotEmpty();
      RuleFor(c => c.CoverImageUrl).NotEmpty();
      RuleFor(c => c.CoverImagePublicId).NotEmpty();
      RuleFor(c => c.NumberOfPages).NotEmpty();
      RuleFor(c => c.FirstPublished).NotEmpty();
    }
  }
}
