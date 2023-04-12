using System;
using CRUD.Challenge.Application.Authentication.Commands.Register;
using CRUD.Challenge.Application.Authentication.Common;
using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace CRUD.Challenge.Application.Behaviors;

public class ValidationBehavior : IPipelineBehavior<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IValidator<RegisterCommand> _validator;

    public ValidationBehavior(IValidator<RegisterCommand> validator)
    {
        _validator = validator;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand request, RequestHandlerDelegate<ErrorOr<AuthenticationResult>> next, CancellationToken cancellationToken)
    {
        ValidationResult validationResult = await _validator.ValidateAsync(request);
        if (validationResult.IsValid)
        {
            return await next();
        }

       var errors = validationResult.Errors
            .Select(validationFailure => Error.Validation(validationFailure.PropertyName, validationFailure.ErrorMessage))
            .ToList();

        return errors;
    }
}

