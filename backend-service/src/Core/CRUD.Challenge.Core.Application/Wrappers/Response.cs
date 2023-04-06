﻿using System;
namespace CRUD.Challenge.Core.Application.Wrappers;

public class Response<T>
{
    public Response()
    {

    }

    public Response(T data, string message = "")
    {
        this.Succeeded = true;
        this.Message = message;
        this.Data = data;
    }

    public Response(string message)
    {
        this.Succeeded = false;
        this.Message = message;
    }

    public bool Succeeded { get; set; }
    public string Message { get; set; } = string.Empty;
    public List<string> Error { get; set; }
    public T Data { get; set; }

}

