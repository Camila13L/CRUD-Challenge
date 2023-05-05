using CRUD.Challenge.Domain.Entites;

namespace CRUD.Challenge.Application.Authentication.Common;

public record AuthenticationResult
(
    User User,
    string Token
);
