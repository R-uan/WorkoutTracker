using System;
using FluentValidation;
using WorkoutTracker.Application.Models;
using WorkoutTracker.Database.Entities;

namespace WorkoutTracker.Application.Utilities.Validators
{
	public class UserModelValidator : AbstractValidator<UserModel>
	{
		public UserModelValidator()
		{
			RuleFor(user => user.Password)
			.NotEmpty().WithMessage("Missing 'Password' property.")
			.MaximumLength(12).WithMessage("Password can only have 12 characters")
			.MinimumLength(8).WithMessage("Password needs to have at least 8 characters");

			RuleFor(user => user.Username).NotEmpty().WithMessage("Missing 'Username' property.");
			RuleFor(user => user.Email).NotEmpty().EmailAddress().WithMessage("Missing 'Email' property.");
		}
	}
}