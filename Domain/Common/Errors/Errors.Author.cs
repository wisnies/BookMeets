using ErrorOr;

namespace Domain.Common.Errors
{
  public static partial class Errors
  {
    public static class Author
    {
      public static Error NotFound => Error.NotFound(
        code: "Author.NotFound",
        description: "This author does not exist.");
      public static Error UnableToDeleteOldImage => Error.Unexpected(
        code: "Author.UnableToDeleteOldImage",
        description: "Unable to delete previous image, try again later.");
      public static Error Unexpected => Error.Unexpected(
        code: "Author.Unexpected",
        description: "Something went wrong, try again later.");
    }
  }
}
