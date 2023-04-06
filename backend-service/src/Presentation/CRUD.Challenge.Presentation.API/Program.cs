using CRUD.Challenge.Core.Application;
using CRUD.Challenge.Infraestructure.Persistence;
using CRUD.Challenge.Infraestructure.Persistence.Context;
using CRUD.Challenge.Infraestructure.Shared;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationLayer();
builder.Services.AddPersistenceInfraestructure(builder.Configuration);
builder.Services.AddSharedInfraestructure(builder.Configuration);

var app = builder.Build();


//using (var scope = app.Services.CreateScope())
//{
//    var applicationContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
//    applicationContext.Database.Migrate();
//}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
