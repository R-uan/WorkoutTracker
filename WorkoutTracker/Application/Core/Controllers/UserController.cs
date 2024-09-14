using Microsoft.AspNetCore.Mvc;
using WorkoutTracker.Application.Interfaces;
using WorkoutTracker.Application.Models;

namespace WorkoutTracker.Application.Controllers
{
	[ApiController, Route("api/user")]
	public sealed class UserController(IUserService _service) : ControllerBase
	{
		[HttpPost("/")]
		public async Task<IActionResult> RegisterUserProfile([FromBody] UserModel user)
		{
			return Ok();
		}
	}
}