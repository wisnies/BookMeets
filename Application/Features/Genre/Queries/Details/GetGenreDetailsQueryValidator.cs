using FluentValidation;

namespace Application.Features.Genre.Queries.Details
{
  public class GetGenreDetailsQueryValidator : AbstractValidator<GetGenreDetailsQuery>
  {
    public GetGenreDetailsQueryValidator()
    {
      RuleFor(q => q.Id).NotEmpty();
    }
  }
}
