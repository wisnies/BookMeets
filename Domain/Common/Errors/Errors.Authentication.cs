using ErrorOr;

namespace Domain.Common.Errors
{
  public static partial class Errors
  {
    public static class Authentication
    {
      public static Error InvalidCredentials => Error.Conflict(
        code: "Authentication.InvalidCredentials",
        description: "Invalid User credentials."
        );
      public static Error TokenNotExpired => Error.Validation(
        code: "Authentication.TokenNotExpired",
        description: "Token is not expired."
        );
      public static Error TokenExpired => Error.Validation(
        code: "Authentication.TokenNotExpired",
        description: "Token is expired."
        );
    }
  }
}
