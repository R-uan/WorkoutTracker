namespace WorkoutTracker.Application.Utilities
{
	public class PasswordEncryption
	{
		public static String Hash(String password)
		{
			return BC.HashPassword(password);
		}

		public static bool Verify(String rawPassword, String hashedPassword)
		{
			return BC.Verify(rawPassword, hashedPassword);
		}
	}
}