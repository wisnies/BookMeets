using ErrorOr;

namespace Domain.Common.Errors
{
  public static partial class Errors
  {
    public static class User
    {
      public static Error DuplicateEmail => Error.Conflict(
        code: "User.DuplicateEmail",
        description: "This email address is alredy taken.");
      public static Error RoleNotFound => Error.NotFound(
        code: "User.RoleNotFound",
        description: "User role not found.");
    }
  }
}
