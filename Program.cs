using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference(options =>
{
    options.Title = "AWS CodePipeline Demo";
    options.Theme = ScalarTheme.Mars;
});

app.MapGet("/", () => Results.Ok(new
{
    Message = "Hello World from .NET 10 on AWS Elastic Beanstalk",
    Docs = "/scalar/v1"
}));

app.MapGet("/health", () => Results.Ok(new
{
    Status = "Healthy",
    Utc = DateTimeOffset.UtcNow
}))
.WithName("HealthCheck");

app.MapGet("/api/hello", () => Results.Ok(new
{
    Message = "Hello World"
}))
.WithName("GetHello");

app.Run();
