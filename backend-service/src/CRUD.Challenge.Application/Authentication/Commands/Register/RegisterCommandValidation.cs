﻿using FluentValidation;

namespace CRUD.Challenge.Application.Authentication.Commands.Register;
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

