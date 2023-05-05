using CRUD.Challenge.Application.Common.Interfaces.Authentication;
using CRUD.Challenge.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using CRUD.Challenge.Domain.Entites;
using CRUD.Challenge.Domain.Common.HttpErrors;
using CRUD.Challenge.Application.Authentication.Common;

namespace CRUD.Challenge.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        if (await _userRepository.GetUserByEmail(query.Email) is not User user)
        {
            return HttpErrors.Authentication.InvalidCredentials;
        }

        if (user.Password != query.Password)
        {
            return new[] { HttpErrors.Authentication.InvalidPassword };
        }

        var token = await _jwtTokenGenerator.GenerateToken(user);
        return await Task.Run(() => new AuthenticationResult(
            user,
            token
            ));
    }
}

