using FluentValidation;

namespace Application.Features.Author.Queries.Details
{
  public class GetAuthorDetailsQueryValidator
    : AbstractValidator<GetAuthorDetailsQuery>
  {
    public GetAuthorDetailsQueryValidator()
    {
      RuleFor(q => q.Id).NotEmpty();
    }
  }
}
