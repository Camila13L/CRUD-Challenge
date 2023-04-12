using System;
using System.Reflection;
using CRUD.Challenge.Application.Authentication.Commands;
using CRUD.Challenge.Application.Authentication.Commands.Register;
using CRUD.Challenge.Application.Authentication.Common;
using CRUD.Challenge.Application.Behaviors;
using CRUD.Challenge.Application.Common.Interfaces.Authentication;
using CRUD.Challenge.Application.Interfaces.Authentication;
using CRUD.Challenge.Application.Services.Authentication;
using CRUD.Challenge.Application.Services.Authentication.Queries;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CRUD.Challenge.Application;

public static class ServiceExtension
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
        services.AddMediatR(typeof(ServiceExtension).Assembly);

        services.AddScoped<
            IPipelineBehavior<RegisterCommand, ErrorOr<AuthenticationResult>>,
            ValidationBehavior>();

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}

