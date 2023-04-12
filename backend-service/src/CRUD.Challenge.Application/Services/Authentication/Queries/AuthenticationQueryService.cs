using System;
using CRUD.Challenge.Application.Common.Errors;
using CRUD.Challenge.Application.Common.Interfaces.Authentication;
using CRUD.Challenge.Application.Common.Interfaces.Errors;
using CRUD.Challenge.Application.Common.Interfaces.Persistence;
using CRUD.Challenge.Application.Interfaces;
using CRUD.Challenge.Application.Services.Authentication.Common;
using CRUD.Challenge.Domain.Common.Errors;
using CRUD.Challenge.Domain.Entites;
using ErrorOr;
using FluentResults;

namespace CRUD.Challenge.Application.Services.Authentication.Queries;

public class AuthenticationQueryService : IAuthenticationQueryService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationQueryService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Login(string email, string password)
    {
        if (await _userRepository.GetUserByEmail(email) is not User user)
        {
            return HttpErrors.Authentication.InvalidCredentials;
        }

        if (user.Password != password)
        {
            return new[] { HttpErrors.Authentication.InvalidPassword };
        }

        var token = await _jwtTokenGenerator.GenerateToken(user);
        return await Task.Run(() => new AuthenticationResult(
            user,
            token
            )); 
    }
}

