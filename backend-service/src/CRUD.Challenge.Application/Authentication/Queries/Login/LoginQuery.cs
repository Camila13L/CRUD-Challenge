using CRUD.Challenge.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace CRUD.Challenge.Application.Authentication.Queries.Login;

public record LoginQuery
(
    string Email,
    string Password
) : IRequest<ErrorOr<AuthenticationResult>>;

