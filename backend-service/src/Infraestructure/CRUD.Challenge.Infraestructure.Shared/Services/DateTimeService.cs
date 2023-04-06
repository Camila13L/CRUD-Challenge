namespace CRUD.Challenge.Infraestructure.Shared.Services;
using System;
using CRUD.Challenge.Core.Application.Interfaces;

public class DateTimeService : IDateTimeService
{

    public DateTime NowUtc => DateTime.UtcNow;

}
