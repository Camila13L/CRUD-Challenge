using System;
using CRUD.Challenge.Application.Services.Authentication.Common;
using ErrorOr;

namespace CRUD.Challenge.Application.Common.Interfaces.Authentication;
public interface IAuthenticationQueryService
{
    public Task<ErrorOr<AuthenticationResult>> Login(string email, string password);
}

