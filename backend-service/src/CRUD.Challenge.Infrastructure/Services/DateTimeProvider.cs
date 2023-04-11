using System;
using CRUD.Challenge.Application.Common.Interfaces.Services;

namespace CRUD.Challenge.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}

