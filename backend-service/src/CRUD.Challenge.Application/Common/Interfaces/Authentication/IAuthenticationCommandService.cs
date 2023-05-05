namespace CRUD.Challenge.Application.Interfaces.Authentication;

using CRUD.Challenge.Application.Common.Errors;
using CRUD.Challenge.Application.Common.Interfaces.Errors;
using CRUD.Challenge.Application.Services.Authentication;
using CRUD.Challenge.Application.Services.Authentication.Common;
using ErrorOr;
using FluentResults;

public interface IAuthenticationCommandService
{
    public Task<ErrorOr<AuthenticationResult>> Register(string firstName, string lastName, string email, string password);
}

