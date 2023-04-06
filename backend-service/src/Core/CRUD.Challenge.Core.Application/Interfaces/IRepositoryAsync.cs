namespace CRUD.Challenge.Core.Application.Interfaces;
using System;
using Ardalis.Specification;

public interface IRepositoryAsync<T> : IRepositoryBase<T> where T : class
{
}
public interface IReadRepositoryAsync<T> : IReadRepositoryBase<T> where T : class
{
}

