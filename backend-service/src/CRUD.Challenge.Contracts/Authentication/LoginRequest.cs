using System;
namespace CRUD.Challenge.Contracts.Authentication;

public record LoginRequest
(
    string Emal,
    string Password
);

