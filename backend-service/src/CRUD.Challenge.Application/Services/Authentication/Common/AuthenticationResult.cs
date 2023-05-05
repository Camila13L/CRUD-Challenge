using System;
using CRUD.Challenge.Domain.Entites;

namespace CRUD.Challenge.Application.Services.Authentication.Common;

public record AuthenticationResult
(
    User user,
    string token
);

