namespace CRUD.Challenge.Application.Interfaces;

using System;
using CRUD.Challenge.Contracts.Authentication;

public interface IAuthentication
{
    AuthenticationResponse Login(string firstName, string lastName, string email, string password);
    AuthenticationResponse Register(string email, string password);

}

