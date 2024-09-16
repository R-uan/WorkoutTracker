using System;
using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Application.Core.Repositories;
using WorkoutTracker.Application.Interfaces.Repositories;
using WorkoutTracker.Database;
using WorkoutTracker.Database.Entities;

namespace Tests.Application.Repositories
{
	public class WorkoutRepositoryTests
	{
		public readonly ApplicationDbContext _dbContext;
		public readonly IWorkoutRepository _workoutRepository;

		public WorkoutRepositoryTests()
		{
			var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase").Options;

			_dbContext = new ApplicationDbContext(dbOptions);
			_workoutRepository = new WorkoutRepository(_dbContext);
		}

		[Fact]
		public async Task FindByGuid_ShouldReturnWorkoutEntity()
		{
			var testEntity = Workout.Create(Guid.NewGuid(), "name", DateTime.Now, 0, null);
			await _dbContext.Workout.AddAsync(testEntity);
			await _dbContext.SaveChangesAsync();

			var testMethod = await _workoutRepository.FindByGuid(testEntity.Id);

			Assert.NotNull(testMethod);
			Assert.Equal(testEntity, testMethod);
		}

		[Fact]
		public async Task FindByGuid_ShouldReturnNull()
		{
			var testMethod = await _workoutRepository.FindByGuid(Guid.NewGuid());
			Assert.Null(testMethod);
		}

		[Fact]
		public async Task SaveWorkout_ShouldReturnWorkoutEntity()
		{
			var testEntity = Workout.Create(Guid.NewGuid(), "name", DateTime.Now, 0, null);
			var testMethod = await _workoutRepository.Save(testEntity);

			Assert.NotNull(testMethod);
			Assert.IsType<Workout>(testMethod);
		}

		[Fact]
		public async Task FindUsersWorkouts_ShouldReturnWorkoutList()
		{
			var testUserGuid = Guid.NewGuid();
			var testEntity = Workout.Create(testUserGuid, "name", DateTime.Now, 0, null);
			await _dbContext.Workout.AddAsync(testEntity);
			await _dbContext.SaveChangesAsync();

			var testMethod = await _workoutRepository.FindUsersWorkouts(testUserGuid);
			Assert.NotNull(testMethod);
			Assert.Single(testMethod);
		}
	}
}
