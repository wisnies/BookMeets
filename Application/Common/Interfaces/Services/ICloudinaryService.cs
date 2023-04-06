using CloudinaryDotNet.Actions;
using ErrorOr;
using Microsoft.AspNetCore.Http;

namespace Application.Common.Interfaces.Services
{
  public interface ICloudinaryService
  {
    Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
    Task<DeletionResult> DeletePhotoAsync(string publicId);
    ErrorOr<bool> ValidateImage(IFormFile file);

  }
}
