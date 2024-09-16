using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracker.Application.Core.Services;
using WorkoutTracker.Application.Interfaces.Repositories;
using WorkoutTracker.Application.Interfaces.Services;
using WorkoutTracker.Database.Entities;

namespace Tests.Application.Services
{
  public class ExerciseServiceTests
  {
    public readonly IExerciseService _exerciseService;
    public readonly Mock<IExerciseRepository> _mockRepository;

    public ExerciseServiceTests()
    {
      _mockRepository = new Mock<IExerciseRepository>();
      _exerciseService = new ExerciseService(_mockRepository.Object);
    }

    [Fact]
    public async Task FindByGuid_ShouldReturnExerciseEntity()
    {
      var testExercise = Exercise.Create("name", "category", "muscleGroup", null);
      _mockRepository.Setup(repo => repo.FindByGuid(It.IsAny<Guid>())).ReturnsAsync(testExercise);

      var find = await _exerciseService.FindByGuid(testExercise.Id);
      Assert.NotNull(find);
      Assert.IsType<Exercise>(find);
    }

    [Fact]
    public async Task FindByGuid_ShouldThrowKeyNotFoundException()
    {
      _mockRepository.Setup(repo => repo.FindByGuid(It.IsAny<Guid>())).ReturnsAsync((Exercise)null!);

      var exception = await Assert.ThrowsAsync<KeyNotFoundException>(
          async () => await _exerciseService.FindByGuid(Guid.NewGuid())
      );

      Assert.Equal("Could not find Exercise.", exception.Message);
    }
  }
}
