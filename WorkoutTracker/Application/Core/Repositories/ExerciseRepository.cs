using System;
using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Application.Interfaces.Repositories;
using WorkoutTracker.Application.Models;
using WorkoutTracker.Database;
using WorkoutTracker.Database.Entities;

namespace WorkoutTracker.Application.Core.Repositories;

public class ExerciseRepository(ApplicationDbContext _db) : IExerciseRepository
{
	public async Task<bool> DeleteExercise(Exercise exercise)
	{
		_db.Exercise.Remove(exercise);
		var changes = await _db.SaveChangesAsync();
		return changes > 0;
	}

	public async Task<Exercise?> FindExerciseByGuid(Guid guid) => await _db.Exercise.FindAsync(guid);

	public async Task<Exercise> SaveExercise(Exercise exercise)
	{
		var save = await _db.Exercise.AddAsync(exercise);
		await _db.SaveChangesAsync();
		return save.Entity;
	}

	public async Task<bool> UpdateExercise(Exercise target, ExerciseUpdateModel update)
	{
		if (update.Name != null) target.Name = update.Name;
		if (update.Category != null) target.Category = update.Category;
		if (update.MuscleGroup != null) target.MuscleGroup = update.MuscleGroup;
		if (update.Description != null) target.Description = update.Description;

		var changes = await _db.SaveChangesAsync();
		return changes > 0;
	}
}
