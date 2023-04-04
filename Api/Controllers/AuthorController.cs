using AutoMapper;
using Contracts.Author;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
  [Route("author")]
  public class AuthorController : ApiController
  {
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    public AuthorController(ISender mediator, IMapper mapper)
    {
      _mediator = mediator;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAuthorList()
    {
      return Ok();
    }

    [Route("{authorId:int}")]
    [HttpGet]
    public async Task<IActionResult> GetAuthorById(int authorId)
    {
      return Ok();
    }

    [HttpPost]
    //[Authorize(Roles = "Moderator,Administrator")]
    public async Task<IActionResult> CreateAuthor([FromBody] CreateAuthorRequest request)
    {
      return Ok();
    }

    [Route("{authorId:int}")]
    [HttpPut]
    //[Authorize(Roles = "Moderator,Administrator")]
    public async Task<IActionResult> UpsertAuthor(int authorId, [FromBody] UpsertAuthorRequest request)
    {
      return Ok();
    }

    [Route("{authorId:int}")]
    [HttpDelete]
    //[Authorize(Roles = "Moderator,Administrator")]
    public async Task<IActionResult> DeleteAuthor(int authorId)
    {
      return Ok();
    }
  }
}
