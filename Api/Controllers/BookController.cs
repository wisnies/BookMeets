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
    public async Task<IActionResult> GetAll()
    {
      //var command = 1;
      //ErrorOr<ICollection<BookListDto>> response = await _mediator.Send(command);
      //return response.Match(
      //  response => Ok(response),
      //  errors => Problem(errors));
      return Ok();
    }
  }
}
