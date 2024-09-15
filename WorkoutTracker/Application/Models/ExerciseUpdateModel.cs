using System;

namespace WorkoutTracker.Application.Models
{
	public class ExerciseUpdateModel
	{
		public string? Name { get; set; }
		public string? Category { get; set; }
		public string? Description { get; set; }
		public string? MuscleGroup { get; set; }

		public static ExerciseUpdateModel Create(string? name, string? category, string? muscleGroup, string? description)
		{
			return new ExerciseUpdateModel
			{
				Name = name,
				Category = category,
				MuscleGroup = muscleGroup,
				Description = description,
			};
		}
	}
}
