using Carter;
using Swashbuckle.AspNetCore.Annotations;

namespace VerticalSliceMinimalApi.Features.Todo.DeleteTodo
{
    public class DeleteTodoEndpoint : ICarterModule
    {
        public async Task<IResult> HandleAsync(Guid id, ITodoRepository todoRepository, CancellationToken cancellationToken)
        {
            var output = await todoRepository.GetByIdAsync(id, cancellationToken);

            if (output == null)
            {
                return Results.NotFound();
            }

            await todoRepository.DeleteAsync(output, cancellationToken);

            return Results.NoContent();
        }

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/todo/{id}", HandleAsync)
                .WithTags("Todo")
                .WithMetadata(new SwaggerOperationAttribute(summary: "Delete todo by id", description: "Route to delete todo by id"));
        }
    }
}