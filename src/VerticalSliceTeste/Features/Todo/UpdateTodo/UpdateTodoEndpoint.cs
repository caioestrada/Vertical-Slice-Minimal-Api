using Asp.Versioning.Conventions;
using Carter;
using Swashbuckle.AspNetCore.Annotations;

namespace VerticalSliceMinimalApi.Features.Todo.UpdateTodo
{
    public class UpdateTodoEndpoint : ICarterModule
    {
        public async Task<IResult> HandleAsync(Guid id, TodoEntity input, ITodoRepository todoRepository, CancellationToken cancellationToken)
        {
            var todo = await todoRepository.GetByIdAsync(input.Id, cancellationToken);

            if (todo == null)
            {
                return Results.NotFound();
            }

            todo.Text = input.Text;
            todo.Completed = input.Completed;

            await todoRepository.UpdateAsync(todo, cancellationToken);

            return Results.Ok(todo);
        }

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/todo/{id}", handler: HandleAsync)
                .WithTags("Todo")
                .WithMetadata(new SwaggerOperationAttribute(summary: "Update todo", description: "Route to update todo"));
        }
    }
}