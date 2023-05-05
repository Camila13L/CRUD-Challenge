using CRUD.Challenge.Api.Common.Errors;
using CRUD.Challenge.Api.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CRUD.Challenge.Api;

public static class ServiceExtension
{
	public static IServiceCollection AddPresentation(this IServiceCollection services)
	{
		services.AddControllers();
		services.AddMappings();
		return services;
	}
}

