using System;
using CRUD.Challenge.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace CRUD.Challenge.Application.Authentication.Commands.Register;

public record RegisterCommand
(
    string FirstName,
    string LastName,
    string Email,
    string Password
): IRequest<ErrorOr<AuthenticationResult>>;
