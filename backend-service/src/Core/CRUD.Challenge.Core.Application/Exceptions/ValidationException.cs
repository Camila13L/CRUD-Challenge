namespace CRUD.Challenge.Core.Application.Exceptions;

using System;
using FluentValidation.Results;

public class ValidationException : Exception
{

    public List<string> Errors { get; }

    public ValidationException() : base("One or more validation errors found")
    {
        Errors = new List<string>();
    }

    public ValidationException(IEnumerable<ValidationFailure> failures) : this()
    {
        foreach (var failure in failures)
        {
            this.Errors.Add(failure.ErrorMessage);
        }
    }
}

