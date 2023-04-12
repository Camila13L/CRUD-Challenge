using System;
using CRUD.Challenge.Application.Authentication.Commands.Register;
using FluentValidation;

namespace CRUD.Challenge.Application.Authentication.Commands;

public class RegisterCommandValidation : AbstractValidator<RegisterCommand> 
{
	public RegisterCommandValidation()
	{
		RuleFor(x => x.FirstName).NotNull().NotEmpty().WithErrorCode("{PropertyName} cannot be empty");
        RuleFor(x => x.LastName).NotNull().NotEmpty().WithErrorCode("{PropertyName} cannot be empty");
        RuleFor(x => x.Email).EmailAddress().NotEmpty().WithErrorCode("{PropertyName} cannot be empty");
        RuleFor(x => x.Password).MinimumLength(6).NotEmpty().WithErrorCode("{PropertyName} max lentgh 8 ");
    }
}

