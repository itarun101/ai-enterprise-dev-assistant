var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () => "AI Enterprise Dev Assistant Running...");

app.Run();
