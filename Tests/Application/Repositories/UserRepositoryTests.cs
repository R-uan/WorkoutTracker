using System;
using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Application.Interfaces;
using WorkoutTracker.Application.Models;
using WorkoutTracker.Application.Repositories;
using WorkoutTracker.Database;
using WorkoutTracker.Database.Entities;

namespace Tests.Application.Repositories
{
	public class UserRepositoryTests
	{
		public readonly IUserRepository _repository;
		public readonly ApplicationDbContext _dbContext;

		public UserRepositoryTests()
		{
			var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase").Options;

			_dbContext = new ApplicationDbContext(dbOptions);
			_repository = new UserRepository(_dbContext);
		}

		[Fact]
		public async Task CreateUserTest_ShouldReturnUserEntity()
		{
			var testEntity = User.FromModel(UserModel.Create("username", "email", "password"));
			var testMethod = await _repository.SaveNew(testEntity);

			Assert.NotNull(testMethod);
			Assert.IsType<User>(testMethod);
		}

		[Fact]
		public async Task FindByGuid_ShouldReturnUserEntity()
		{
			var testUser = User.Create("username", "email", "password");
			await _dbContext.User.AddAsync(testUser);
			await _dbContext.SaveChangesAsync();

			var testMethod = await _repository.FindByGuid(testUser.Id);
			Assert.NotNull(testMethod);
			Assert.IsType<User>(testMethod);
		}

		[Fact]
		public async Task FindByGuid_ShouldReturnNull()
		{
			var testMethod = await _repository.FindByGuid(Guid.NewGuid());
			Assert.Null(testMethod);
		}

		[Fact]
		public async Task DeleteTest_ShouldReturnTrue()
		{
			var testUser = User.Create("username", "email", "password");
			await _dbContext.User.AddAsync(testUser);
			await _dbContext.SaveChangesAsync();

			var deleteEntity = await _dbContext.User.FindAsync(testUser.Id);
			var testMethod = await _repository.Delete(deleteEntity!);

			Assert.True(testMethod);
		}
	}
}