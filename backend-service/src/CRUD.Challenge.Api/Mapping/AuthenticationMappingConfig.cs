using System;
using CRUD.Challenge.Application.Authentication.Common;
using CRUD.Challenge.Contracts.Authentication;
using Mapster;

namespace CRUD.Challenge.Api.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Token, src => src.Token )
            .Map(dest => dest, src => src.User);
    }
}

