using System;
using WorkoutTracker.Application.Models;
using WorkoutTracker.Database.Entities;

namespace WorkoutTracker.Application.Interfaces.Services;

public interface IExerciseService
{
	Task<List<Exercise>> FindAll();
	Task<Exercise> FindByGuid(Guid guid);
	Task<Exercise> CreateExercise(ExerciseModel model);
	Task<bool> Delete(Guid exerciseId);
}
