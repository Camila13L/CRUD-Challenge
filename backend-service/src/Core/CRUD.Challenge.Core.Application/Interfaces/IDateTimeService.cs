using System;
namespace CRUD.Challenge.Core.Application.Interfaces;

public interface IDateTimeService
{
    DateTime NowUtc { get; }
}

