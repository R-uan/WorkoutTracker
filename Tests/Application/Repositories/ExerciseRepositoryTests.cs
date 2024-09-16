using System;
using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Application.Core.Repositories;
using WorkoutTracker.Application.Interfaces.Repositories;
using WorkoutTracker.Application.Models;
using WorkoutTracker.Database;
using WorkoutTracker.Database.Entities;

namespace Tests.Application.Repositories
{
	public class ExerciseRepositoryTests
	{
		public readonly ApplicationDbContext _dbContext;
		public readonly IExerciseRepository _exerciseRepository;

		public ExerciseRepositoryTests()
		{
			var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase").Options;

			_dbContext = new ApplicationDbContext(dbOptions);
			_exerciseRepository = new ExerciseRepository(_dbContext);
		}

		[Fact]
		public async Task FindExerciseByIdTest_ShouldReturnExerciseEntity()
		{
			var testEntity = Exercise.Create("name", "category", "muscle group", null);
			await _dbContext.Exercise.AddAsync(testEntity);
			await _dbContext.SaveChangesAsync();

			var testMethod = await _exerciseRepository.FindByGuid(testEntity.Id);

			Assert.NotNull(testMethod);
			Assert.Equal(testEntity, testMethod);
		}

		[Fact]
		public async Task FindExerciseByIdTest_ShouldReturnNullWhenNotFound()
		{
			var testMethod = await _exerciseRepository.FindByGuid(Guid.NewGuid());
			Assert.Null(testMethod);
		}

		[Fact]
		public async Task SaveExerciseTest_ShouldReturnExerciseEntity()
		{
			var testEntity = Exercise.Create("name", "category", "muscle group", null);
			var testMethod = await _exerciseRepository.SaveNew(testEntity);
			var exists = await _dbContext.Exercise.FindAsync(testEntity.Id);

			Assert.NotNull(testMethod);
			Assert.NotNull(exists);
			Assert.Equal(testMethod, exists);
		}

		[Fact]
		public async Task UpdateExerciseTest_ShouldReturnNewExerciseEntity()
		{
			var testEntity = Exercise.Create("name", "category", "muscle group", null);
			var updateEntity = ExerciseUpdateModel.Create("Hello", null, null, null);
			await _dbContext.Exercise.AddAsync(testEntity);
			await _dbContext.SaveChangesAsync();

			var target = await _dbContext.Exercise.FindAsync(testEntity.Id);
			var testMethod = await _exerciseRepository.Update(target!, updateEntity);

			var check = await _dbContext.Exercise.FindAsync(testEntity.Id);
			Assert.True(testMethod);
			Assert.Equal(updateEntity.Name, check!.Name);
			Assert.Equal(testEntity.Category, check.Category);
		}

		[Fact]
		public async Task DeleteExerciseTest_ShouldReturnTrue()
		{
			var testEntity = Exercise.Create("name", "category", "muscle group", null);
			await _dbContext.Exercise.AddAsync(testEntity);
			await _dbContext.SaveChangesAsync();

			var exercise = await _dbContext.Exercise.FindAsync(testEntity.Id);
			var testMethod = await _exerciseRepository.Delete(exercise!);

			Assert.True(testMethod);
		}
	}
}