using System;

namespace CRUD.Challenge.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
	public Task<string> GenerateToken(Guid userIdm, string firstName, string lastName);

}

