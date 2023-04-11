using System;
using CRUD.Challenge.Application.Common.Interfaces.Authentication;
using CRUD.Challenge.Application.Interfaces;

namespace CRUD.Challenge.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        //check if the user already exists
        //Create a user//generate uniqueID
        //create the token'

        Guid userId = Guid.NewGuid();
        string token = await  _jwtTokenGenerator.GenerateToken(userId,firstName, lastName);
        return await Task.Run(() => new AuthenticationResult(userId, firstName, lastName, email, token));
    }

    public async Task<AuthenticationResult> Login(string email, string password)
    {
        return await Task.Run(() => new AuthenticationResult(Guid.NewGuid(), "firstName", "lastName", email, "token")); 
    }
}

