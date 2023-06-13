using CleanArchitecture.Application.Features.Task.Query;
using CleanArchitecture.Application.Features.Task.Query.GetAllTaskForUser;
using CleanArchitecture.Domain.Contracts.Repositories;
using DotNext;
using FluentAssertions;
using Moq;
using Xunit;

namespace CleanArchitecture.UnitTests.Features.Task;

public class GetAllTaskForUserQueryHandlerTest
{
    [Fact]
    public async System.Threading.Tasks.Task ShouldReturnListOfTasks()
    {
        // Arrange
        var repository = new Mock<ITaskRepository>();
        var handler = new GetAllTaskForUserQueryHandler(repository.Object);
        var query = new GetAllTaskForUserQuery();
        Guid guid = Guid.NewGuid();
        List<Domain.Entities.Task> tasks = new List<Domain.Entities.Task> {
            new Domain.Entities.Task(guid, "Ma desc"),
            new Domain.Entities.Task(Guid.NewGuid(), "Autre desc")
        };
        repository.Setup(x => x.GetAllTaskForUser()).Returns(tasks);
        // Act
        Result<List<Domain.Entities.Task>> results = await handler.Handle(query, default);
        // Assert
        results.IsSuccessful.Should().BeTrue();
        results.Value.Should().HaveCount(2);
        results.Error.Should().BeNull();
        results.Value.Should().BeOfType<List<Domain.Entities.Task>>();
        results.Value.First().Description.Should().Be("Ma desc");
        results.Value.First().Id.Should().Be(guid);
    }
}
