using WorkoutTracker.Application.Models;
using WorkoutTracker.Application.Utilities;

namespace WorkoutTracker.Database.Entities
{
	public class User
	{
		public Guid Id { get; set; }
		public required string Username { get; set; }
		public required string Email { get; set; }
		public required string PasswordHash { get; set; }

		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }

		public List<Workout>? Workouts { get; set; }

		public static User Create(string username, string email, string password)
		{
			string hashPassword = PasswordEncryption.Hash(password);

			return new User
			{
				Id = Guid.NewGuid(),
				Email = email,
				Username = username,
				PasswordHash = hashPassword,

				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
			};

		}

		public static User FromModel(UserModel user)
		{
			string hashPassword = PasswordEncryption.Hash(user.Password);

			return new User
			{
				Id = Guid.NewGuid(),
				Email = user.Email,
				Username = user.Username,
				PasswordHash = hashPassword,

				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
			};
		}
	}
}