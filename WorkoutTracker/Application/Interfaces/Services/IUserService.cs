using WorkoutTracker.Application.Models;
using WorkoutTracker.Database.Entities;

namespace WorkoutTracker.Application.Interfaces
{
	public interface IUserService
	{
		Task<UserModel> CreateNewUser(UserModel data);
		Task<User> FindByEmail(string email);
	}
}