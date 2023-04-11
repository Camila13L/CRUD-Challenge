using System;
using CRUD.Challenge.Application.Interfaces;
using CRUD.Challenge.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace CRUD.Challenge.Infrastructure;

public static class ServiceExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        return services;
    }
}

