using System;
using ErrorOr;

namespace CRUD.Challenge.Domain.Common.HttpErrors;

public static partial class HttpErrors
{
	public static class Authentication
	{
		public static Error InvalidCredentials => Error.Validation(code: "Authe.InvalidCredentials", description: "User does not exists" );

        public static Error InvalidPassword => Error.Validation(code: "Authe.InvalidPassword", description: "The password is incorrect");
    }
}

