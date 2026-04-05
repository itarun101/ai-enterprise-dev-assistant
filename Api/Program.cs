using Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add HttpClient
builder.Services.AddHttpClient();

// Register AI Service
builder.Services.AddScoped<AIService>();

var app = builder.Build();

app.MapGet("/", () => "AI Enterprise Dev Assistant Running...");

app.Run();
