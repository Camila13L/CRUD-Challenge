namespace CRUD.Challenge.Application.Interfaces;

using CRUD.Challenge.Application.Services.Authentication;

public interface IAuthenticationService
{
    public Task<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
    public Task<AuthenticationResult> Login(string email, string password);

}

