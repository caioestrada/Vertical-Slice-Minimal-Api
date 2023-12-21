using System.Net.Http.Json;
using VerticalSliceMinimalApi.Features.Todo;
using VerticalSliceMinimalApi.Integration.Test;

namespace VerticalSliceMinimalApi.Integration.Tests.Features.Todo.GetAllTodos
{
    public class GetAllTodosEndpointTest : IntegrationTestFactory
    {
        [Fact]
        public async Task GetAllTodos_WithData_ReturnsItems()
        {
            // Arrange
            await _context.Todos.AddAsync(new TodoEntity { Completed = true, Text = "Teste" });
            await _context.SaveChangesAsync();

            // Act
            var todoList = await _httpClient.GetFromJsonAsync<IEnumerable<TodoEntity>>("/todo");

            // Assert
            Assert.NotEmpty(todoList);
        }
    }
}