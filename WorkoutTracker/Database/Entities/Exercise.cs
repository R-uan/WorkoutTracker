using System;
using WorkoutTracker.Application.Models;

namespace WorkoutTracker.Database.Entities;

public class Exercise
{
	public Guid Id { get; set; }
	public required string Name { get; set; }
	public required string Category { get; set; }
	public required string MuscleGroup { get; set; }
	public string? Description { get; set; }
	public List<ExerciseRecord>? ExerciseRecords { get; set; }

	public static Exercise Create(string name, string category, string muscleGroup, string? description)
	{
		return new Exercise()
		{
			Id = Guid.NewGuid(),
			Name = name,
			Category = category,
			MuscleGroup = muscleGroup,
			Description = description,
		};
	}

	public static Exercise FromModel(ExerciseModel model)
	{
		return new Exercise()
		{
			Id = Guid.NewGuid(),
			Category = model.Category,
			MuscleGroup = model.MuscleGroup,
			Name = model.Name,
			Description = model.Description,
		};
	}
}
