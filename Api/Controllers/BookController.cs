using Application.DTOs.Book;
using Application.Features.Book.Queries.BookList;
using AutoMapper;
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
  }
}
