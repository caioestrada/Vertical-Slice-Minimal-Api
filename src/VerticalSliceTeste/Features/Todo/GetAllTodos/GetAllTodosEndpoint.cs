using Asp.Versioning;
using Asp.Versioning.Conventions;
using Carter;
using Swashbuckle.AspNetCore.Annotations;

namespace VerticalSliceMinimalApi.Features.Todo.GetAllTodos
{
    public class GetAllTodosEndpoint : ICarterModule
    {
        public async Task<IResult> HandleAsync(ITodoRepository todoRepository, CancellationToken cancellationToken)
        {
            var output = await todoRepository.GetAllAsync(cancellationToken);

            return Results.Ok(output);
        }

        public async Task<IResult> HandleAsync2(ITodoRepository todoRepository, CancellationToken cancellationToken)
        {
            var output = await todoRepository.GetAllAsync(cancellationToken);
            Console.WriteLine("Version 2.0");

            return Results.Ok(output);
        }

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/todo", handler: HandleAsync)
                .WithTags("Todo")
                .WithMetadata(new SwaggerOperationAttribute(summary: "Get all todo", description: "Route to get all todo itens"))
                .WithApiVersionSet(new Asp.Versioning.Builder.ApiVersionSet(app.NewApiVersionSet(), "todo"))
                .HasApiVersion(1.0);

            //app.MapGet("/todo", handler: HandleAsync2)
            //    .WithTags("Todo")
            //    .WithMetadata(new SwaggerOperationAttribute(summary: "Get all todo", description: "Route to get all todo itens"))
            //    .WithApiVersionSet(new Asp.Versioning.Builder.ApiVersionSet(app.NewApiVersionSet(), "todo"))
            //    .HasApiVersion(2.0);
        }
    }
}