using System;
using System.Net;
using FluentResults;

namespace CRUD.Challenge.Application.Common.Errors;

public class DuplicatedEmailError : IError
{
    public List<IError> Reasons => throw new NotImplementedException();

    public string Message => throw new NotImplementedException();

    public Dictionary<string, object> Metadata => throw new NotImplementedException();
}
