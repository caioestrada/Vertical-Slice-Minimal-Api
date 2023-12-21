using Asp.Versioning.Conventions;
using Carter;
using Swashbuckle.AspNetCore.Annotations;

namespace VerticalSliceMinimalApi.Features.Todo.GetTodo
{
    public class GetTodoEndpoint : ICarterModule
    {
        public async Task<IResult> HandleAsync(Guid id, ITodoRepository todoRepository, CancellationToken cancellationToken)
        {
            var output = await todoRepository.GetByIdAsync(id, cancellationToken);

            if (output == null)
                return Results.NotFound();

            return Results.Ok(output);
        }

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/todo/{id}", handler: HandleAsync)
                .WithTags("Todo")
                .WithMetadata(new SwaggerOperationAttribute(summary: "Get todo by id", description: "Route to get todo by id"));
        }
    }
}