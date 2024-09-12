using System;

namespace WorkoutTracker.Database.Entities;

public class ExerciseRecord
{
	public Guid Id { get; set; }
	public Guid WorkoutId { get; set; }
	public Guid ExerciseId { get; set; }
	public int Sets { get; set; }
	public int Reps { get; set; }
	public float Weight { get; set; }
	public int Duration { get; set; }

	public Workout? Workout { get; set; }
	public Exercise? Exercise { get; set; }

	public static ExerciseRecord Create(Guid workoutId, Guid exerciseId, int sets, int reps, float weight, int duration)
	{
		return new ExerciseRecord
		{
			Id = Guid.NewGuid(),
			WorkoutId = workoutId,
			ExerciseId = exerciseId,
			Reps = reps,
			Sets = sets,
			Weight = weight,
			Duration = duration,
		};
	}
}
