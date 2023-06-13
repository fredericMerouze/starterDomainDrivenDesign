using CleanArchitecture.Domain.Contracts.Repositories;
using CleanArchitecture.Persistence.Repositories;
using FluentAssertions;
using Moq;
using Xunit;

namespace CleanArchitecture.UnitTests.Features.Task;

public class TaskRepositoryTest
{
    [Fact]
    public void ShouldReturnListOfTasks()
    {
        // Arrange
        var repository = new Mock<ITaskRepository>();
        Guid guid = Guid.NewGuid();
        List<Domain.Entities.Task> tasks = new List<Domain.Entities.Task> {
            new Domain.Entities.Task(guid, "Ma desc"),
            new Domain.Entities.Task(Guid.NewGuid(), "Autre desc")
        };
        repository.Setup(x => x.GetAllTaskForUser()).Returns(tasks);
        // Act
        var results = repository.Object.GetAllTaskForUser();
        // Assert
        results.Should().HaveCount(2);
        results.Should().BeOfType<List<Domain.Entities.Task>>();
        results.First().Description.Should().Be("Ma desc");
        results.First().Id.Should().Be(guid);
    }
}
