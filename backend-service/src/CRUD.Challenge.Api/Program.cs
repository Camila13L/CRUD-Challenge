using CRUD.Challenge.Api;
using CRUD.Challenge.Application;
using CRUD.Challenge.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
{
    builder.Services
    .AddPresentation()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);
}

var app = builder.Build();
{

    app.UseExceptionHandler("/error");

    app.UseHttpsRedirection();

    app.UseAuthentication();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}

