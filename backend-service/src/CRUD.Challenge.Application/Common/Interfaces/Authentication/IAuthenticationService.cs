namespace CRUD.Challenge.Application.Interfaces;

using CRUD.Challenge.Application.Common.Errors;
using CRUD.Challenge.Application.Common.Interfaces.Errors;
using CRUD.Challenge.Application.Services.Authentication;
using ErrorOr;
using FluentResults;

public interface IAuthenticationService
{
    public Task<ErrorOr<AuthenticationResult>> Register(string firstName, string lastName, string email, string password);
    public Task<ErrorOr<AuthenticationResult>> Login(string email, string password);

}

