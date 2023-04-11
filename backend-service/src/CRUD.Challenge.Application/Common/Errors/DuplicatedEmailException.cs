using System;
using System.Net;
using CRUD.Challenge.Application.Common.Interfaces.Errors;

namespace CRUD.Challenge.Application.Common.Errors;

public class DuplicatedEmailException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

    public string ErrorMessage => "Email already exits";
}

