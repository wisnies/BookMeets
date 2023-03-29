using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Domain.Common.Errors;
using Domain.Entities.User;
using ErrorOr;
using MediatR;

namespace Application.Features.Auth.Commands.Register
{
  public class RegisterCommandHandler
    : IRequestHandler<RegisterCommand, ErrorOr<Unit>>
  {
    private readonly IUserRepository _userRepository;
    private readonly IPasswordService _passwordService;

    public RegisterCommandHandler(
      IUserRepository userRepository,
      IPasswordService passwordService)
    {
      _userRepository = userRepository;
      _passwordService = passwordService;
    }

    public async Task<ErrorOr<Unit>> Handle(
      RegisterCommand request,
      CancellationToken cancellationToken)
    {
      if (await _userRepository.GetUserByEmailAsync(request.Email) is not null)
      {
        return Errors.User.DuplicateEmail;
      }

      var user = new User()
      {
        Email = request.Email,
        Password = _passwordService.GenerateHash(request.Password),
        UserName = request.UserName,
      };

      var dbUser = await _userRepository.AddAsync(user);

      return Unit.Value;
    }
  }
}
