namespace CRUD.Challenge.Infraestructure.Shared;
using System;
using CRUD.Challenge.Core.Application.Interfaces;
using CRUD.Challenge.Infraestructure.Shared.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceExtensions
{
    public static void AddSharedInfraestructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IDateTimeService, DateTimeService>();
    }
}

