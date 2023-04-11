using System;
namespace CRUD.Challenge.Contracts.Authentication;

public record ResgisterRequest
(
    string FirstName,
    string LastName,
    string Email,
    string Password
);
