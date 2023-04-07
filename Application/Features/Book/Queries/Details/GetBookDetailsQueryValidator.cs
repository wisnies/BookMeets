using FluentValidation;

namespace Application.Features.Book.Queries.Details
{
  public class GetBookDetailsQueryValidator : AbstractValidator<GetBookDetailsQuery>
  {
    public GetBookDetailsQueryValidator()
    {
      RuleFor(q => q.Id).NotEmpty();
    }
  }
}
