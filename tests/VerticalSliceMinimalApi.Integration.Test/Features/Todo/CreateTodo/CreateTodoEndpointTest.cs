using System.Net;
using System.Net.Http.Json;
using VerticalSliceMinimalApi.Features.Todo.CreateTodo;
using VerticalSliceMinimalApi.Integration.Test;

namespace VerticalSliceMinimalApi.Unit.Tests.Features.Todo.CreateTodo
{
    public class CreateTodoEndpointTest : IntegrationTestFactory
    {
        [Fact]
        public async Task CreateTodo_Success()
        {
            // Arrange
            var todoRequest = new CreateTodoRequest { Text = "Teste" };

            // Act
            var todoResult = await _httpClient.PostAsJsonAsync("/todo", todoRequest);

            // Assert
            Assert.Equal(HttpStatusCode.Created, todoResult.StatusCode);
        }
    }
}
