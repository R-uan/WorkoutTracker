using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Application.Interfaces;
using WorkoutTracker.Database;
using WorkoutTracker.Database.Entities;

namespace WorkoutTracker.Application.Repositories
{
	public sealed class UserRepository(ApplicationDbContext _db) : IUserRepository
	{
		public async Task<User?> FindByGuid(Guid userGuid) => await _db.User.FindAsync(userGuid);

		public async Task<User> SaveNew(User user)
		{
			var save = await _db.User.AddAsync(user);
			await _db.SaveChangesAsync();
			return save.Entity;
		}

		public async Task<bool> Delete(User entity)
		{
			_db.User.Remove(entity);
			var deletions = await _db.SaveChangesAsync();
			return deletions > 0;
		}

		public async Task<User?> FindByEmail(string email)
		{
			return await (from user in _db.User
										where user.Email == email
										select user).FirstOrDefaultAsync();
		}
	}
}