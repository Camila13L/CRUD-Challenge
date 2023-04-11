using System;
using CRUD.Challenge.Domain.Entites;

namespace CRUD.Challenge.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
	public Task<User> GetUserByEmail(string email);
	public Task AddUser(User user);
}

