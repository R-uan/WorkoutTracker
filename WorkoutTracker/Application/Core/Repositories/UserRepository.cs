using WorkoutTracker.Application.Interfaces;
using WorkoutTracker.Database;
using WorkoutTracker.Database.Entities;

namespace WorkoutTracker.Application.Repositories
{
	public sealed class UserRepository(ApplicationDbContext _db) : IUserRepository
	{
		public async Task<User> SaveUser(User user)
		{
			var save = await _db.User.AddAsync(user);
			await _db.SaveChangesAsync();
			return save.Entity;
		}
	}
}