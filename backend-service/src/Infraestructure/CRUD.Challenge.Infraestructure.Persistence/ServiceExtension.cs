namespace CRUD.Challenge.Infraestructure.Persistence;

using System;
using CRUD.Challenge.Core.Application.Interfaces;
using CRUD.Challenge.Infraestructure.Persistence.Context;
using CRUD.Challenge.Infraestructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceExtension
{
    public static void AddPersistenceInfraestructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
            configuration.GetConnectionString("DefaultConnection")!,
            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
            ));

        #region Repositories
        services.AddTransient(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
        #endregion
    }
}
