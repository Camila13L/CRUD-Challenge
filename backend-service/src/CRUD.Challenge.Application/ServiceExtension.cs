using System;
using CRUD.Challenge.Application.Common.Interfaces.Authentication;
using CRUD.Challenge.Application.Interfaces.Authentication;
using CRUD.Challenge.Application.Services.Authentication;
using CRUD.Challenge.Application.Services.Authentication.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CRUD.Challenge.Application;

public static class ServiceExtension
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
        services.AddMediatR(typeof(ServiceExtension).Assembly);
        return services;
    }
}

