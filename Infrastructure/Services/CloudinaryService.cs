using Application.Common.Interfaces.Services;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Domain.Common.Errors;
using ErrorOr;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Infrastructure.Services
{
  public class CloudinaryService : ICloudinaryService
  {
    private readonly Cloudinary _cloudinary;
    private string[] _allowedMimeTypes =
    {
      "image/jpeg",
      "image/bmp",
      "image/png"
    };

    public CloudinaryService(IOptions<CloudinarySettings> options)
    {
      var account = new Account(
        options.Value.CloudName,
        options.Value.ApiKey,
        options.Value.ApiSecret);

      _cloudinary = new Cloudinary(account);
    }

    public async Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
    {
      var uploadResult = new ImageUploadResult();
      if (file.Length > 0)
      {
        using var stream = file.OpenReadStream();
        var uploadParams = new ImageUploadParams
        {
          File = new FileDescription(file.FileName, stream)
          // add transformation? refactor to specialized methods?
        };

        uploadResult = await _cloudinary.UploadAsync(uploadParams);
      }
      return uploadResult;
    }

    public async Task<DeletionResult> DeletePhotoAsync(string publicId)
    {
      var deleteParams = new DeletionParams(publicId);
      var deleteResult = await _cloudinary.DestroyAsync(deleteParams);

      return deleteResult;
    }

    public ErrorOr<bool> ValidateImage(IFormFile file)
    {
      var errors = new List<ErrorOr.Error>();

      if (file.Length > 2097152)
      {
        errors.Add(Errors.File.InvalidSize);
      }

      if (!_allowedMimeTypes.Contains(file.ContentType))
      {
        errors.Add(Errors.File.InvalidMimeType);
      }

      return errors.ToArray().Length > 0 ? errors : true;
    }
  }
}
