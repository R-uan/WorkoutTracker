using System;
using Microsoft.AspNetCore.Authentication;
using WorkoutTracker.Application.Interfaces;
using WorkoutTracker.Application.Interfaces.Services;
using WorkoutTracker.Application.Utilities;

namespace WorkoutTracker.Application.Core.Services
{
	public class AuthService(IUserService userService) : IAuthService
	{
		public async Task<bool> AuthenticateCredentials(string email, string password)
		{
			var findUser = await userService.FindByEmail(email);
			var verifyPassword = PasswordEncryption.Verify(password, findUser.PasswordHash);
			if (!verifyPassword) throw new AuthenticationFailureException("Failed authorization.");
			return true;
		}
	}
}
