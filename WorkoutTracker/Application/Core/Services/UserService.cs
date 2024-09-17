using WorkoutTracker.Application.Interfaces;
using WorkoutTracker.Application.Models;
using WorkoutTracker.Database.Entities;

namespace WorkoutTracker.Application.Services
{
	public sealed class UserService(IUserRepository _service) : IUserService
	{
		public async Task<UserModel> CreateNewUser(UserModel data)
		{
			var user = User.FromModel(data);
			var savedUser = await _service.SaveNew(user);
			return UserModel.Create(savedUser);
		}

		public async Task<User> FindByEmail(string email)
		{
			return await _service.FindByEmail(email) ??
			throw new KeyNotFoundException("Unable to find user associated with given email.");
		}
	}
}