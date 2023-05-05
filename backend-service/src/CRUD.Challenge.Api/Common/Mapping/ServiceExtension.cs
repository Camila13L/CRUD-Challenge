using System;
using System.Reflection;
using Mapster;
using MapsterMapper;

namespace CRUD.Challenge.Api.Mapping;

public static class ServiceExtension
{
	public static IServiceCollection AddMappings(this IServiceCollection services)
	{
        TypeAdapterConfig config = TypeAdapterConfig.GlobalSettings;
		config.Scan(Assembly.GetExecutingAssembly());

		services.AddSingleton(config);
		services.AddScoped<IMapper, ServiceMapper>();

		return services;
	}
}

