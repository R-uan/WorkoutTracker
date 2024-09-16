using System;
using WorkoutTracker.Database.Entities;

namespace WorkoutTracker.Application.Models;

public class WorkoutModel
{
	public required string Name { get; set; }
	public required DateTime Date { get; set; }
	public int Duration { get; set; }
	public string? Description { get; set; }

	public static WorkoutModel Create(string name, DateTime date, int duration, string? description)
	{
		return new WorkoutModel
		{
			Name = name,
			Date = date,
			Duration = duration,
			Description = description,
		};
	}

	public static WorkoutModel FromEntity(Workout entity)
	{
		return new WorkoutModel
		{
			Name = entity.Name,
			Date = entity.Date,
			Duration = entity.Duration,
			Description = entity.Description,
		};
	}
}
