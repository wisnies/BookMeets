using ErrorOr;

namespace Domain.Common.Errors
{
  public static partial class Errors
  {
    public static class Book
    {
      public static Error NotFound => Error.NotFound(
        code: "Book.NotFound",
        description: "This book does not exist.");
      public static Error BookAuthors => Error.Conflict(
        code: "Book.BookAuthors",
        description: "Unable to resolve book-author relations, try again later.");
      public static Error BookGenres => Error.Conflict(
        code: "Book.BookGenres",
        description: "Unable to resolve book-genres relation, try again later.");
    }
  }
}
