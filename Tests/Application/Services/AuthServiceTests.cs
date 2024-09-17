using System;
using System.Security.Cryptography.X509Certificates;
using Moq;
using WorkoutTracker.Application.Core.Services;
using WorkoutTracker.Application.Interfaces;
using WorkoutTracker.Application.Interfaces.Services;
using WorkoutTracker.Database.Entities;

namespace Tests.Application.Services;

public class AuthServiceTests
{
	public readonly Mock<IUserService> mockUserService;
	public readonly IAuthService authService;

	public AuthServiceTests()
	{
		mockUserService = new Mock<IUserService>();
		authService = new AuthService(mockUserService.Object);
	}

	[Fact]
	public async Task AuthCredentialsTest_ShouldReturnTrue()
	{
		var testUser = User.Create("username", "testingmail@gmail.com", "password");
		mockUserService.Setup(x => x.FindByEmail(It.IsAny<string>())).ReturnsAsync(testUser);

		var testMethod = await authService.AuthenticateCredentials("testingmail@gmail.com", "password");
		mockUserService.Verify(x => x.FindByEmail(It.IsAny<string>()), Times.Once);

		Assert.True(testMethod);
	}
}
