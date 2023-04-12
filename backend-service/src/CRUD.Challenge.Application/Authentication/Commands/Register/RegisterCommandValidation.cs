using System;
using CRUD.Challenge.Application.Authentication.Commands.Register;
using FluentValidation;

namespace CRUD.Challenge.Application.Authentication.Commands;

public class RegisterCommandValidation : AbstractValidator<RegisterCommand> 
{
	public RegisterCommandValidation()
	{
		RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.Email).EmailAddress().NotEmpty();
        RuleFor(x => x.Password).MinimumLength(6).NotEmpty();
    }
}

