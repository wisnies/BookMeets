using FluentValidation;

namespace Application.Features.Auth.Commands.Register
{
  public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
  {
    public RegisterCommandValidator()
    {
      RuleFor(x => x.Email).NotEmpty();
      RuleFor(x => x.Password).NotEmpty();
      RuleFor(x => x.UserName).NotEmpty();
    }
  }
}
