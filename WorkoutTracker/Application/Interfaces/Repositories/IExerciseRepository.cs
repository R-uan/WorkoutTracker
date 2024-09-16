using System;
using WorkoutTracker.Application.Models;
using WorkoutTracker.Database.Entities;

namespace WorkoutTracker.Application.Interfaces.Repositories;

public interface IExerciseRepository : IGenericRepository<Exercise>
{
	Task<bool> Update(Exercise target, ExerciseUpdateModel update);
}
