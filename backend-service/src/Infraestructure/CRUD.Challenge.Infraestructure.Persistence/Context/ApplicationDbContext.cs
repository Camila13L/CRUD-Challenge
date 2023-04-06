namespace CRUD.Challenge.Infraestructure.Persistence.Context;

using System;
using System.Reflection;
using CRUD.Challenge.Core.Application.Interfaces;
using CRUD.Challenge.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    private readonly IDateTimeService _dateTime;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateTimeService dateTime) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        _dateTime = dateTime;
    }

    public DbSet<TEDTalk>? TEDTalks { get; set; }
    public DbSet<City>? Cities { get; set; }

    //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    //{
    //    foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
    //    {
    //        switch (entry.State)
    //        {
    //            case EntityState.Added:
    //                entry.Entity.CreationDate = _dateTime.NowUtc;
    //                break;
    //            case EntityState.Modified:
    //                entry.Entity.LastModifiedDate = _dateTime.NowUtc;
    //                break;
    //        }
    //    }
    //    return base.SaveChangesAsync(cancellationToken);
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.Entity<TEDTalk>().ToTable("TEDTalk");
        modelBuilder.Entity<City>().ToTable("City");
    }
}