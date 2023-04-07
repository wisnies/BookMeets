using Application.Common.Interfaces.Services;
using Application.DTOs.Book;
using Application.Features.Book.Commands.AddAuthor;
using Application.Features.Book.Commands.AddGenre;
using Application.Features.Book.Commands.Create;
using Application.Features.Book.Commands.Delete;
using Application.Features.Book.Commands.DeleteAuthor;
using Application.Features.Book.Commands.DeleteGenre;
using Application.Features.Book.Commands.Edit;
using Application.Features.Book.Queries.BookList;
using Application.Features.Book.Queries.Details;
using AutoMapper;
using Contracts.Book;
using Contracts.Common;
using Domain.Common.Errors;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
  [Route("book")]
  public class BookController : ApiController
  {
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    private readonly ICloudinaryService _cloudinaryService;
    public BookController(
      ISender mediator,
      IMapper mapper,
      ICloudinaryService cloudinaryService)
    {
      _mediator = mediator;
      _mapper = mapper;
      _cloudinaryService = cloudinaryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetBookList([FromQuery] GetBookListRequest request)
    {
      var query = _mapper.Map<GetBookListQuery>(request);

      BookListItemPaginatedResponseDto response = await _mediator.Send(query);
      return Ok(response);
    }

    [Route("{bookId:int}")]
    [HttpGet]
    public async Task<IActionResult> GetBookById(int bookId)
    {
      var query = new GetBookDetailsQuery()
      {
        Id = bookId
      };
      ErrorOr<BookDto> response = await _mediator.Send(query);

      return response.Match(
        response => Ok(response),
        errors => Problem(errors));
    }

    [HttpPost]
    //[Authorize(Roles = "Moderator,Administrator")]
    public async Task<IActionResult> CreateBook([FromForm] CreateBookRequest request)
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
      var command = _mapper.Map<CreateBookCommand>((request, imageUrl, imagePublicId));

      ErrorOr<BaseCommandResponse> response = await _mediator.Send(command);

      return response.Match(
        response => Ok(response),
        errors => Problem(errors));
    }

    [Route("{bookId:int}")]
    [HttpPut]
    //[Authorize(Roles = "Moderator,Administrator")]
    public async Task<IActionResult> EditBook(int bookId, [FromForm] EditBookRequest request)
    {
      string imageUrl = request.CoverImageUrl, imagePublicId = request.CoverImagePublicId;
      if (request.Image != null)
      {
        ErrorOr<bool> validImage = _cloudinaryService.ValidateImage(request.Image);
        if (!validImage.IsError)
        {
          try
          {
            await _cloudinaryService.DeletePhotoAsync(request.CoverImagePublicId);
          }
          catch (Exception ex)
          {
            var errors = new List<ErrorOr.Error>
          {
            Errors.File.UnableToDeleteOldImage
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
      var command = _mapper.Map<EditBookCommand>((request, imageUrl, imagePublicId, bookId));

      ErrorOr<BaseCommandResponse> response = await _mediator.Send(command);

      return response.Match(
        response => Ok(response),
        errors => Problem(errors));
    }

    [Route("{bookId:int}")]
    [HttpDelete]
    //[Authorize(Roles = "Moderator,Administrator")]
    public async Task<IActionResult> DeleteBook(int bookId)
    {
      var command = new DeleteBookCommand()
      {
        Id = bookId
      };

      ErrorOr<BaseCommandResponse> response = await _mediator.Send(command);

      return response.Match(
        response => Ok(response),
        errors => Problem(errors));
    }

    [Route("{bookId:int}/author")]
    [HttpPost]
    //[Authorize(Roles = "Moderator,Administrator")]
    public async Task<IActionResult> AddBookAuthor(int bookId, [FromBody] AddBookAuthorRequest request)
    {
      var command = new AddBookAuthorCommand()
      {
        Id = bookId,
        AuthorId = request.AuthorId
      };

      ErrorOr<BaseCommandResponse> response = await _mediator.Send(command);

      return response.Match(
        response => Ok(response),
        errors => Problem(errors));
    }

    [Route("{bookId:int}/genre")]
    [HttpPost]
    //[Authorize(Roles = "Moderator,Administrator")]
    public async Task<IActionResult> AddBookGenre(int bookId, [FromBody] AddBookGenreRequest request)
    {
      var command = new AddBookGenreCommand()
      {
        Id = bookId,
        GenreId = request.GenreId
      };

      ErrorOr<BaseCommandResponse> response = await _mediator.Send(command);

      return response.Match(
        response => Ok(response),
        errors => Problem(errors));
    }

    [Route("{bookId:int}/author/{authorId:int}")]
    [HttpDelete]
    //[Authorize(Roles = "Moderator,Administrator")]
    public async Task<IActionResult> DeleteBookAuthor(int bookId, int authorId)
    {
      var command = new DeleteBookAuthorCommand()
      {
        Id = bookId,
        AuthorId = authorId
      };

      ErrorOr<BaseCommandResponse> response = await _mediator.Send(command);

      return response.Match(
        response => Ok(response),
        errors => Problem(errors));
    }
    [Route("{bookId:int}/genre/{genreId:int}")]
    [HttpDelete]
    //[Authorize(Roles = "Moderator,Administrator")]
    public async Task<IActionResult> DeleteBookGenre(int bookId, int genreId)
    {
      var command = new DeleteBookGenreCommand()
      {
        Id = bookId,
        GenreId = genreId
      };

      ErrorOr<BaseCommandResponse> response = await _mediator.Send(command);

      return response.Match(
        response => Ok(response),
        errors => Problem(errors));
    }
  }
}
