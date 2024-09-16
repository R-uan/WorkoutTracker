using System;
using WorkoutTracker.Application.Models;

namespace WorkoutTracker.Database.Entities;

public class Workout
{
	public Guid Id { get; set; }
	public Guid UserId { get; set; }
	public int Duration { get; set; }
	public string? Description { get; set; }
	public required string Name { get; set; }
	public required DateTime Date { get; set; }

	public User? User { get; set; }
	public List<ExerciseRecord>? ExerciseRecords { get; set; }

	public static Workout Create(Guid userId, string name, DateTime date, int duration, string? description)
	{
		return new Workout()
		{
			Id = Guid.NewGuid(),
			Name = name,
			UserId = userId,
			Date = date,
			Description = description,
			Duration = duration,
		};
	}

	public static Workout FromModel(WorkoutModel model, Guid userId)
	{
		return new Workout()
		{
			Id = Guid.NewGuid(),
			UserId = userId,
			Name = model.Name,
			Date = model.Date,
			Duration = model.Duration,
			Description = model.Description,
		};
	}
}
