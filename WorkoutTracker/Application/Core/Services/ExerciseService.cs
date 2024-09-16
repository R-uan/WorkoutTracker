using System;
using WorkoutTracker.Application.Interfaces.Repositories;
using WorkoutTracker.Application.Interfaces.Services;
using WorkoutTracker.Application.Models;
using WorkoutTracker.Database.Entities;

namespace WorkoutTracker.Application.Core.Services;

public class ExerciseService(IExerciseRepository _repository) : IExerciseService
{
	public Task<List<Exercise>> FindAll()
	{
		throw new NotImplementedException();
	}

	public async Task<Exercise> FindByGuid(Guid guid)
	{
		return await _repository.FindByGuid(guid) ??
		throw new KeyNotFoundException("Could not find Exercise.");
	}

	public async Task<Exercise> CreateExercise(ExerciseModel model)
	{
		var exercise = Exercise.FromModel(model);
		return await _repository.SaveNew(exercise);
	}

	public async Task<bool> Delete(Guid exerciseId)
	{
		var exercise = await this.FindByGuid(exerciseId);
		return await _repository.Delete(exercise);
	}
}
