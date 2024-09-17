using WorkoutTracker.Application.Models;
using WorkoutTracker.Database.Entities;

namespace WorkoutTracker.Application.Interfaces.Services
{
	public interface IWorkoutService
	{
		Task<Workout> FindByGuid(Guid workoutGuid);
		Task<bool> DeleteByGuid(Guid workoutGuid);
		Task<List<Workout>> FindUsersWorkouts(Guid userGuid);
		Task<Workout> Create(WorkoutModel workoutModel, Guid userGuid);
	}
}