﻿using FluentValidation;

namespace Application.Features.Auth.Commands.RefreshToken
{
  public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommand>
  {
    public RefreshTokenCommandValidator()
    {
      RuleFor(x => x.RefreshToken).NotEmpty();
      RuleFor(x => x.ExpiredToken).NotEmpty();
    }
  }
}
