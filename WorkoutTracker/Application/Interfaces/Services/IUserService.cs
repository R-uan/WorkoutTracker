using WorkoutTracker.Application.Models;

namespace WorkoutTracker.Application.Interfaces
{
	public interface IUserService
	{
		Task<UserModel> RegisterUser(UserModel data);
	}
}