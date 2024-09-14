using System;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using WorkoutTracker.Application.Models;
using WorkoutTracker.Application.Utilities.Validators;
using FluentValidation.TestHelper;

namespace Tests.Application.Validators
{
	public class UserModelValidatorTests
	{
		public readonly IValidator<UserModel> _validator;

		public UserModelValidatorTests()
		{
			_validator = new UserModelValidator();
		}

		[Fact]
		public void ShouldHaveErrorWhenUsernameIsEmpty()
		{
			var testEntity = UserModel.Create("", "email@gmail.com", "password");
			var validate = _validator.TestValidate(testEntity);
			validate.ShouldHaveValidationErrorFor(user => user.Username);
		}

		[Fact]
		public void ShouldHaveErrorWhenEmailIsEmpty()
		{
			var testEntity = UserModel.Create("username", "", "password");
			var validate = _validator.TestValidate(testEntity);
			validate.ShouldHaveValidationErrorFor(user => user.Email);
		}

		[Fact]
		public void ShouldHaveErrorWhenEmailIsInvalid()
		{
			var testEntity = UserModel.Create("username", "invalidEmail", "password");
			var validate = _validator.TestValidate(testEntity);
			validate.ShouldHaveValidationErrorFor(user => user.Email);
		}

		[Fact]
		public void ShouldHaveNoErrorsWhenEmailIsValid()
		{
			var testEntity = UserModel.Create("username", "email@gmail.com", "password");
			var validate = _validator.TestValidate(testEntity);
			validate.ShouldNotHaveValidationErrorFor(user => user.Email);
		}

		[Fact]
		public void ShoudHaveErrorWhenPasswordIsEmpty()
		{
			var testEntity = UserModel.Create("username", "email@gmail.com", "");
			var validate = _validator.TestValidate(testEntity);
			validate.ShouldHaveValidationErrorFor(user => user.Password);
		}

		[Fact]
		public void ShoudHaveErrorWhenPasswordDoesntMeetMinimiumLength()
		{
			var testEntity = UserModel.Create("username", "email@gmail.com", "12345");
			var validate = _validator.TestValidate(testEntity);
			validate.ShouldHaveValidationErrorFor(user => user.Password);
		}

		[Fact]
		public void ShoudHaveErrorWhenPasswordExceedsMaximunLength()
		{
			var testEntity = UserModel.Create("username", "email@gmail.com", "1234567890222");
			var validate = _validator.TestValidate(testEntity);
			validate.ShouldHaveValidationErrorFor(user => user.Password);
		}

		[Fact]
		public void ShouldHaveNoErrors()
		{
			var testEntity = UserModel.Create("username", "email@gmail.com", "goodPassword");
			var validate = _validator.TestValidate(testEntity);
			validate.ShouldNotHaveAnyValidationErrors();
		}
	}
}
