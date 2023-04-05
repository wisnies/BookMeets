using Application.DTOs.Genre;
using Application.Features.Genre.Commands.Create;
using Application.Features.Genre.Commands.Delete;
using Application.Features.Genre.Commands.Upsert;
using Application.Features.Genre.Queries.Details;
using Application.Features.Genre.Queries.List;
using AutoMapper;
using Contracts.Common;
using Contracts.Genre;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
    public async Task<IActionResult> GetGenreMinimalList()
    {
      var query = new GetGenreMinimalListQuery();
      IEnumerable<GenreMinimalListItemDto> genres = await _mediator.Send(query);

      return Ok(genres);
    }

    [Route("{genreId:int}")]
    [HttpGet]
    public async Task<IActionResult> GetGenreById(int genreId)
    {
      var query = new GetGenreDetailsQuery(genreId);
      ErrorOr<GenreDto> response = await _mediator.Send(query);

      return response.Match(
        response => Ok(response),
        errors => Problem(errors));
    }

    [HttpPost]
    [Authorize(Roles = "Moderator,Administrator")]
    public async Task<IActionResult> CreateGenre([FromBody] CreateGenreRequest request)
    {
      var command = _mapper.Map<CreateGenreCommand>(request);
      ErrorOr<BaseCommandResponse> response = await _mediator.Send(command);

      return response.Match(
        response => Ok(response),
        errors => Problem(errors));
    }

    [Route("{genreId:int}")]
    [HttpPut]
    [Authorize(Roles = "Moderator,Administrator")]
    public async Task<IActionResult> UpsertGenre(int genreId, [FromBody] UpsertGenreRequest request)
    {
      var command = _mapper.Map<UpsertGenreCommand>((request, genreId));
      ErrorOr<BaseCommandResponse> response = await _mediator.Send(command);

      return response.Match(
        response => Ok(response),
        errors => Problem(errors));
    }

    [Route("{genreId:int}")]
    [HttpDelete]
    [Authorize(Roles = "Moderator,Administrator")]
    public async Task<IActionResult> DeleteGenre(int genreId)
    {
      var command = new DeleteGenreCommand(genreId);
      ErrorOr<BaseCommandResponse> response = await _mediator.Send(command);

      return response.Match(
        response => Ok(response),
        errors => Problem(errors));
    }
  }
}
