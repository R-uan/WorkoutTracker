using System;
using WorkoutTracker.Application.Interfaces;
using WorkoutTracker.Application.Interfaces.Repositories;
using WorkoutTracker.Application.Interfaces.Services;
using WorkoutTracker.Application.Models;
using WorkoutTracker.Database.Entities;

namespace WorkoutTracker.Application.Core.Services;

public class WorkoutService(IWorkoutRepository _workoutRepository, IUserRepository _userRepository) : IWorkoutService
{
	public async Task<Workout> Create(WorkoutModel workoutModel, Guid userGuid)
	{
		_ = await _userRepository.FindByGuid(userGuid) ??
		throw new KeyNotFoundException("User was not found.");
		return await _workoutRepository.SaveNew(Workout.FromModel(workoutModel, userGuid));
	}

	public async Task<List<Workout>> FindUsersWorkouts(Guid userGuid)
	{
		_ = await _userRepository.FindByGuid(userGuid) ??
		throw new KeyNotFoundException("User was not found.");
		return await _workoutRepository.FindUsersWorkouts(userGuid);
	}

	public async Task<Workout> FindByGuid(Guid workoutGuid)
	{
		return await _workoutRepository.FindByGuid(workoutGuid) ??
		throw new KeyNotFoundException("Workout was not found.");
	}

	public async Task<bool> DeleteByGuid(Guid workoutGuid)
	{
		var exercise = await _workoutRepository.FindByGuid(workoutGuid) ??
		throw new KeyNotFoundException("Could not find workout.");
		return await _workoutRepository.Delete(exercise);
	}
}
