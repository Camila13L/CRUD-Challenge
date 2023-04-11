using System;
using CRUD.Challenge.Application.Common.Interfaces.Persistence;
using CRUD.Challenge.Domain.Entites;

namespace CRUD.Challenge.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new();

    public async Task AddUser(User user)
    {
        await Task.Run(() => _users.Add(user));

    }

    public async Task<User> GetUserByEmail(string email)
    {
        User user = _users.SingleOrDefault(x => x.Email == email)!;
        return await Task.Run(() => user);
    }
}

