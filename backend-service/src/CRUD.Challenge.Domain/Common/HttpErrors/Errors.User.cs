using System;
using ErrorOr;

namespace CRUD.Challenge.Domain.Common.Errors;

public static partial class HttpErrors
{
    public static class User
    {
        public static Error DuplicatedEmail => Error.Conflict(code: "User.DuplicatedEmail", description: "This email is already in use");
    }
}

