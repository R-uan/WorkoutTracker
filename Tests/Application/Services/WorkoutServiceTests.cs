using System;
using Moq;
using WorkoutTracker.Application.Core.Services;
using WorkoutTracker.Application.Interfaces;
using WorkoutTracker.Application.Interfaces.Repositories;
using WorkoutTracker.Application.Interfaces.Services;
using WorkoutTracker.Application.Models;
using WorkoutTracker.Database.Entities;

namespace Tests.Application.Services;

public class WorkoutServiceTests
{
	public readonly IWorkoutService _workoutService;
	public readonly Mock<IUserRepository> _mockUserRepository;
	public readonly Mock<IWorkoutRepository> _mockWorkoutRepository;

	public WorkoutServiceTests()
	{
		_mockUserRepository = new Mock<IUserRepository>();
		_mockWorkoutRepository = new Mock<IWorkoutRepository>();
		_workoutService = new WorkoutService(_mockWorkoutRepository.Object, _mockUserRepository.Object);
	}

	[Fact]
	public async Task CreateWorkoutTest_ShouldReturnAWorkoutEntity()
	{
		var testUser = User.Create("username", "email", "Password");
		var testWorkout = WorkoutModel.Create("name", DateTime.Now, 0, null);

		_mockUserRepository.Setup(u => u.FindUserByGuid(It.IsAny<Guid>())).ReturnsAsync(testUser);
		_mockWorkoutRepository.Setup(w => w.Save(It.IsAny<Workout>())).ReturnsAsync(Workout.FromModel(testWorkout, testUser.Id));

		var createWorkout = await _workoutService.CreateWorkout(testWorkout, testUser.Id);

		Assert.NotNull(createWorkout);
		Assert.IsType<Workout>(createWorkout);
	}

	[Fact]
	public async Task CreateWorkoutTest_ShouldThrowKeyNotFoundException()
	{
		var workout = WorkoutModel.Create("name", DateTime.Now, 0, null);

		_mockUserRepository.Setup(u => u.FindUserByGuid(It.IsAny<Guid>())).ReturnsAsync((User)null!);

		var exception = await Assert.ThrowsAsync<KeyNotFoundException>(
			async () => await _workoutService.CreateWorkout(workout, Guid.NewGuid())
		);

		Assert.IsType<KeyNotFoundException>(exception);
		Assert.Equal("User was not found.", exception.Message);
	}

	[Fact]
	public async Task FindWorkoutByGuidTest_ShouldReturnWorkoutEntity()
	{
		var testWorkout = WorkoutModel.Create("name", DateTime.Now, 0, null);

		_mockWorkoutRepository.Setup(w => w.FindByGuid(It.IsAny<Guid>()))
		.ReturnsAsync(Workout.FromModel(testWorkout, Guid.NewGuid()));

		var findWorkout = await _workoutService.FindWorkoutByGuid(Guid.NewGuid());

		Assert.NotNull(findWorkout);
		Assert.IsType<Workout>(findWorkout);
	}

	[Fact]
	public async Task FindWorkoutByGuidTest_ShouldThrowKeyNotFoundException()
	{
		_mockWorkoutRepository.Setup(w => w.FindByGuid(It.IsAny<Guid>())).ReturnsAsync((Workout)null!);

		var exception = await Assert.ThrowsAsync<KeyNotFoundException>(
			async () => await _workoutService.FindWorkoutByGuid(Guid.NewGuid())
		);

		Assert.IsType<KeyNotFoundException>(exception);
		Assert.Equal("Workout was not found.", exception.Message);
	}

	[Fact]
	public async Task FindUsersWorkouts_ShouldReturnListOfWorkoutEntities()
	{
		var testUser = User.Create("username", "email", "Password");
		var testWorkout = WorkoutModel.Create("name", DateTime.Now, 0, null);

		_mockUserRepository.Setup(u => u.FindUserByGuid(It.IsAny<Guid>())).ReturnsAsync(testUser);
		_mockWorkoutRepository.Setup(w => w.FindUsersWorkouts(testUser.Id))
		.ReturnsAsync([Workout.FromModel(testWorkout, testUser.Id)]);

		var findWorkouts = await _workoutService.FindUsersWorkouts(testUser.Id);

		Assert.NotNull(findWorkouts);
		Assert.IsType<List<Workout>>(findWorkouts);
	}

	[Fact]
	public async Task FindUsersWorkouts_ShouldThrowKeyNotFoundException()
	{
		var workout = WorkoutModel.Create("name", DateTime.Now, 0, null);

		_mockUserRepository.Setup(u => u.FindUserByGuid(It.IsAny<Guid>())).ReturnsAsync((User)null!);

		var exception = await Assert.ThrowsAsync<KeyNotFoundException>(
			async () => await _workoutService.FindUsersWorkouts(Guid.NewGuid())
		);

		Assert.IsType<KeyNotFoundException>(exception);
		Assert.Equal("User was not found.", exception.Message);
	}
}
