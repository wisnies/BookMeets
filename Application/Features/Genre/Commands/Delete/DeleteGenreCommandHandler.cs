using Application.Common.Interfaces.Persistence;
using Contracts.Common;
using Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Application.Features.Genre.Commands.Delete
{
  public class DeleteGenreCommandHandler
    : IRequestHandler<DeleteGenreCommand, ErrorOr<BaseCommandResponse>>
  {
    private readonly IGenreRepository _genreRepository;

    public DeleteGenreCommandHandler(IGenreRepository genreRepository)
    {
      _genreRepository = genreRepository;
    }

    public async Task<ErrorOr<BaseCommandResponse>> Handle(
      DeleteGenreCommand request,
      CancellationToken cancellationToken)
    {
      if (await _genreRepository.GetAsync(request.Id) is not Domain.Entities.Genre.Genre dbGenre)
      {
        return Errors.Genre.NotFound;
      }

      await _genreRepository.DeleteAsync(dbGenre);

      return new BaseCommandResponse()
      {
        Id = dbGenre.Id,
        Message = "Genre " + dbGenre.Title + " deleted successfully.",
      };
    }
  }
}
