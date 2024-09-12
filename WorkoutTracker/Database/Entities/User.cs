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
			return new User
			{
				Id = Guid.NewGuid(),
				Username = username,
				Email = email,
#warning Should hash password
				PasswordHash = password,
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			};
		}
	}
}