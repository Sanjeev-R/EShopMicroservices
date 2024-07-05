using Carter;
using Marten;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCarter();
builder.Services.AddMediatR(
    config => config.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddMarten(options =>
{
    options.Connection(builder.Configuration.GetConnectionString("DatabaseConnection") ?? string.Empty);
}).UseLightweightSessions();
// Add services to the container.
var app = builder.Build();
app.MapCarter();
// Configure the HTTP request pipeline.

app.Run();
