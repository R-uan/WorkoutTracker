using System;

namespace WorkoutTracker.Application.Interfaces.Services
{
	public interface IAuthService
	{
		Task<bool> AuthenticateCredentials(string email, string password);
	}
}