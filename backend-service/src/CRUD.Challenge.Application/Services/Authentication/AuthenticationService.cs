﻿using System;
using CRUD.Challenge.Application.Common.Interfaces.Authentication;
using CRUD.Challenge.Application.Common.Interfaces.Persistence;
using CRUD.Challenge.Application.Interfaces;
using CRUD.Challenge.Domain.Entites;

namespace CRUD.Challenge.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        User userEmail = await _userRepository.GetUserByEmail(email);
        if (userEmail is not null)
        {
            throw new Exception("User already exists");

        }

        User user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Password = password,
            Email = email
        };
        await _userRepository.AddUser(user);

        string token = await  _jwtTokenGenerator.GenerateToken(user);
        return await Task.Run(() => new AuthenticationResult(user, token));
    }

    public async Task<AuthenticationResult> Login(string email, string password)
    {
        if (await _userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("user not found");
        }

        if (user.Password != password)
        {
            throw new Exception("Incorrect password");
        }

        var token = await _jwtTokenGenerator.GenerateToken(user);
        return await Task.Run(() => new AuthenticationResult(
            user,
            token
            )); 
    }
}
