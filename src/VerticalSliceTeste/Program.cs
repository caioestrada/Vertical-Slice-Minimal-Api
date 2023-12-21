using Carter;
using VerticalSliceMinimalApi.Configurations;
using VerticalSliceMinimalApi.Features.Todo;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEfCore();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCarter();

builder.Services.AddApiVersion();
builder.Services.AddSwaggerGen(config => { config.EnableAnnotations(); });

// Features
builder.Services.AddTodoFeature();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapCarter();

app.Run();

public partial class Program { }