using ErrorOr;

namespace Domain.Common.Errors
{
  public static partial class Errors
  {
    public static class Genre
    {
      public static Error DuplicateTitle => Error.Conflict(
        code: "Genre.DuplicateTitle",
        description: "This genre alredy exists.");

      public static Error NotFound => Error.NotFound(
        code: "Genre.NotFound",
        description: "This genre does not exist.");
    }
  }
}
