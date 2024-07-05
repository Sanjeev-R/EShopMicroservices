using Carter;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCarter();
builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(Program).Assembly));
// Add services to the container.
var app = builder.Build();
app.MapCarter();
// Configure the HTTP request pipeline.

app.Run();
