using Application.DTOs.Book;
using Application.Features.Book.Queries.BookList;
using AutoMapper;
using Contracts.Book;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
  [Route("book")]
  public class BookController : ApiController
  {
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    public BookController(ISender mediator, IMapper mapper)
    {
      _mediator = mediator;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetBookList()
    {
      var query = new BookListQuery();
      ICollection<BookListItemDto> response = await _mediator.Send(query);
      return Ok(response);
    }

    [Route("{bookId:int}")]
    [HttpGet]
    public async Task<IActionResult> GetBookById(int bookId)
    {
      var query = new BookListQuery();
      ICollection<BookListItemDto> response = await _mediator.Send(query);
      return Ok(response);
    }

    [HttpPost]
    //[Authorize(Roles = "Moderator,Administrator")]
    public async Task<IActionResult> CreateBook([FromBody] CreateBookRequest request)
    {
      return Ok();
    }

    [Route("{bookId:int}")]
    [HttpPut]
    //[Authorize(Roles = "Moderator,Administrator")]
    public async Task<IActionResult> UpsertBook(int bookId, [FromBody] UpsertBookRequest request)
    {
      return Ok();
    }

    [Route("{bookId:int}")]
    [HttpDelete]
    //[Authorize(Roles = "Moderator,Administrator")]
    public async Task<IActionResult> DeleteBook(int bookId)
    {
      return Ok();
    }
  }
}
