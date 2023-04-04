using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace Application.Common.Interfaces.Services
{
  public interface ICloudinaryService
  {
    Task<ImageUploadResult> AddPhotoASync(IFormFile file);
    Task<DeletionResult> DeletePhotoAsync(string publicId);
  }
}
