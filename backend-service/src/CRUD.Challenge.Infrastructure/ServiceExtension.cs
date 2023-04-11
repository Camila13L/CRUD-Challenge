using System;
using CRUD.Challenge.Application.Common.Interfaces.Authentication;
using CRUD.Challenge.Application.Interfaces;
using CRUD.Challenge.Application.Services.Authentication;
using CRUD.Challenge.Infrastructure.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace CRUD.Challenge.Infrastructure;

public static class ServiceExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        return services;
    }
}

