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
		public ApplicationDbContext _dbContext { get; set; }
		public IUserRepository _repository { get; set; }

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
			var testEntity = User.Create(UserModel.Create("username", "email", "password"));
			var testMethod = await _repository.SaveUser(testEntity);

			Assert.NotNull(testMethod);
			Assert.IsType<User>(testMethod);
		}
	}
}