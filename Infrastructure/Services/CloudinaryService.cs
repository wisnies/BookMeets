using Application.Common.Interfaces.Services;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Infrastructure.Services
{
  public class CloudinaryService : ICloudinaryService
  {
    private readonly Cloudinary _cloudinary;

    public CloudinaryService(IOptions<CloudinarySettings> options)
    {
      var account = new Account(
        options.Value.CloudName,
        options.Value.ApiKey,
        options.Value.ApiSecret);

      _cloudinary = new Cloudinary(account);
    }

    public async Task<ImageUploadResult> AddPhotoASync(IFormFile file)
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
  }
}
