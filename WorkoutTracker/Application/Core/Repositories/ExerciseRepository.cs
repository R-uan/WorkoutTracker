using System;
using WorkoutTracker.Application.Interfaces.Repositories;
using WorkoutTracker.Application.Models;
using WorkoutTracker.Database;
using WorkoutTracker.Database.Entities;

namespace WorkoutTracker.Application.Core.Repositories;

public class ExerciseRepository(ApplicationDbContext _db) : IExerciseRepository
{
	public Task<bool> DeleteExercise(Exercise exercise)
	{
		throw new NotImplementedException();
	}

	public Task<Exercise?> FindExerciseByGuid(Guid guid)
	{
		throw new NotImplementedException();
	}

	public Task<Exercise> SaveExercise(Exercise exercise)
	{
		throw new NotImplementedException();
	}

	public async Task<Exercise> UpdateExercise(Exercise target, ExerciseUpdateModel update)
	{
		throw new NotImplementedException();
	}
}
