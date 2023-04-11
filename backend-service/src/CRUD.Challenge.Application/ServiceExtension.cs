using System;
using CRUD.Challenge.Application.Interfaces;
using CRUD.Challenge.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace CRUD.Challenge.Application;

public static class ServiceExtension
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        return services;
    }
}

