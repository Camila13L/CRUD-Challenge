using System;
using ErrorOr;

namespace CRUD.Challenge.Domain.Common.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicatedEmail => Error.Conflict(code: "User.DuplicatedEmail", description: "Email is already in use");
    }
}

