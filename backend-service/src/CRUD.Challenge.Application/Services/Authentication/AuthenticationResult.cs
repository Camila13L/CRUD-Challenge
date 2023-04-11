using System;
namespace CRUD.Challenge.Application.Services.Authentication;

public record AuthenticationResult
(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string token
);

