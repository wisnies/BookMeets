using ErrorOr;

namespace Domain.Common.Errors
{
  public static partial class Errors
  {
    public static class File
    {
      public static Error InvalidSize => Error.Validation(
        code: "File.InvalidSize",
        description: "Uploaded images size must not exceed 2048kB.");

      public static Error InvalidMimeType => Error.Validation(
        code: "File.InvalidMimeType",
        description: "Uploaded images must be of type: bmp, jpg, jpeg, png.");
      public static Error UnableToDeleteOldImage => Error.Unexpected(
        code: "File.UnableToDeleteOldImage",
        description: "Unable to delete previous image, try again later.");
    }
  }
}
