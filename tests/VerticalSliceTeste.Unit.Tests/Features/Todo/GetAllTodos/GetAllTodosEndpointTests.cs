using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;
using NSubstitute;
using VerticalSliceMinimalApi.Features.Todo;
using VerticalSliceMinimalApi.Features.Todo.GetAllTodos;

namespace VerticalSliceMinimalApi.Unit.Tests.Features.Todo.GetAllTodos
{
    public class GetAllTodosEndpointTests
    {
        [Fact]
        public async Task GetAllTodos_WithData_ReturnsItems()
        {
            // Arrange
            var items = new[]
            {
                new TodoEntity
                {
                    Id = Guid.NewGuid(),
                    Text = "My todo item"
                }
            };

            var repo = Substitute.For<ITodoRepository>();
            repo.GetAllAsync(Arg.Any<CancellationToken>()).Returns(x => Task.FromResult<IEnumerable<TodoEntity>>(items));

            // Act
            var result = await new GetAllTodosEndpoint().HandleAsync(repo, CancellationToken.None);

            // Assert
            result.Should().BeOfType<Ok<IEnumerable<TodoEntity>>>()
                .Which.Value.Should().BeEquivalentTo(items);
        }
    }
}