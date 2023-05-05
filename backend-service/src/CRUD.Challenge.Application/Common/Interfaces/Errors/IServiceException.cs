using System;
using System.Net;

namespace CRUD.Challenge.Application.Common.Interfaces.Errors;

public interface IServiceException
{
    public HttpStatusCode StatusCode { get; }
    public string ErrorMessage { get; }
}


