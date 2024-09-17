using WorkoutTracker.Application.Interfaces.Repositories;
using WorkoutTracker.Database.Entities;

namespace WorkoutTracker.Application.Interfaces
{
	public interface IUserRepository : IGenericRepository<User>
	{
		Task<User?> FindByEmail(string email);
	}
}