using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Domain.Common.Errors;
using Domain.Entities.User;
using Domain.Entities.UserRole;
using ErrorOr;
using MediatR;

namespace Application.Features.Auth.Commands.Register
{
  public class RegisterCommandHandler
    : IRequestHandler<RegisterCommand, ErrorOr<Unit>>
  {
    private readonly IUserRepository _userRepository;
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IPasswordService _passwordService;

    public RegisterCommandHandler(
      IUserRepository userRepository,
      IUserRoleRepository userRoleRepository,
      IPasswordService passwordService)
    {
      _userRepository = userRepository;
      _userRoleRepository = userRoleRepository;
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

      var userRole = new UserRole()
      {
        UserId = dbUser.Id,
        Role = "User"
      };

      await _userRoleRepository.AddAsync(userRole);
      return Unit.Value;
    }
  }
}
