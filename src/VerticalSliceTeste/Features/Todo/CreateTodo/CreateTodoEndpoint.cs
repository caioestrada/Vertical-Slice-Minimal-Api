using Asp.Versioning.Conventions;
using Carter;
using Swashbuckle.AspNetCore.Annotations;

namespace VerticalSliceMinimalApi.Features.Todo.CreateTodo
{
    public class CreateTodoEndpoints : ICarterModule
    {
        public async Task<IResult> HandleAsync(CreateTodoRequest request, ITodoRepository todoRepository, CancellationToken cancellationToken)
        {
            var output = new TodoEntity
            {
                Text = request.Text,
                Completed = false
            };

            await todoRepository.AddAsync(output, cancellationToken);

            return Results.Created();
        }

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/todo", handler: HandleAsync)
                .WithTags("Todo")
                .WithMetadata(new SwaggerOperationAttribute(summary: "Create todo", description: "Route to create todo"))
                .WithApiVersionSet(new Asp.Versioning.Builder.ApiVersionSet(app.NewApiVersionSet(), "todo"))
                .HasApiVersion(1.0);
        }
    }
}