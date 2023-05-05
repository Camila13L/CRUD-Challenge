using System;
using CRUD.Challenge.Application.Common.Interfaces.Authentication;
using CRUD.Challenge.Application.Common.Interfaces.Persistence;
using CRUD.Challenge.Domain.Entites;
using CRUD.Challenge.Domain.Common.HttpErrors;
using ErrorOr;
using MediatR;

using CRUD.Challenge.Application.Authentication.Common;

namespace CRUD.Challenge.Application.Authentication.Commands.Register;
public class RegistercommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegistercommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        User userEmail = await _userRepository.GetUserByEmail(command.Email);

        if (userEmail is not null)
        {
            return new[] { HttpErrors.User.DuplicatedEmail };
        }

        User user = new User
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Password = command.Password,
            Email = command.Email
        };
        await _userRepository.AddUser(user);

        string token = await _jwtTokenGenerator.GenerateToken(user);
        return await Task.Run(() => new AuthenticationResult(user, token));
    }
}

