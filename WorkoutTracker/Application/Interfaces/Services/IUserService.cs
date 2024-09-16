using WorkoutTracker.Application.Models;

namespace WorkoutTracker.Application.Interfaces
{
	public interface IUserService
	{
		Task<UserModel> CreateNewUser(UserModel data);
	}
}