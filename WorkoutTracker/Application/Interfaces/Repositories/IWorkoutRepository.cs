using System;
using WorkoutTracker.Database.Entities;

namespace WorkoutTracker.Application.Interfaces.Repositories;

public interface IWorkoutRepository
{
	Task<Workout> SaveWorkout(Workout workout);
	Task<Workout?> FindWorkoutByGuid(Guid workoutGuid);
	Task<List<Workout>> FindUsersWorkouts(Guid userId);

}
