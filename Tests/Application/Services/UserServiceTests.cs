using System;
using Moq;
using WorkoutTracker.Application.Interfaces;
using WorkoutTracker.Application.Models;
using WorkoutTracker.Application.Services;
using WorkoutTracker.Database.Entities;

namespace Tests.Application.Services
{
	public class UserServiceTests
	{
		public readonly IUserService _service;
		public readonly Mock<IUserRepository> _mockRepository;

		public UserServiceTests()
		{
			_mockRepository = new Mock<IUserRepository>();
			_service = new UserService(_mockRepository.Object);
		}

		[Fact]
		public async Task CreateNewUserTest_ShouldReturnAUserModelEntity()
		{
			var testEntity = UserModel.Create("username", "email", "password");
			_mockRepository.Setup(repo => repo.SaveNew(It.IsAny<User>())).ReturnsAsync(User.FromModel(testEntity));

			var testMethod = await _service.CreateNewUser(testEntity);

			_mockRepository.Verify(repo => repo.SaveNew(It.IsAny<User>()), Times.Once);

			Assert.NotNull(testMethod);
			Assert.IsType<UserModel>(testMethod);
		}
	}
}