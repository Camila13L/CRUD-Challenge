using CRUD.Challenge.Application.Authentication.Commands.Register;
using CRUD.Challenge.Application.Authentication.Common;
using CRUD.Challenge.Application.Authentication.Queries.Login;
using CRUD.Challenge.Contracts.Authentication;
using Mapster;

namespace CRUD.Challenge.Api.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();


        config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Token, src => src.Token )
            .Map(dest => dest, src => src.User);
    }
}

