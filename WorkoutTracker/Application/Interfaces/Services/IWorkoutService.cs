using WorkoutTracker.Application.Models;
using WorkoutTracker.Database.Entities;

namespace WorkoutTracker.Application.Interfaces.Services
{
	public interface IWorkoutService
	{
		Task<Workout> FindWorkoutByGuid(Guid workoutGuid);
		Task<List<Workout>> FindUsersWorkouts(Guid userGuid);
		Task<Workout> CreateWorkout(WorkoutModel workoutModel, Guid userGuid);
	}
}