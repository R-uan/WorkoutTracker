using System;
using WorkoutTracker.Database.Entities;

namespace WorkoutTracker.Application.Interfaces.Repositories;

public interface IWorkoutRepository : IGenericRepository<Workout>
{
	Task<List<Workout>> FindUsersWorkouts(Guid userId);
}
