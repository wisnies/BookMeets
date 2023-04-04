using AutoMapper;
using Contracts.Genre;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
  [Route("genre")]
  public class GenreController : ApiController
  {
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    public GenreController(ISender mediator, IMapper mapper)
    {
      _mediator = mediator;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetGenreList()
    {
      return Ok();
    }

    [Route("{genreId:int}")]
    [HttpGet]
    public async Task<IActionResult> GetGenreById(int genreId)
    {
      return Ok();
    }

    [HttpPost]
    //[Authorize(Roles = "Moderator,Administrator")]
    public async Task<IActionResult> CreateGenre([FromBody] CreateGenreRequest request)
    {
      return Ok();
    }

    [Route("{genreId:int}")]
    [HttpPut]
    //[Authorize(Roles = "Moderator,Administrator")]
    public async Task<IActionResult> UpsertGenre(int authorId, [FromBody] UpsertGenreRequest request)
    {
      return Ok();
    }

    [Route("{genreId:int}")]
    [HttpDelete]
    //[Authorize(Roles = "Moderator,Administrator")]
    public async Task<IActionResult> DeleteGenre(int genreId)
    {
      return Ok();
    }
  }
}
