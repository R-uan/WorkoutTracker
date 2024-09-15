using System;

namespace WorkoutTracker.Application.Models
{
	public class ExerciseModel
	{
		public string? Description { get; set; }
		public required string Name { get; set; }
		public required string Category { get; set; }
		public required string MuscleGroup { get; set; }
	}
}
