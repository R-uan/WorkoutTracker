using WorkoutTracker.Database.Entities;

namespace WorkoutTracker.Application.Interfaces
{
	public interface IUserRepository
	{
		Task<User> SaveUser(User user);
		Task<User?> FindUserByGuid(Guid userGuid);
	}
}