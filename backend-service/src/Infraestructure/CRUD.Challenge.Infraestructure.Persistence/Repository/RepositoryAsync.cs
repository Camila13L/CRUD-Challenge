namespace CRUD.Challenge.Infraestructure.Persistence.Repository;

using System;
using Ardalis.Specification.EntityFrameworkCore;
using CRUD.Challenge.Core.Application.Interfaces;
using CRUD.Challenge.Infraestructure.Persistence.Context;

public class RepositoryAsync<T> : RepositoryBase<T>, IRepositoryAsync<T> where T : class
{
    private readonly ApplicationDbContext dbContext;

    public RepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
    {
        this.dbContext = dbContext;
    }
}

