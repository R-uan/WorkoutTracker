using System.Text.Json.Serialization;
using WorkoutTracker.Database.Entities;

namespace WorkoutTracker.Application.Models
{
	public sealed class UserModel
	{
		public required string Email { get; set; }
		public required string Username { get; set; }

		[JsonIgnore]
		public required string Password { get; set; }

		public static UserModel Create(User user)
		{
			return new UserModel
			{
				Email = user.Email,
				Username = user.Username,
				Password = user.PasswordHash
			};
		}

		public static UserModel Create(string username, string email, string password)
		{
			return new UserModel
			{
				Email = email,
				Username = username,
				Password = password
			};
		}
	}
}