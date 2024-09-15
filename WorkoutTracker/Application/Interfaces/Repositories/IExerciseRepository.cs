using System;
using WorkoutTracker.Application.Models;
using WorkoutTracker.Database.Entities;

namespace WorkoutTracker.Application.Interfaces.Repositories;

public interface IExerciseRepository
{
	Task<bool> DeleteExercise(Exercise exercise);
	Task<Exercise?> FindExerciseByGuid(Guid guid);
	Task<Exercise> SaveExercise(Exercise exercise);
	Task<bool> UpdateExercise(Exercise target, ExerciseUpdateModel update);
}
