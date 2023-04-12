using System;
using System.Text;
using CRUD.Challenge.Application.Common.Interfaces.Authentication;
using CRUD.Challenge.Application.Common.Interfaces.Persistence;
using CRUD.Challenge.Application.Common.Interfaces.Services;
using CRUD.Challenge.Application.Interfaces;
using CRUD.Challenge.Application.Services.Authentication;
using CRUD.Challenge.Infrastructure.Authentication;
using CRUD.Challenge.Infrastructure.Persistence;
using CRUD.Challenge.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CRUD.Challenge.Infrastructure;

public static class ServiceExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddAuth(configuration);

        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }

    public static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configuration)
    {
        JwtSettings JwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, JwtSettings);

        services.AddSingleton(Options.Create(JwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = JwtSettings.Issuer,
                ValidAudience = JwtSettings.Audience,
                IssuerSigningKey =  new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSettings.Secret))

            });

        return services;
    }
}

