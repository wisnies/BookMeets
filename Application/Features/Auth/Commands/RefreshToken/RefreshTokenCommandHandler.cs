﻿using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Contracts.Authentication;
using Domain.Common.Errors;
using ErrorOr;
using MediatR;
using System.IdentityModel.Tokens.Jwt;

namespace Application.Features.Auth.Commands.RefreshToken
{
  public class RefreshTokenCommandHandler
    : IRequestHandler<RefreshTokenCommand, ErrorOr<RefreshTokenResponse>>
  {
    private readonly IUserRefreshTokenRepository _userRefreshTokenRepository;
    private readonly ITokenGenerator _tokenGenerator;

    public RefreshTokenCommandHandler(
      IUserRefreshTokenRepository userRefreshTokenRepository,
      ITokenGenerator tokenGenerator)
    {
      _userRefreshTokenRepository = userRefreshTokenRepository;
      _tokenGenerator = tokenGenerator;
    }

    public async Task<ErrorOr<RefreshTokenResponse>> Handle(
      RefreshTokenCommand request,
      CancellationToken cancellationToken)
    {
      if (request.ExpiredToken.ValidTo > DateTime.UtcNow)
      {
        return Errors.Authentication.TokenNotExpired;
      }

      var userRefreshToken = await _userRefreshTokenRepository
        .GetRefreshTokenByTokenAsync(request.RefreshToken);

      if (userRefreshToken is null || !userRefreshToken.IsActive)
      {
        return Errors.Authentication.TokenExpired;
      }

      string email = request.ExpiredToken.Claims.
        FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Email).Value;
      string strId = request.ExpiredToken.Claims.
        FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub).Value;

      int userId;
      bool parsed = int.TryParse(strId, out userId);

      if (!parsed)
      {
        return Errors.Authentication.InvalidCredentials;
      }

      var accessToken = _tokenGenerator.GenerateAccessToken(userId, email);

      userRefreshToken.AccessToken = accessToken;

      await _userRefreshTokenRepository.UpdateAsync(userRefreshToken);
      return new RefreshTokenResponse(accessToken);
    }
  }
}
