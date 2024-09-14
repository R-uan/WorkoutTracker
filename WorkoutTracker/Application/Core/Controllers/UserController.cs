using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WorkoutTracker.Application.Interfaces;
using WorkoutTracker.Application.Models;

namespace WorkoutTracker.Application.Controllers
{
	[ApiController, Route("api/user")]
	public sealed class UserController(IUserService _service, IValidator<UserModel> _validator) : ControllerBase
	{
		[HttpPost("/")]
		public async Task<IActionResult> RegisterUserProfile([FromBody] UserModel user)
		{
			try
			{
				var validate = _validator.Validate(user);
				if (!validate.IsValid) return BadRequest(validate.Errors);
				var registration = await _service.RegisterUser(user);
				return Ok(registration);
			}
			catch (System.Exception ex)
			{
				return StatusCode(500, ex);
			}
		}
	}
}