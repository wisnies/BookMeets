using Application.Common.Interfaces.Services;
using Application.DTOs.Author;
using Application.Features.Author.Commands.Create;
using Application.Features.Author.Commands.Delete;
using Application.Features.Author.Commands.Upsert;
using Application.Features.Author.Queries.Details;
using Application.Features.Author.Queries.NoBooksList;
using AutoMapper;
using Contracts.Author;
using Contracts.Common;
using Domain.Common.Errors;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
  [Route("author")]
  public class AuthorController : ApiController
  {
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    private readonly ICloudinaryService _cloudinaryService;
    public AuthorController(
      ISender mediator,
      IMapper mapper,
      ICloudinaryService cloudinaryService)
    {
      _mediator = mediator;
      _mapper = mapper;
      _cloudinaryService = cloudinaryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAuthorNoBooksList()
    {
      var query = new GetAuthorNoBooksListQuery();
      IEnumerable<AuthorNoBooksDto> authors = await _mediator.Send(query);

      return Ok(authors);
    }

    [Route("{authorId:int}")]
    [HttpGet]
    public async Task<IActionResult> GetAuthorById(int authorId)
    {
      var query = new GetAuthorDetailsQuery()
      {
        Id = authorId
      };
      ErrorOr<AuthorDto> response = await _mediator.Send(query);

      return response.Match(
        response => Ok(response),
        errors => Problem(errors));

    }

    [HttpPost]
    //[Authorize(Roles = "Moderator,Administrator")]
    public async Task<IActionResult> CreateAuthor([FromForm] CreateAuthorRequest request)
    {

      string imageUrl = "default", imagePublicId = "default";

      if (request.Image != null)
      {
        ErrorOr<bool> validImage = _cloudinaryService.ValidateImage(request.Image);

        if (!validImage.IsError)
        {
          var imageUploadResult = await _cloudinaryService.AddPhotoAsync(request.Image);
          imageUrl = imageUploadResult.Url.ToString();
          imagePublicId = imageUploadResult.PublicId.ToString();
        }
        else
        {
          return Problem(validImage.Errors);
        }
      }
      var command = _mapper.Map<CreateAuthorCommand>((request, imageUrl, imagePublicId));

      ErrorOr<BaseCommandResponse> response = await _mediator.Send(command);

      return response.Match(
        response => Ok(response),
        errors => Problem(errors));
    }

    [Route("{authorId:int}")]
    [HttpPut]
    //[Authorize(Roles = "Moderator,Administrator")]
    public async Task<IActionResult> UpsertAuthor(int authorId, [FromForm] UpsertAuthorRequest request)
    {
      string imageUrl = request.ImageUrl, imagePublicId = request.ImagePublicId;
      if (request.Image != null)
      {
        ErrorOr<bool> validImage = _cloudinaryService.ValidateImage(request.Image);
        if (!validImage.IsError)
        {
          try
          {
            await _cloudinaryService.DeletePhotoAsync(request.ImagePublicId);
          }
          catch (Exception ex)
          {
            var errors = new List<Error>
          {
            Errors.Author.UnableToDeleteOldImage
          };
            return Problem(errors);
          }
          var imageUploadResult = await _cloudinaryService.AddPhotoAsync(request.Image);
          imageUrl = imageUploadResult.Url.ToString();
          imagePublicId = imageUploadResult.PublicId.ToString();
        }
        else
        {
          return Problem(validImage.Errors);
        }
      }
      var command = _mapper.Map<UpsertAuthorCommand>((request, imageUrl, imagePublicId, authorId));

      ErrorOr<BaseCommandResponse> response = await _mediator.Send(command);

      return response.Match(
        response => Ok(response),
        errors => Problem(errors));
    }

    [Route("{authorId:int}")]
    [HttpDelete]
    //[Authorize(Roles = "Moderator,Administrator")]
    public async Task<IActionResult> DeleteAuthor(int authorId)
    {
      var command = new DeleteAuthorCommand()
      {
        Id = authorId,
      };

      ErrorOr<BaseCommandResponse> response = await _mediator.Send(command);
      return response.Match(
        response => Ok(response),
        errors => Problem(errors));
    }
  }
}
