using System;
using CRUD.Challenge.Domain.Entites;

namespace CRUD.Challenge.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
	public Task<string> GenerateToken(User user);

}

