using System;
using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Application.Interfaces.Repositories;
using WorkoutTracker.Database;
using WorkoutTracker.Database.Entities;

namespace WorkoutTracker.Application.Core.Repositories;

public class WorkoutRepository(ApplicationDbContext _db) : IWorkoutRepository
{
	public async Task<List<Workout>> FindUsersWorkouts(Guid userId)
	{
		return await (from workout in _db.Workout
									where workout.UserId == userId
									select workout).ToListAsync();
	}

	public async Task<Workout?> FindByGuid(Guid workoutGuid) => await _db.Workout.FindAsync(workoutGuid);

	public async Task<Workout> SaveNew(Workout workout)
	{
		var save = await _db.Workout.AddAsync(workout);
		await _db.SaveChangesAsync();
		return save.Entity;
	}

	public async Task<bool> Delete(Workout entity)
	{
		_db.Workout.Remove(entity);
		var deletions = await _db.SaveChangesAsync();
		return deletions > 0;
	}
}
