using System;
using WorkoutTracker.Database.Entities;

namespace WorkoutTracker.Application.Interfaces.Repositories;

public interface IWorkoutRepository
{
	Task<Workout> Save(Workout workout);
	Task<Workout?> FindByGuid(Guid workoutGuid);
	Task<List<Workout>> FindUsersWorkouts(Guid userId);

}
