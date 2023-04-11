using System;
namespace CRUD.Challenge.Contracts.Authentication;

public record LoginRequest
(
    string Email,
    string Password
);

