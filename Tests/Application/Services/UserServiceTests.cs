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
		public async Task RegisterUserTest_ShouldReturnAUserModelEntity()
		{
			var testEntity = UserModel.Create("username", "email", "password");
			_mockRepository.Setup(repo => repo.SaveUser(It.IsAny<User>())).ReturnsAsync(User.Create(testEntity));

			var testMethod = await _service.RegisterUser(testEntity);

			_mockRepository.Verify(repo => repo.SaveUser(It.IsAny<User>()), Times.Once);

			Assert.NotNull(testMethod);
			Assert.IsType<UserModel>(testMethod);
		}
	}
}