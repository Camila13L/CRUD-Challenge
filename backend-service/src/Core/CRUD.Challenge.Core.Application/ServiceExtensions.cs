namespace CRUD.Challenge.Core.Application;

using System;
using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;


public static class ServiceExtensions
{
	public static void AddApplicationLayer(this IServiceCollection services)
	{
		/**
		* Registering AutoMapper for mappings
		*/
		services.AddAutoMapper(Assembly.GetExecutingAssembly());

        /**
		* Registering FluentValidation for validations
		*/
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        /**
		* Registering MediatR to implement mediator pattern
		*/
		services.AddMediatR(Assembly.GetExecutingAssembly());
    }
}

