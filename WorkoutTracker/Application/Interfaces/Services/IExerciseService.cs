using System;
using WorkoutTracker.Application.Models;
using WorkoutTracker.Database.Entities;

namespace WorkoutTracker.Application.Interfaces.Services;

public interface IExerciseService
{
	Task<bool> DeleteExercise(Guid exerciseId);
	Task<Exercise> CreateExercise(ExerciseModel model);
}
