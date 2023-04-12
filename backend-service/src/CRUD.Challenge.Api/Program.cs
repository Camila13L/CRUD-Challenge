using CRUD.Challenge.Api;
using CRUD.Challenge.Api.Errors;
using CRUD.Challenge.Api.Filters;
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



//builder.Services.AddSingleton<ProblemDetailsFactory,CRUDChallengeProblemDetailsFactory>();


var app = builder.Build();
{

    app.UseExceptionHandler("/error");

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}

