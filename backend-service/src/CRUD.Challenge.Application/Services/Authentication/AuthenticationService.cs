using System;
using CRUD.Challenge.Application.Interfaces;

namespace CRUD.Challenge.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    public async Task<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        return await Task.Run(() => new AuthenticationResult(Guid.NewGuid(), firstName, lastName, email, "token"));
    }

    public async Task<AuthenticationResult> Login(string email, string password)
    {
        return await Task.Run(() => new AuthenticationResult(Guid.NewGuid(), "firstName", "lastName", email, "token")); 
    }
}

