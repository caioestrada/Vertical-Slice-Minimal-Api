using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;
using NSubstitute;
using VerticalSliceMinimalApi.Features.Todo;
using VerticalSliceMinimalApi.Features.Todo.CreateTodo;

namespace VerticalSliceMinimalApi.Unit.Tests.Features.Todo.CreateTodo
{
    public class CreateTodoEndpointTest
    {
        [Theory]
        [InlineData("Description test")]
        public async Task GetAllTodos_WithData_ReturnsItems(string text)
        {
            // Arrange
            var request = new CreateTodoRequest
            {
                Text = text
            };
            
            var repo = Substitute.For<ITodoRepository>();
            repo.AddAsync(Arg.Any<TodoEntity>(), Arg.Any<CancellationToken>()).Returns(x => Task.FromResult(new TodoEntity { Text = text }));

            // Act
            var result = await new CreateTodoEndpoints().HandleAsync(request, repo, CancellationToken.None);

            // Assert
            result.Should().BeOfType<Created>();
        }
    }
}
